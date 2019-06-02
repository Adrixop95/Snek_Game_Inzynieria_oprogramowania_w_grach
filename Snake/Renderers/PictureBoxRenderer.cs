using Snake.Controller;
using Snake.Forms;
using Snake.Objects;
using Snake.Snake;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snake.Renderers {

    /// <summary> Funkcja renderująca obraz gry i wysyłająca go do interfejsu aplikacji. </summary>
    public class PictureBoxRenderer : Renderer {
        
        private PictureBox      pictureBox;
        private Label           labelPoints;
        private FormGameOver    formGameOver;


        #region Constructor
        // ######################################################################
        /// <summary> Konstruktor klasy Renderującaej obraz w oknie aplikacji. </summary>
        /// <param name="pictureBox"> Uchwyt do elementu interfejsu. </param>
        public PictureBoxRenderer( PictureBox pictureBox, Label label ) {
            this.pictureBox     =   pictureBox;
            this.labelPoints    =   label;
            this.formGameOver   =   new FormGameOver();
        }

        #endregion Constructor
        #region Renderer
        // ######################################################################
        /// <summary> Funkcja renderująca obraz. </summary>
        /// <param name="apple"> Obiekt jabłka. </param>
        /// <param name="map"> Mapa. </param>
        /// <param name="snake"> Obiekt węża. </param>
        public void RenderGame( Apple apple, Map map, SnakeBlock snake ) {
            try {
                pictureBox.Invoke( new Action( () => {
                    RenderBackground( map );
                    DrawSnake( map, snake );
                    DrawApple( apple, map );
                } ) );
            } catch ( InvalidAsynchronousStateException ) {
                Application.Exit();

            } catch ( InvalidOperationException ) {
                Application.Exit();
            }
        }


        // ----------------------------------------------------------------------
        /// <summary> Funkcja aktualizująca interfejs graficzny. </summary>
        /// <param name="points"> Aktualne punkty. </param>
        public void RenderInterface( int points ) {
            try {
                labelPoints.Invoke( new Action( () => {
                    labelPoints.Text = "Points: " + points.ToString();
                } ) );
            } catch ( InvalidAsynchronousStateException ) {
                Application.Exit();

            } catch ( InvalidOperationException ) {
                Application.Exit();
            }
        }


        // ----------------------------------------------------------------------
        /// <summary> Funkcja renderująca scenę końca gry. </summary>
        /// <param name="isWin"> Informacja o wygranej. </param>
        /// <param name="points"> Aktualne punkty. </param>
        public void RenderGameOverScreen( bool isWin, int points ) {
            formGameOver.Initialize( isWin, points );
        }


        #endregion Renderer
        #region Fragments
        // ######################################################################
        /// <summary> Funkcja prerenderująca tło. </summary>
        /// <returns> Wyrenderowane tło. </returns>
        private void RenderBackground( Map map ) {
            Size        size        =   new Size( pictureBox.Width, pictureBox.Height );
            PixelFormat format      =   PixelFormat.Format32bppArgb;
            Bitmap      bitmap      =   new Bitmap( size.Width, size.Height, format );      
            Graphics    graphics    =   Graphics.FromImage( bitmap );
            Image       tile        =   ScaleBlockSize(
                Properties.Resources.terrain, map.Size, size
            );

            for ( int y = 0; y < size.Height; y++ ) {
                for ( int x = 0; x < size.Width; x++ ) {
                    graphics.DrawImage( tile, x * tile.Width, y * tile.Height );
                }
            }

            pictureBox.Image    =   bitmap;
        }

        // ----------------------------------------------------------------------
        private void DrawSnake( Map map, SnakeBlock snake ) {
            Size        size    =   new Size( pictureBox.Width, pictureBox.Height );
            SnakeBlock  child   =   snake;

            while ( child != null ) {
                Image   tile;
                switch( child.SnakeTile ) {
                    case SnakeTile.HEAD:
                        tile = ScaleBlockSize( Properties.Resources.head, map.Size, size );
                        break;
                    case SnakeTile.TAIL:
                        tile = ScaleBlockSize( Properties.Resources.tail, map.Size, size );
                        break;
                    default:
                        tile = ScaleBlockSize( Properties.Resources.body, map.Size, size );
                        break;
                }

                switch ( child.direction ) {
                    case Direction.UP:
                        tile = RotateImage( tile, -90 );
                        break;
                    case Direction.DOWN:
                        tile = RotateImage( tile, 90 );
                        break;
                    case Direction.LEFT:
                        tile = RotateImage( tile, 180 );
                        break;
                }

                Point drawPoint =   CalculatePosition( child.position, tile.Size );
                var graphics    =   Graphics.FromImage( pictureBox.Image );
                graphics.DrawImage( tile, drawPoint );
                child           =   child.ChildBlock;
            }
        }


        // ----------------------------------------------------------------------
        private void DrawApple( Apple apple, Map map ) {
            Size    size        =   new Size( pictureBox.Width, pictureBox.Height );
            Image   tile        =   ScaleBlockSize( Properties.Resources.apple, map.Size, size );
            Point   drawPoint   =   CalculatePosition( apple.position, tile.Size );
            var graphics        =   Graphics.FromImage( pictureBox.Image );
            graphics.DrawImage( tile, drawPoint );
        }


        #endregion Fragments
        #region Tools
        // ######################################################################
        /// <summary> Funkcja skalująca blok gry do rozmiarów obrazu aplikacji. </summary>
        /// <param name="tile"> Obraz bloku gry. </param>
        /// <param name="nSize"> Rozmiar tablicy (pola gry). </param>
        /// <param name="dest"> Rozmiar obrazu wyjściowego. </param>
        /// <returns> Przeskalowany blok. </returns>
        private Image ScaleBlockSize( Image tile, Size nSize, Size dest ) {
            int width       =   (int) (dest.Width / nSize.Width);
            int height      =   (int) (dest.Height / nSize.Height);
            var format      =   PixelFormat.Format32bppArgb;
            var result      =   new Bitmap( width, height, format );
            var graphics    =   Graphics.FromImage( result );
            graphics.DrawImage( tile, new Rectangle( 0, 0, width, height ) );
            return result;
        }


        // ----------------------------------------------------------------------
        /// <summary> Funkcja obracająca obraz. </summary>
        /// <param name="image"> Obraz wejściowy. </param>
        /// <param name="angle"> Kąt obrotu. </param>
        /// <returns> Obraz wyjściowy. </returns>
        public static Bitmap RotateImage( Image image, float angle ) {
            Bitmap      result      =   new Bitmap( image.Width, image.Height );
            Graphics    graphics    =   Graphics.FromImage( result );

            graphics.TranslateTransform( (float) image.Width / 2, (float) image.Height / 2 );
            graphics.RotateTransform(angle);
            graphics.TranslateTransform( -(float) image.Width/2, -(float) image.Height/2 );
            graphics.DrawImage( image, new Point(0, 0) ); 
            return  result;
        }


        // ----------------------------------------------------------------------
        /// <summary> Funkcja obliczająca pozycję rysowania bloku. </summary>
        /// <param name="position"> Pozycja na mapie. </param>
        /// <param name="tileSize"> Rozmiar kafelka. </param>
        /// <returns></returns>
        private Point CalculatePosition( Point position, Size tileSize ) {
            return new Point( position.X * tileSize.Width, position.Y * tileSize.Height );
        }

        #endregion Tools
        // ######################################################################
    }

}

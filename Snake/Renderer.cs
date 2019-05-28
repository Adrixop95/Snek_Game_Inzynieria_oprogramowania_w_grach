using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snake {

    public class Renderer {
        
        private PictureBox  pictureBox;
        private Graphics    graphics;

        private Bitmap      _background;

        #region Constructor
        // ######################################################################
        /// <summary> Konstruktor klasy Renderującaej obraz w oknie aplikacji. </summary>
        /// <param name="pictureBox"> Uchwyt do elementu interfejsu. </param>
        public Renderer( PictureBox pictureBox ) {
            this.pictureBox     =   pictureBox;
            this.graphics       =   pictureBox.CreateGraphics();
            this._background    =   RenderBackground(
                new Size( 20, 20 ), pictureBox.DisplayRectangle.Size );

            this.pictureBox.Invoke( new Action( () => {
                this.graphics.DrawImage( _background, pictureBox.DisplayRectangle );
            } ) );
        }

        #endregion Constructor
        #region Renderer
        // ######################################################################
        /// <summary> Główna funkcja renderująca cały obraz. </summary>
        public void Render() {
            DrawSnake();
        }

        // ----------------------------------------------------------------------
        /// <summary> Funkcja prerenderująca tło. </summary>
        /// <param name="size"> Rozmiar tablicy (pola gry). </param>
        /// <param name="dest"> Rozmiar obrazu wyjściowego. </param>
        /// <returns> Wyrenderowane tło. </returns>
        private Bitmap RenderBackground( Size size, Size dest ) {
            PixelFormat format      =   PixelFormat.Format32bppArgb;
            Bitmap      result      =   new Bitmap( dest.Width, dest.Height, format );
            Graphics    graphics    =   Graphics.FromImage( result );
            Image       tile        =   ScaleBlockSize(
                Properties.Resources.terrain, size, dest
            );

            for ( int y = 0; y < size.Height; y++ ) {
                for ( int x = 0; x < size.Width; x++ ) {
                    graphics.DrawImage( tile, x * tile.Width, y * tile.Height );
                }
            }

            return result;
        }

        // ----------------------------------------------------------------------
        private void DrawSnake() {
            //
        }

        #endregion Renderer
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

        #endregion Tools
        // ######################################################################
    }

}

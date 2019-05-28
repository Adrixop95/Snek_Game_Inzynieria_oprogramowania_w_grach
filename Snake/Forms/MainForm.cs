using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snake.Forms {

    public partial class MainForm : Form {

        // ######################################################################
        /// <summary> Konstruktor głównego okna aplikacji. </summary>
        public MainForm() {
            InitializeComponent();
        }

        // ----------------------------------------------------------------------
        /// <summary> Funkcja wywoływana przy ładowaniu okna aplikacji. </summary>
        /// <param name="sender"> Handler obecnej klasy okna aplikacji. </param>
        /// <param name="e"> Argumenty zdarzeń funkcji. </param>
        private void MainForm_Load( object sender, EventArgs e ) {
            var screen  =   Screen.PrimaryScreen.WorkingArea;
            this.Left   =   (int) (screen.Width / 2 - this.Width / 2);
            this.Top    =   (int) (screen.Height / 2 - this.Height / 2);
        }

        // ----------------------------------------------------------------------
        /// <summary> Funkcja wywoływana przy wyświetlaniu okna aplikacji. </summary>
        /// <param name="sender"> Handler obecnej klasy okna aplikacji. </param>
        /// <param name="e"> Argumenty zdarzeń funkcji. </param>
        private void MainForm_Shown( object sender, EventArgs e ) {
            //
        }

        // ----------------------------------------------------------------------
        /// <summary> Funkcja wywoływana przed zamknięciem okna aplikacji. </summary>
        /// <param name="sender"> Handler obecnej klasy okna aplikacji. </param>
        /// <param name="e"> Argumenty zdarzeń funkcji. </param>
        private void MainForm_FormClosing( object sender, FormClosingEventArgs e ) {
            string          title       =   "Snake";
            string          content     =   "Do you want close application?";
            DialogResult    messageBox  =   MessageBox.Show(
                content, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question
            );

            if ( messageBox == DialogResult.No ) e.Cancel = true;
        }

        // ----------------------------------------------------------------------
        /// <summary> Funkcja wywoływana po zamknięciu okna aplikacji </summary>
        /// <param name="sender"> Handler obecnej klasy okna aplikacji. </param>
        /// <param name="e"> Argumenty zdarzeń funkcji. </param>
        private void MainForm_FormClosed( object sender, FormClosedEventArgs e ) {
            //
        }

        // ######################################################################
        private void ButtonStartGame_Click( object sender, EventArgs e ) {
            Draw( Background( 10, 10, Properties.Resources.grass ) );
        }

        // ######################################################################
        public Bitmap Background( int width, int height, Image block ) {
            int imageWidth  =   block.Width * width;
            int imageHeight =   block.Height * height;
            var format      =   PixelFormat.Format32bppArgb;
            var bitmap      =   new Bitmap( imageWidth, imageHeight, format );
            var graphics    =   Graphics.FromImage( bitmap );

            for ( int y = 0; y < height; y++ ) {
                for ( int x = 0; x < width; x++ ) {
                    graphics.DrawImage( block, new Point( x * block.Width, y * block.Height ) );
                }
            }

            return bitmap;
        }

        // ----------------------------------------------------------------------
        public void Draw( Bitmap bitmap ) {
            var graphics    =   this.pictBox.CreateGraphics();
            graphics.DrawImage( bitmap, this.pictBox.DisplayRectangle );
        }

        // ######################################################################
    }

}

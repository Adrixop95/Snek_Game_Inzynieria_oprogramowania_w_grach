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
            ClearScreen();
        }

        // ######################################################################
        public void ClearScreen() {
            var g   =   this.pictBox.CreateGraphics();
            g.FillRectangle( Brushes.Black, this.pictBox.DisplayRectangle );

            var p   =   new Pen( new SolidBrush( Color.Red ), 5 );
            g.DrawLine( p, 390, 37, 256, 436 );
            g.DrawLine( p, 256, 436, 604, 183 );
            g.DrawLine( p, 604, 183, 175, 183 );
            g.DrawLine( p, 175, 183, 523, 436 );
            g.DrawLine( p, 523, 436, 390, 37 );
        }

        // ----------------------------------------------------------------------
        public void DrawBackground( int width, int height, Image block ) {
            int imageWidth = block.Width * width;
            int imageHeight = block.Height * height;
            Bitmap bitmap = new Bitmap( imageWidth, imageHeight, PixelFormat.Format32bppArgb );
            Graphics graphics = Graphics.FromImage( bitmap );
            for ( int y = 0; y < height; y++ ) {
                for ( int x = 0; x < width; x++ ) {
                    
                }
            }
        }

        // ----------------------------------------------------------------------
        public void Draw( Bitmap bitmap ) {
            var g   =   this.pictBox.CreateGraphics();
            g.DrawImage( bitmap, 0, 0, this.pictBox.Width, this.pictBox.Height );
        }

        // ######################################################################
    }

}

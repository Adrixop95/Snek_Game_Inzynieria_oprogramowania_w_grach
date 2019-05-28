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

        private GameManager gameManager;
        private Renderer    renderer;

        #region WindowsForm
        // ######################################################################
        /// <summary> Konstruktor głównego okna aplikacji. </summary>
        public MainForm() {
            InitializeComponent();
            //gameManager =   new GameManager();
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

        #endregion WindowsForm
        #region Buttons
        // ######################################################################
        private void ButtonStartGame_Click( object sender, EventArgs e ) {
            renderer    =   new Renderer( this.pictBox );

            renderer.Render();
        }

        #endregion Buttons
        // ######################################################################
        public Size ScaleBlock( int width, int height, Size dest ) {
            int blockWidth  =   (int) (dest.Width / width);
            int blockHeight =   (int) (dest.Height / height);
            return new Size( blockWidth, blockHeight );
        }

        // ----------------------------------------------------------------------
        public void MakeSnake( int x, int y, Image[] blocks ) {
            var graphics    =   this.pictBox.CreateGraphics();
            var blockSize   =   ScaleBlock( 20, 20, this.pictBox.Size );

            foreach ( Image block in blocks ) {
                graphics.DrawImage( block,
                    new Rectangle( x * blockSize.Width, y * blockSize.Height, blockSize.Width, blockSize.Height ) );
                x -= 1;
            }
        }

        // ######################################################################
    }

}

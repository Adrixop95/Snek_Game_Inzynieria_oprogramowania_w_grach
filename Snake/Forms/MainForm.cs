using Snake.Renderers;
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

    /// <summary> Klasa okna aplikacji. </summary>
    public partial class MainForm : Form {

        private Renderer        renderer;


        #region WindowsForm
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
            renderer = null;
            GameManager.Destroy();
        }


        #endregion WindowsForm
        #region Buttons
        // ######################################################################
        private void ButtonStartGame_Click( object sender, EventArgs e ) {
            this.buttonStartGame.Text   =   "Restart";
            renderer                    =   new PictureBoxRenderer( this.pictBox, this.labelPoints );
            if ( GameManager.Instance != null ) GameManager.Restart();
            else GameManager.Initialize( new Size( 20, 15 ), 5, renderer );
        }


        // ----------------------------------------------------------------------
        private void ButtonInformations_Click(object sender, EventArgs e) {
            MessageBox.Show(
                "Snake Game v1.0" + Environment.NewLine +
                    "Authors:" + Environment.NewLine +
                    "Dymarczyk Laura, Dziurka Agata, Karpiński Kamil, Rupala Adrian" + Environment.NewLine +
                    Environment.NewLine +
                    "KNI Uniwersytet Śląski 2019",
                "About",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }


        #endregion Buttons
        // ######################################################################
    }

}

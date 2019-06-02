using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snake.Forms {

    public partial class FormGameOver : Form {

        private bool    isWin;
        private int     points;


        #region WindowsForm
        // ######################################################################
        /// <summary> Konstruktor klasy okna końca gry. </summary>
        public FormGameOver(  ) {
            InitializeComponent();
        }


        // ----------------------------------------------------------------------
        /// <summary> Funkcja inicjalizująca okno końca gry. </summary>
        /// <param name="isWin"> Informacja o wygranej. </param>
        /// <param name="points"> Aktualne punkty. </param>
        public void Initialize( bool isWin, int points ) {
            this.isWin  =   isWin;
            this.points =   points;
            this.ShowDialog();
        }


        // ----------------------------------------------------------------------
        /// <summary> Funkcja wywoływana przy pokazywaniu okna. </summary>
        /// <param name="sender"> Handler obecnej klasy okna. </param>
        /// <param name="e"> Argumenty zdarzeń funkcji. </param>
        private void FormGameOver_Shown(object sender, EventArgs e) {
            labelTitles.Text    =   (isWin ? "Game Complete" : "Game Over")
                + Environment.NewLine + points.ToString() + " points";
        }


        #endregion WindowsForm
        #region Buttons
        // ######################################################################
        /// <summary> Funkcja przycisku zamknij, zamykająca okno końca gry. </summary>
        /// <param name="sender"> Handler obecnej klasy przycisku. </param>
        /// <param name="e"> Argumenty zdarzeń funkcji. </param>
        private void buttonClose_Click( object sender, EventArgs e ) {
            this.Close();
        }


        #endregion Buttons
        // ######################################################################
    }
}

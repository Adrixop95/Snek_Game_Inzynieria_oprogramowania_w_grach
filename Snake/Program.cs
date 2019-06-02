using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snake {

    /// <summary> Główna klasa programu. </summary>
    static class Program {

        static  readonly    string  mutexName   =   "KNI.Snake";


        #region Main Functions
        // ######################################################################
        /// <summary> Funkcja uruchamiająca program. </summary>
        [STAThread]
        static void Main() {
            if ( IsRunning( mutexName ) )
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault( false );
            Application.Run( new Forms.MainForm() );
        }


        // ----------------------------------------------------------------------
        /// <summary> Funkcja sprawdzająca czy aplikacja jest już uruchomiona. </summary>
        /// <param name="mutexName"> Nazwa dostępu międzyprocesorowego. </param>
        /// <returns> Informacja o istniejącej instancji aplikacji. </returns>
        static bool IsRunning( string mutexName ) {
            bool    created     =   false;
            Mutex   mutex       =   new Mutex( true, mutexName, out created );
            if ( created ) { mutex.ReleaseMutex(); }
            return  !created;
        }


        #endregion Main Functions
        // ######################################################################
    }

}

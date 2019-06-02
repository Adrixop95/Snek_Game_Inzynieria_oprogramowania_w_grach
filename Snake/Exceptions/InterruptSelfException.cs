using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake.Exceptions {

    /// <summary> Klasa wyjątku zjedzenia siebie. </summary>
    public class InterruptSelfException : Exception {
        

        // ######################################################################
        /// <summary> Pusty konstruktor wyjątku. </summary>
        public InterruptSelfException() { }


        // ----------------------------------------------------------------------
        /// <summary> Konstruktor wyjątku z możwilośćią podania wiadomości. </summary>
        /// <param name="message"> Informacja o błędzie. </param>
        public InterruptSelfException( string message ) : base( message ) { }


        // ----------------------------------------------------------------------
        /// <summary> Konstruktor wyjątku z możliwością podania wiadomości
        /// i wyjątku wewnętrznego. </summary>
        /// <param name="message"></param>
        /// <param name="inner"></param>
        public InterruptSelfException( string message, Exception inner ) : base( message, inner ) { }


        // ######################################################################
    }

}

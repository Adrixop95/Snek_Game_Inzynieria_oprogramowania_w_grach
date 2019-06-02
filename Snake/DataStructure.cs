using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake {

    /// <summary> Klasa zawierająca dane gracza. </summary>
    public static class DataStructure {

        private static  int points;

    
        // ######################################################################
        /// <summary> Funkcja zwiększająca ilość punktów. </summary>
        /// <param name="increment_amount"> Ilość zebranych punktów. </param>
        public static void IncrementPoints( int increment_amount ) {
            points += increment_amount;
        }


        // ----------------------------------------------------------------------
        /// <summary> Funkcja resetująca punkty. </summary>
        public static void ResetPoints() {
            points = 0;
        }


        // ######################################################################
        /// <summary> Aktualna ilość punktów. </summary>
        public static int Points {
            get { return points; }
        }


        // ######################################################################
    }

}

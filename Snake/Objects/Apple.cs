using Snake.Exceptions;
using Snake.Snake;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake.Objects {

    /// <summary> Klasa obiektu jabłka. </summary>
    public class Apple : ICloneable {

        public  int     points      { get; private set; }   =   1;
        public  Point   position    { get; private set; }


        #region Constructor
        // ######################################################################
        /// <summary> Konstruktor obiektu jabłka. </summary>
        /// <param name="points"> Punkty uzyskiwane po zjedzeniu jabłka. </param>
        public Apple( int points ) {
            this.points = points;
        }
        

        // ----------------------------------------------------------------------
        /// <summary> Implementacja wzorca projektowego "Prototyp". </summary>
        /// <returns> Klon obiektu jabłka. </returns>
        public object Clone() {
            return MemberwiseClone();
        }


        #endregion Constructor
        #region Main Functions
        // ######################################################################
        /// <summary> Funkcja ustawiająca losowo punkt jabłka, na bazie dostępnych punktów. </summary>
        /// <param name="freePoints"> Lista dostępnych punktów. </param>
        /// <returns> Punkt jabłka ustalony losowo. </returns>
        public void RandomPosition( List<Point> freePoints ) {
            if ( freePoints.Count <= 0 ) throw new AppleSpawnException();
            Random  random  =   new Random();
            int     idr     =   random.Next( freePoints.Count );
            SetPosition( freePoints[idr] );
        }


        // ----------------------------------------------------------------------
        /// <summary> Funkcja konfigurująca pozycję jabłka. </summary>
        /// <param name="position"> Pozycja jabłka. </param>
        public void SetPosition( Point position ) {
            this.position   =   position;
        }


        #endregion Main Functions
        #region Getters
        // ######################################################################
        /// <summary> Ilość punktów za jabłko. </summary>
        public int Point {
            get { return this.points; }
        }


        #endregion Getters
        // ######################################################################
    }

}

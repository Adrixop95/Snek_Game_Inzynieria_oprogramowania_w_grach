using Snake.Snake;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake {

    /// <summary> Klasa mapy. </summary>
    public class Map {
        
        private static  Map             _instance;
        private         Size            size;
        private         List<Point>     array;


        #region Constructor
        // ######################################################################
        /// <summary> Prywatny konstruktor klasy obiektu mapy. </summary>
        /// <param name="width"> Szerokość mapy. </param>
        /// <param name="height"> Wysokość mapy. </param>
        private Map( Size size ) {
            this.size = size;
            this.array = new List<Point>();
            this.FillArray();
        }


        // ----------------------------------------------------------------------
        /// <summary> Initializator (konstruktor) klasy obiektu mapy.
        /// Implementacja wzorca projektowego "Prototyp". </summary>
        /// <param name="width"> Szerokość mapy. </param>
        /// <param name="height"> Wysokość mapy. </param>
        public static Map Initialize( Size size ) {
            if ( _instance == null ) { _instance = new Map( size ); }
            return _instance;
        }


        // ----------------------------------------------------------------------
        /// <summary> Funkcja zmieniająca rozmiar mapy. </summary>
        /// <param name="size"> Nowy rozmiar mapy. </param>
        public void Resize( Size size ) {
            _instance   =   new Map( size );
        }


        // ----------------------------------------------------------------------
        /// <summary> Manualny destruktor klasy obiekty mapy.
        /// Implementacja wzorca projektowego "Prototyp". </summary>
        public void Destroy() {
            _instance = null;
        }


        #endregion Constructor
        #region Tools
        // ######################################################################
        public List<Point> FreeFields( SnakeBlock snake ) {
            if ( _instance != null ) {
                List<Point> clone   =   new List<Point>(_instance.array);
                SnakeBlock  child   =   snake;
                while ( child != null ) {
                    if ( clone.Contains( child.position ) )
                        clone.Remove( child.position );
                    child = child.ChildBlock;
                }
                return clone;
            }
            return new List<Point>();
        }


        // ----------------------------------------------------------------------
        private void FillArray() {  
            for ( int x = 0; x < size.Width; x++ ) {
                for ( int y = 0; y < size.Height; y++ ) array.Add( new Point( x, y ) );
            }
        }

        #endregion Tools
        #region Getters
        // ######################################################################
        /// <summary> Zwraca zmienną zawierającą wymiary mapy. </summary>
        public Size Size {
            get {
                if ( _instance != null ) { return _instance.size; }
                return new Size( 0, 0 );
            }
        }


        // ----------------------------------------------------------------------
        /// <summary> Zwraca punkt środkowy mapy. </summary>
        public Point CenterPoint {
            get {
                if ( _instance != null ) {
                    int x = (int) ( _instance.size.Width / 2 );
                    int y = (int) ( _instance.size.Height / 2 );
                    return new Point( x, y );
                }
                return new Point( 0, 0 );
            }
        }


        #endregion Getters
        // ######################################################################
    }

}

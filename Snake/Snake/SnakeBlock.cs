using Snake.Controller;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake.Snake {

    /// <summary> Klasa bloku węża (wąż). </summary>
    public class SnakeBlock : ICloneable {

        private SnakeBlock  childBlock      =   null;
        private SnakeBlock  parentBlock     =   null;
        public  Point       position        { get; private set; }
        public  Direction   direction       { get; private set; }   =   Direction.RIGHT;


        #region Constructor
        // ######################################################################
        /// <summary> Konstruktor klasy obiektu bloku węża. </summary>
        /// <param name="startPoint"> Punkt początkowy węża. </param>
        /// <param name="initialLength"> Wstępna długość węża. </param>
        public SnakeBlock( Point startPoint, int initialLength ) {
            this.position   =   startPoint;
            this.IncreaseBlock( initialLength - 1 );
        }


        // ----------------------------------------------------------------------
        /// <summary> Implementacja wzorca projektowego "Prototyp". </summary>
        /// <returns> Klon bloku węża. </returns>
        public object Clone() {
            return MemberwiseClone();
        }


        #endregion Constructor
        #region Main Functions
        // ######################################################################
        /// <summary> Funckja dodająca rekurencyjnie kolejny blok węża na koniec. </summary>
        /// <param name="count"> Ilość dodawanych bloków. </param>
        public void IncreaseBlock( int count = 1 ) {
            if ( childBlock != null ) {
                childBlock.IncreaseBlock( count );
            } else if ( count > 0 ) {
                childBlock  =   (SnakeBlock) this.Clone();
                childBlock.SetupChild( this );
                childBlock.IncreaseBlock( count - 1 );
            }
        }


        // ----------------------------------------------------------------------
        /// <summary> Funkcja usuwająca poddrzewo dzieci. </summary>
        public void SacrificeChild() {
            childBlock  =   null;
        }


        // ----------------------------------------------------------------------
        /// <summary> Funkcja wykonująca rekurencyjnie kolejny ruch węża. </summary>
        public void Move() {
            CalculateNextPosition();
            if ( childBlock != null ) { childBlock.Move(); }
            InheritDirection();
        }


        // ----------------------------------------------------------------------
        /// <summary> Funkcja zmieniająca kierunek poruszania się węża. </summary>
        public void UpdateDirection( Direction direction ) {
            switch ( direction ) {
                case Direction.NONE:
                    return;

                case Direction.UP:
                    if ( this.direction == Direction.DOWN ) return;
                    break;

                case Direction.DOWN:
                    if ( this.direction == Direction.UP ) return;
                    break;

                case Direction.LEFT:
                    if ( this.direction == Direction.RIGHT ) return;
                    break;

                case Direction.RIGHT:
                    if ( this.direction == Direction.LEFT ) return;
                    break;
            }
            
            this.direction = direction;
        }


        // ----------------------------------------------------------------------
        /// <summary> Funkcja zatrzymująca węża. </summary>
        public void Stop() {
            if ( childBlock != null ) childBlock.Stop();
            direction = Direction.NONE;
        }


        #endregion Main Functions
        #region Tools
        // ######################################################################
        /// <summary> Funkcja konfigurująca ostatni dodany blok węża. </summary>
        private void SetupChild( SnakeBlock parent ) {
            this.parentBlock    =   parent;
            var parentPosition  =   parent.position;
            this.direction      =   parent.direction;

            switch ( direction ) {
                case Direction.UP:
                    position = new Point( parentPosition.X, parentPosition.Y+1 );
                    break;
                    
                case Direction.RIGHT:
                    position = new Point( parentPosition.X-1, parentPosition.Y );
                    break;

                case Direction.DOWN:
                    position = new Point( parentPosition.X, parentPosition.Y-1 );
                    break;

                case Direction.LEFT:
                    position = new Point( parentPosition.X+1, parentPosition.Y );
                    break;
                
                default:
                    position = parentPosition;
                    break;
            }
        }


        // ----------------------------------------------------------------------
        /// <summary> Funkcja aktualizująca kolejną pozycję bloku węża. </summary>
        private void CalculateNextPosition() {
            switch ( direction ) {
                case Direction.UP:
                    position = new Point( position.X, position.Y-1 );
                    break;
                    
                case Direction.RIGHT:
                    position = new Point( position.X+1, position.Y );
                    break;

                case Direction.DOWN:
                    position = new Point( position.X, position.Y+1 );
                    break;

                case Direction.LEFT:
                    position = new Point( position.X-1, position.Y );
                    break;
            }
        }


        // ----------------------------------------------------------------------
        /// <summary> Funkcja aktualizujący rekurencyjnie kierunek poruszania się kolejnego bloku węża. </summary>
        private void InheritDirection() {
            if ( parentBlock != null ) { direction = parentBlock.direction; }
        }


        #endregion Tools
        #region Getters
        // ######################################################################
        /// <summary> Zwraca rekurencyjnie następny blok węża. </summary>
        public SnakeBlock ChildBlock {
            get { return this.childBlock; }
        }


        // ----------------------------------------------------------------------
        /// <summary> Zwraca rekurencyjnie poprzedny blok węża. </summary>
        public SnakeBlock ParentBlock {
            get { return this.parentBlock; }
        }


        // ----------------------------------------------------------------------
        /// <summary> Zwraca informacje o typie bloku węża (HEAD, BODY, TAIL). </summary>
        public SnakeTile SnakeTile {
            get {
                if ( parentBlock == null ) { return SnakeTile.HEAD; }
                else if ( childBlock == null ) { return SnakeTile.TAIL; }
                else { return SnakeTile.BODY; }
            }
        }


        #endregion Getters
        // ######################################################################
    }

}

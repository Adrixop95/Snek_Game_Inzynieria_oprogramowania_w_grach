using Snake.Control;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake.Snake {

    public class SnakeBlock {
        
        private Direction   direction       =   Direction.RIGHT;
        private SnakeBlock  nextBlock       =   null;
        private SnakeBlock  parentBlock     =   null;
        private Point       point;

        #region Constructor
        // ######################################################################
        /// <summary> Konstruktor bloku węża. </summary>
        /// <param name="parent"> Poprzedni fragment węża, jeżeli istnieje. </param>
        public SnakeBlock( Point point, SnakeBlock parent = null ) {
            this.point = point;
            this.parentBlock = parent;
        }

        // ----------------------------------------------------------------------
        /// <summary> Funkcja generująca nowego węża składjącego się z kilku bloków. </summary>
        /// <param name="head"> Pozycja startowa nowego węża. </param>
        /// <param name="length">  </param>
        /// <returns></returns>
        public static SnakeBlock GenerateSnake( Point head, int length ) {
            SnakeBlock snake = new SnakeBlock( head );
            for ( int b = 0; b < Math.Max( 2, length ); b++ ) {
                snake.AddBlock();
            }
            return snake;
        }

        #endregion Constructor
        #region Functions
        // ######################################################################
        /// <summary> Funkcja dodająca na koniec węża kolejny blok. </summary>
        public void AddBlock() {
            if ( nextBlock != null ) { nextBlock.AddBlock(); }
            nextBlock = new SnakeBlock( this.point, this );
        }

        #endregion Functions
        #region Getters
        // ######################################################################
        /// <summary> Kolejny blok węża. </summary>
        public SnakeBlock NextBlock {
            get { return this.nextBlock; }
        }

        // ----------------------------------------------------------------------
        /// <summary> Poprzedni blok węża. </summary>
        public SnakeBlock ParentBlock {
            get { return this.parentBlock; }
        }

        // ----------------------------------------------------------------------
        /// <summary> Typ bloku węża (Head, Body, Tail). </summary>
        public SnakeTiles SnakeTail {
            get {
                if ( this.parentBlock == null ) return SnakeTiles.HEAD;
                else if ( this.nextBlock == null ) return SnakeTiles.TAIL;
                else return SnakeTiles.BODY;
            }
        }

        #endregion Getters
        // ######################################################################
    }

}

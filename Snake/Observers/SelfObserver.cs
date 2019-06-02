using Snake.Exceptions;
using Snake.Snake;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake.Observers {

/// <summary> Klasa obserwatora wyjścia poza mapę. </summary>
    public class SelfObserver : Observer {

        private SnakeBlock  snake;


        // ######################################################################
        /// <summary> Konstruktor klasy obserwatora wyjścia poza mapę. </summary>
        /// <param name="snakeHead"> Blok początkowy węża (wąż). </param>
        /// <param name="map"> Odwołanie do mapy gry. </param>
        public SelfObserver( SnakeBlock snakeHead ) {
            this.snake  =   snakeHead;
        }


        // ######################################################################
        /// <summary> Funkcja aktualizująca i sprawdzająca warunki,
        /// Implementacja wzorca projektowego "Observer". </summary>
        public void Update() {
            Point       position    =   this.snake.position;
            SnakeBlock  child       =   this.snake.ChildBlock;
            while ( child != null ) {
                if ( position == child.position ) {
                    int collect     =   Collect( child );
                    child.ParentBlock.SacrificeChild();
                    throw new InterruptSelfException( collect.ToString() );
                }
                child   =   child.ChildBlock;
            }
        }


        // ----------------------------------------------------------------------
        public int Collect( SnakeBlock block ) {
            SnakeBlock  child   =   block;
            int         result  =   0;
            while ( child != null ) {
                result++;
                child   =   child.ChildBlock;
            }
            return result;
        }


        // ######################################################################
    }

}


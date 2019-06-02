using Snake.Exceptions;
using Snake.Snake;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake.Observers {

    /// <summary> Klasa obserwatora wyjścia poza mapę. </summary>
    public class WallObserver : Observer {

        private Map         map;
        private SnakeBlock  snake;


        // ######################################################################
        /// <summary> Konstruktor klasy obserwatora wyjścia poza mapę. </summary>
        /// <param name="snakeHead"> Blok początkowy węża (wąż). </param>
        /// <param name="map"> Odwołanie do mapy gry. </param>
        public WallObserver( Map map, SnakeBlock snakeHead ) {
            this.map    =   map;
            this.snake  =   snakeHead;
        }


        // ######################################################################
        /// <summary> Funkcja aktualizująca i sprawdzająca warunki,
        /// Implementacja wzorca projektowego "Observer". </summary>
        public void Update() {
            if ( snake.position.Y < 0 ) {
                throw new OutOfMapException( "Wyjście poza górną granicę mapy." );

            } else if ( snake.position.X >= map.Size.Width ) {
                throw new OutOfMapException( "Wyjście poza prawą granicę mapy." );

            } else if ( snake.position.Y >= map.Size.Height ) {
                throw new OutOfMapException( "Wyjście poza dolną granicę mapy." );

            } else if ( snake.position.X < 0 ) {
                throw new OutOfMapException( "Wyjście poza lewą granicę mapy." );

            }
        }


        // ######################################################################
    }

}

using Snake.Controller;
using Snake.Snake;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake.Observers {

    /// <summary> Klasa obserwatora kontroli gracza. </summary>
    public class PlayerObserver : Observer {
        
        private SnakeBlock  snake;


        // ######################################################################
        /// <summary> Konstruktor klasy obserwatora kontroli gracza. </summary>
        /// <param name="snakeHead"> Blok początkowy węża (wąż). </param>
        public PlayerObserver( SnakeBlock snakeHead ) {
            this.snake  =   snakeHead;
        }


        // ######################################################################
        /// <summary> Funkcja aktualizująca kierunek poruszania się gracza i inicjująca ruch,
        /// Implementacja wzorca projektowego "Observer". </summary>
        public void Update() {
            snake.UpdateDirection( InputManager.NextEvent );
            snake.Move();
        }


        // ######################################################################
    }

}

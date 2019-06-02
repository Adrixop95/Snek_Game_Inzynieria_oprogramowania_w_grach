using Snake.Exceptions;
using Snake.Objects;
using Snake.Snake;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake.Observers {

    /// <summary> Klasa obserwatora węża i jabłka. </summary>
    public class PointsObserver : Observer {
        
        private Apple           apple;
        private Map             map;
        private SnakeBlock      snake;


        // ######################################################################
        /// <summary>  </summary>
        /// <param name="apple">  </param>
        /// <param name="map">  </param>
        /// <param name="snake">  </param>
        public PointsObserver( Apple apple, Map map, SnakeBlock snake ) {
            this.apple  =   apple;
            this.map    =   map;
            this.snake  =   snake;
        }


        // ######################################################################
        /// <summary> </summary>
        public void Update() {
            if ( snake.position == apple.position ) {
                snake.IncreaseBlock();
                DataStructure.IncrementPoints( apple.points );
                throw new InterruptAppleException( "Found Apple" );
            }
        }


        // ----------------------------------------------------------------------
        /// <summary> </summary>
        /// <param name="apple"> </param>
        public void UpdateApple( Apple apple ) {
            this.apple  =   apple;
        }


        // ######################################################################
    }

}

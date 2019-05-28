using Snake.Control;
using Snake.Snake;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Snake {

    public sealed class GameManager {
    
        private static  GameManager _instance;

        private bool        active;
        private ThreadStart deleagte;
        private Thread      thread;

        private Input       input;
        private SnakeBlock  snake;

        // ######################################################################
        public GameManager() {
            if ( _instance == null ) { _instance = this; }
            else { return; }

            this.input      =   new Input();

            this.deleagte   =   new ThreadStart( Run );
            this.thread     =   new Thread( deleagte );
            this.active     =   true;
            this.thread.Start();
        }

        // ----------------------------------------------------------------------
        public void Run() {
            while ( active ) {
                Thread.Sleep( 1000 );
                Console.WriteLine( input.NextEvent );
            }
        }

        // ----------------------------------------------------------------------
        ~GameManager() {
            if ( thread.IsAlive ) thread.Abort();
        }

        // ######################################################################
        public static GameManager Instance {
            get {
                if ( _instance == null ) { _instance = new GameManager(); }
                return _instance;
            }
        }

        // ######################################################################
        public static bool Running {
            get { return _instance != null ? _instance.thread.IsAlive : false; }
        }

        // ######################################################################
    }

}

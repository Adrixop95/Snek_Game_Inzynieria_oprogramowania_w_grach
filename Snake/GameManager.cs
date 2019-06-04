using Snake.Controller;
using Snake.Exceptions;
using Snake.Objects;
using Snake.Observers;
using Snake.Renderers;
using Snake.Snake;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Snake {

    /// <summary> Główna klasa gry (menadżer), spinająca wszystkie elementy ze sobą. </summary>
    public sealed class GameManager {
    
        private static  GameManager _instance;
        private Apple               apple;
        private Map                 map;
        private SnakeBlock          snake;
        private int                 speed;
        private Observer[]          observers;
        private Renderer            renderer;

        private bool                active;
        private ThreadStart         deleagte;
        private Thread              thread;


        // ######################################################################
        /// <summary> Konstruktor obiektu menadżera gry. </summary>
        /// <param name="mapSize"> Rozmiar mapy. </param>
        /// <param name="speed"> Szybkość rozgrywki. </param>
        private GameManager( Size mapSize, int speed, Renderer renderer ) {
            InputManager.Initialize();
            this.speed  =   speed;
            this.map    =   Map.Initialize( mapSize );
            this.snake  =   new SnakeBlock( map.CenterPoint, 3 );
            this.apple  =   new Apple( 1 );
            this.apple.RandomPosition( this.map.FreeFields( this.snake ) );
            this.observers  =   new Observer[4] {
                new PlayerObserver( this.snake ),
                new WallObserver( this.map, this.snake ),
                new SelfObserver( this.snake ),
                new PointsObserver( this.apple, this.map, this.snake ),
            };
            this.renderer   =   renderer;
        }


        // ----------------------------------------------------------------------
        ~GameManager() {
            if ( Running ) thread.Abort();
        }


        // ----------------------------------------------------------------------
        public static void Initialize( Size mapSize, int speed, Renderer renderer ) {
            if ( _instance == null ) {
                _instance = new GameManager( mapSize, speed, renderer );
                Start();
            }
        }


        // ----------------------------------------------------------------------
        public static void Destroy() {
            _instance = null;
        }


        // ######################################################################
        public static void Start() {
            if ( _instance != null ) {
                if ( _instance.thread == null ) {
                    _instance.deleagte  =   _instance.Run;
                    _instance.thread    =   new Thread( _instance.deleagte );
                    _instance.active    =   true;
                    _instance.thread.Start();
                }
            }
        }


        // ----------------------------------------------------------------------
        public static void Restart() {
            if ( _instance != null ) {
                Size        size        =   _instance.map.Size;
                int         speed       =   _instance.speed;
                Renderer    renderer    =   _instance.renderer;
                Destroy();
                Initialize( size, speed, renderer );
            }
        }


        // ----------------------------------------------------------------------
        public static void Stop() {
            if ( Running ) {
                _instance.thread.Abort();
                _instance.thread = null;
            }
        }


        // ######################################################################
        public void Run() {
            while ( active ) {
                Thread.Sleep( speed * 10 );

                foreach ( Observer obs in observers ) {
                    try {
                        obs.Update();

                    } catch ( OutOfMapException ) {
                        active = false;
                        renderer.RenderGameOverScreen( false, DataStructure.Points );
                        break;

                    } catch ( InterruptAppleException ) {
                        try {
                            apple = (Apple) apple.Clone();
                            apple.RandomPosition( map.FreeFields( snake ) );
                            ((PointsObserver)obs).UpdateApple( apple );

                        } catch ( AppleSpawnException ) {
                            active = false;
                            renderer.RenderGameOverScreen( true, DataStructure.Points );
                        }
                        break;

                    } catch ( InterruptSelfException e ) {
                        if ( int.TryParse( e.Message, out int p ) ) {
                            DataStructure.IncrementPoints( -p );
                        }
                        continue;
                    }
                    
                }

                renderer.RenderGame( apple, map, snake );
                renderer.RenderInterface( DataStructure.Points );
            }
        }


        // ######################################################################
        public static GameManager Instance {
            get {
                return _instance;
            }
        }


        // ----------------------------------------------------------------------
        public static bool Running {
            get {
                if ( _instance == null ) return false;
                if ( _instance.thread == null ) return false;
                return _instance.thread.IsAlive;
            }
        }


        // ######################################################################
    }

}

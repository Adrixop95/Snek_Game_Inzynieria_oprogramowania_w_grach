using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snake.Controller {

    /// <summary> Klasa odpowiadająca za układanie poleceń w stosie poleceń. </summary>
    public class InputManager {
        
        private static readonly Dictionary<Keys, Direction> _dict = new Dictionary<Keys, Direction>() {
            { Keys.W, Direction.UP },
            { Keys.A, Direction.LEFT },
            { Keys.S, Direction.DOWN },
            { Keys.D, Direction.RIGHT }
        };

        private static      InputManager    _instance;
        private             KeyboardHook    _input;
        private             List<Direction> stack;


        #region Constructor
        // ######################################################################
        /// <summary> Konstruktor klasy kotnroli aplikacji, przechwytora klawiatury
        /// (naciśniętych klawiszy). </summary>
        private InputManager() {
            this.stack          =   new List<Direction>();
            this._input         =   new KeyboardHook();
            this._input.KeyDown +=  new KeyEventHandler( ReadKey );
            foreach ( Keys key in _dict.Keys ) this._input.HookedKeys.Add( key );
            this._input.hook();
        }


        // ----------------------------------------------------------------------
        /// <summary> Destruktor, zwalniający działanie bliblioteki KeyboardHook. </summary>
        ~InputManager() {
            this._input.unhook();
        }

        
        // ----------------------------------------------------------------------
        /// <summary> Initializator (konstruktor) klasy obiektu InputManager.
        /// Implementacja wzorca projektowego "Prototyp". </summary>
        public static void Initialize() {
            if ( _instance == null ) { _instance = new InputManager(); }
        }


        // ----------------------------------------------------------------------
        /// <summary> Manualny destruktor klasy obiekty InputManager.
        /// Implementacja wzorca projektowego "Prototyp". </summary>
        public static void Destroy() {
            _instance = null;
        }


        #endregion Contructor
        #region Worker
        // ######################################################################
        /// <summary> Funkcja wykonująca się po naciśnięciu klawisza.
        /// Dodaje kolejną komendę ruchu do stosu poleceń. </summary>
        /// <param name="sender"> Uchwyt do biblioteki KeyboardHook. </param>
        /// <param name="e"> Zdarzenie z kodem wciśniętego klawisza. </param>
        private void ReadKey( object sender, KeyEventArgs e ) {
            AddEvent( EncodeKey( (Keys) e.KeyValue ) );
        }


        // ----------------------------------------------------------------------
        /// <summary> Funkcja dekodująca kod klawisza na kierunek ruchu. </summary>
        /// <param name="key"> Kod klawisza. </param>
        /// <returns></returns>
        public static Direction EncodeKey( Keys key ) {
            if ( _dict.Keys.Contains( key ) ) { return _dict[key]; }
            return Direction.NONE;
        }


        // ----------------------------------------------------------------------
        /// <summary> Funkcja dodająca event zmiany kierunku ruchu do stosu. </summary>
        /// <param name="direction"> Kierunek ruchu. </param>
        public static void AddEvent( Direction direction ) {
            if ( _instance != null ) {
                if ( direction != Direction.NONE && LastEvent != direction ) {
                    _instance.stack.Add( direction );
                }
            }
        }


        #endregion Worker
        #region Getters
        // ######################################################################
        /// <summary> Kolejne zdarzenie użytkownika. </summary>
        public static Direction NextEvent {
            get {
                if ( _instance != null ) {
                    if ( _instance.stack.Count > 0 ) {
                        var direction = _instance.stack[0];
                        _instance.stack.RemoveAt(0);
                        return direction;
                    }
                }
                return Direction.NONE;
            }
        }


        // ----------------------------------------------------------------------
        /// <summary> Ostatnie dodane zdarzenie. </summary>
        public static Direction LastEvent {
            get {
                if ( _instance != null ) {
                    if ( _instance.stack.Count > 0 ) {
                        return _instance.stack[ _instance.stack.Count - 1 ];
                    }
                }
                return Direction.NONE;
            }
        }


        #endregion Getters
        // ######################################################################
    }

}

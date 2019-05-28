using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snake.Control {

    public class Input {
        
        private KeyboardHook    _input;
        private Keys[]          _keys   =   new Keys[] {
            Keys.W, Keys.A, Keys.S, Keys.D
        };
        private List<Direction> stack;

        #region Constructor
        // ######################################################################
        /// <summary> Konstruktor przechwytora klawiatury (naciśniętych klawiszy). </summary>
        public Input() {
            this.stack          =   new List<Direction>();
            this._input         =   new KeyboardHook();
            this._input.KeyDown +=  new KeyEventHandler( Run );
            foreach ( Keys key in this._keys ) this._input.HookedKeys.Add( key );
            this._input.hook();
        }

        // ----------------------------------------------------------------------
        /// <summary> Funkcja wykonująca się po naciśnięciu klawisza.
        /// Dodaje kolejną komendę ruchu do stosu poleceń. </summary>
        /// <param name="sender"> Uchwyt do biblioteki KeyboardHook. </param>
        /// <param name="e"> Zdarzenie z polem wciśniętego klawisza. </param>
        private void Run( object sender, KeyEventArgs e ) {
            switch ( e.KeyValue ) {
                case (int) Keys.W:
                    stack.Add( Direction.UP );
                    break;

                case (int) Keys.A:
                    stack.Add( Direction.LEFT );
                    break;

                case (int) Keys.S:
                    stack.Add( Direction.DOWN );
                    break;

                case (int) Keys.D:
                    stack.Add( Direction.RIGHT );
                    break;
            }
        }

        // ----------------------------------------------------------------------
        /// <summary> Destruktor, zwalniający działanie bliblioteki KeyboardHook. </summary>
        ~Input() {
            this._input.unhook();
        }

        #endregion Contructor
        #region Getters
        // ######################################################################
        /// <summary> Kolejne zdarzenie użytkownika. </summary>
        public Direction NextEvent {
            get {
                Direction temp = stack.Count <= 0 ? Direction.NONE : stack[0];
                if ( stack.Count > 0 ) { stack.RemoveAt(0); }
                return temp;
            }
        }

        #endregion Getters
        // ######################################################################
    }

}

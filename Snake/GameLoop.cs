using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Snake {

    public class GameLoop {
        
        private bool        active;
        private Thread      thread;
        private ThreadStart inside;

        // ######################################################################
        public GameLoop() {
            this.inside =   new ThreadStart( Run );
            this.thread =   new Thread( inside );
            this.active =   true;
            this.thread.Start();
        }

        // ----------------------------------------------------------------------
        public void Run() {
            while ( active ) {
                Input();
                Update();
                Render();
            }
        }

        // ######################################################################
        private void Input() {
            //
        }

        // ----------------------------------------------------------------------
        private void Update() {
            //
        }

        // ----------------------------------------------------------------------
        private void Render() {
            //
        }

        // ######################################################################
        public bool Running {
            get { return this.active && this.thread.IsAlive; }
        }

        // ######################################################################
    }

}

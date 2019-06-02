using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Snake.Controller;

////////////////////////////////////////////////////////////////////////////////
// https://docs.microsoft.com/pl-pl/visualstudio/test/getting-started-with-unit-testing?view=vs-2019
////////////////////////////////////////////////////////////////////////////////
namespace UnitTests {

    [TestClass]
    public class InputTests {

        private readonly Keys[] keySet = new Keys[] {
            Keys.X,
            Keys.W,
            Keys.A,
            Keys.Y,
            Keys.S,
            Keys.D,
            Keys.Z
        };

        private readonly Direction[] directionSet = new Direction[] {
            Direction.NONE,
            Direction.UP,
            Direction.LEFT,
            Direction.NONE,
            Direction.DOWN,
            Direction.RIGHT,
            Direction.NONE
        };

        private readonly Direction[] outputSet = new Direction[] {
            Direction.UP,
            Direction.LEFT,
            Direction.DOWN, 
            Direction.RIGHT
        };
        

        [TestInitialize]
        public void InputTestsInitialize() {
            InputManager.Initialize();
        }


        [TestMethod]
        public void CorrectKeyTranslate() {
            List<Direction> list = new List<Direction>();

            foreach( Keys key in this.keySet ) {
                var direction = InputManager.EncodeKey( key );
                list.Add( direction );
            }

            for ( int i = 0; i < Math.Min( directionSet.Length, list.Count ); i++ ) {
                Assert.AreEqual( directionSet[i], list[i] );
            }
        }


        [TestMethod]
        public void CorrectStackOutput() {
            List<Direction> list = new List<Direction>();
            Direction readDirection = Direction.RIGHT;

            foreach( Direction dir in this.directionSet ) {
                InputManager.AddEvent( dir );
            }

            while ( readDirection != Direction.NONE ) {
                readDirection = InputManager.NextEvent;
                list.Add( readDirection );
            }

            for ( int i = 0; i < Math.Min( outputSet.Length, list.Count ); i++ ) {
                Assert.AreEqual( outputSet[i], list[i] );
            }
        }


        [TestCleanup]
        public void MapTestsClean() {
            InputManager.Destroy();
        }


    }

}

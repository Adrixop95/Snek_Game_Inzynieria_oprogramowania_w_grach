using System;
using System.Collections.Generic;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Snake;
using Snake.Controller;
using Snake.Exceptions;
using Snake.Objects;
using Snake.Observers;
using Snake.Snake;

////////////////////////////////////////////////////////////////////////////////
// https://docs.microsoft.com/pl-pl/visualstudio/test/getting-started-with-unit-testing?view=vs-2019
////////////////////////////////////////////////////////////////////////////////
namespace UnitTests {

    [TestClass]
    public class ObserverSelfTest {

        private readonly    Size        mapSize     =   new Size( 5, 5 );
        private readonly    Point       spawnPoint  =   new Point( 4, 4 );
        private readonly    int         length      =   12;
        private readonly    Direction[] moves       =   new Direction[] {
            Direction.UP,
            Direction.UP,
            Direction.LEFT,
            Direction.LEFT,
            Direction.DOWN,
            Direction.DOWN,
            Direction.DOWN
        };
        private             Map         map;


        [TestInitialize]
        public void ObserverSelfTestInitialize() {
            this.map    =   Map.Initialize( this.mapSize );
        }


        [TestMethod]
        public void TestEatSelf() {
            SnakeBlock      snake       =   new SnakeBlock( this.map.CenterPoint, length );
            SelfObserver    observer    =   new SelfObserver( snake );
            int             moves       =   0;
            bool            eated       =   false;

            while ( !eated && moves < this.moves.Length ) {
                snake.UpdateDirection( this.moves[moves] );
                snake.Move();
                try { observer.Update(); }
                catch ( InterruptSelfException ) { eated = true; }
                moves++;
            }

            Assert.IsTrue( eated );
        }


        [TestCleanup]
        public void MapTestsClean() {
            this.map.Destroy();
        }


    }

}

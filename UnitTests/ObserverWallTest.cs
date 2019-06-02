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
    public class ObserverWallTest {

        private readonly    Size    mapSize     =   new Size( 5, 5 );
        private readonly    int     length      =   3;
        private             Map     map;


        [TestInitialize]
        public void ObserverWallTestInitialize() {
            this.map    =   Map.Initialize( this.mapSize );
        }


        [TestMethod]
        public void TestOutOfMap() {
            SnakeBlock      snake       =   new SnakeBlock( this.map.CenterPoint, length );
            WallObserver    observer    =   new WallObserver( this.map, snake );
            int             moves       =   3;
            bool            hitted      =   false;

            while ( !hitted && moves > 0 ) {
                snake.Move();
                try { observer.Update(); }
                catch ( OutOfMapException ) { hitted = true; }
                moves--;
            }

            Assert.IsTrue( hitted );
        }


        [TestCleanup]
        public void MapTestsClean() {
            this.map.Destroy();
        }


    }

}

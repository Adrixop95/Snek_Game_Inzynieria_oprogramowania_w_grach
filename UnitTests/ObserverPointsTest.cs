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
    public class ObserverPointsTest {

        private readonly    Size    mapSize     =   new Size( 5, 5 );
        private readonly    Point   spawnPoint  =   new Point( 2, 2 );
        private readonly    Point   applePoint  =   new Point( 4, 2 );
        private readonly    int     length      =   3;
        private             Map     map;
        private             Apple   apple;


        [TestInitialize]
        public void ObserverPointsTestInitialize() {
            DataStructure.ResetPoints();
            this.map    =   Map.Initialize( this.mapSize );
            this.apple  =   new Apple( 1 );
        }


        [TestMethod]
        public void TestAppleEat() {
            this.apple.SetPosition( applePoint );
            SnakeBlock      snake       =   new SnakeBlock( this.map.CenterPoint, length );
            PointsObserver  observer    =   new PointsObserver( this.apple, this.map, snake );
            int             moves       =   2;
            bool            collected   =   false;

            while ( !collected && moves > 0 ) {
                snake.Move();
                try { observer.Update(); }
                catch ( InterruptAppleException ) { collected = true; }
                moves--;
            }

            Assert.IsTrue( collected );
            Assert.AreEqual( this.apple.points, DataStructure.Points );
        }


        [TestCleanup]
        public void MapTestsClean() {
            this.map.Destroy();
        }


    }

}

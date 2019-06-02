using System;
using System.Collections.Generic;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Snake;
using Snake.Controller;
using Snake.Exceptions;
using Snake.Objects;
using Snake.Snake;

////////////////////////////////////////////////////////////////////////////////
// https://docs.microsoft.com/pl-pl/visualstudio/test/getting-started-with-unit-testing?view=vs-2019
////////////////////////////////////////////////////////////////////////////////
namespace UnitTests {

    [TestClass]
    public class AppleTests {

        private readonly    Size        mapSize     =   new Size( 5, 3 );
        private readonly    Point       spawnPoint  =   new Point( 3, 1 );
        private readonly    int         length      =   3;
        private readonly    Point       applePos    =   new Point( 4, 1 );
        private             Map         map;
        private             SnakeBlock  snake;
        private             Apple       apple;


        [TestInitialize]
        public void AppleTestsInitialize() {
            this.map    =   Map.Initialize( this.mapSize );
            this.snake  =   new SnakeBlock( spawnPoint, length );
            this.apple  =   new Apple( 1 );
        }


        [TestMethod]
        public void TestAppleSpawn() {
            apple   =   (Apple) this.apple.Clone();
            apple.SetPosition( applePos );
            Assert.AreEqual( applePos, apple.position );
        }


        [TestMethod]
        public void TestAppleSpawnRandom() {
            var fFields =   new List<Point>();
            for ( int x = 0; x < map.Size.Width; x++ ) {
                for ( int y = 0; y < map.Size.Height; y++ ) fFields.Add( new Point( x, y ) );
            }

            apple   =   (Apple) this.apple.Clone();
            apple.RandomPosition( fFields );
            Assert.IsTrue( fFields.Contains( apple.position ) );
        }


        [TestMethod]
        public void TestAppleSpawnWithPlayer() {
            var fFields =   map.FreeFields( snake );
            apple       =   (Apple) this.apple.Clone();
            apple.RandomPosition( fFields );
            
            SnakeBlock  child   =   snake;
            while ( child != null ) {
                Assert.IsFalse( child.position == apple.position );
                child   =   child.ChildBlock;
            }
            Assert.IsTrue( fFields.Contains( apple.position ) );
        }


        [TestMethod]
        public void TestAppleSpawnError() {
            bool        appleSpawnException =   false;
            SnakeBlock  snake               =   GenerateFillSnake();
            var         fFields             =   map.FreeFields( snake );
                        apple               =   (Apple) this.apple.Clone();
            
            try { apple.RandomPosition( fFields ); }
            catch ( AppleSpawnException ) { appleSpawnException = true; }
            Assert.IsTrue( appleSpawnException );
        }


        private SnakeBlock GenerateFillSnake() {
            SnakeBlock  snake   =   new SnakeBlock( new Point( 4, 0 ), 15 );
            snake.UpdateDirection( Direction.DOWN );
            snake.Move();
            snake.UpdateDirection( Direction.LEFT );
            for ( int m = 0; m < 4; m++ ) snake.Move();
            snake.UpdateDirection( Direction.DOWN );
            snake.Move();
            snake.UpdateDirection( Direction.RIGHT );
            for ( int m = 0; m < 4; m++ ) snake.Move();
            return snake;
        }


        [TestCleanup]
        public void MapTestsClean() {
            this.map.Destroy();
        }


    }

}

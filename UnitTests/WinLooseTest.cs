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
    public class WinLooseTest {

        private readonly    List<Direction> moves   =   new List<Direction>() {
            Direction.RIGHT,
            Direction.RIGHT,
            Direction.RIGHT
        };
        private readonly    Size    mapLooseSize    =   new Size( 5, 5 );
        private readonly    Size    mapWinSize      =   new Size( 5, 1 );
        private readonly    Point   winSpawn        =   new Point( 3, 0 );
        private readonly    int     looseLength     =   3;
        private             int     winLength       =   4;
        private             Apple   apple;

        [TestInitialize]
        public void WinLooseTestsInitialize() {
            apple   =   new Apple( 1 );
        }


        [TestMethod]
        public void WinTest() {
            Map             map             =   Map.Initialize( mapWinSize );
            SnakeBlock      snake           =   new SnakeBlock( winSpawn, winLength );
            apple.RandomPosition( map.FreeFields( snake ) );
            SelfObserver    selfObserver    =   new SelfObserver( snake );
            PointsObserver  pointObserver   =   new PointsObserver( this.apple, map, snake );
            WallObserver    wallobserver    =   new WallObserver( map, snake );
            int             currentMoves    =   0;
            int             expectedMoves   =   2;
            bool            win             =   false;

            while ( !win && expectedMoves > 0 ) {
                snake.UpdateDirection( moves[currentMoves] );
                snake.Move();
                try {
                    pointObserver.Update();
                    selfObserver.Update();
                    wallobserver.Update();
                } catch ( InterruptAppleException ) { 
                    apple   =   (Apple) apple.Clone();
                    try { apple.RandomPosition( map.FreeFields( snake ) ); }
                    catch ( AppleSpawnException ) { win = true; }
                }
                currentMoves++;
                expectedMoves--;
            }

            Assert.IsTrue( win );
            map.Destroy();
        }


        [TestMethod]
        public void LooseTest() {
            Map             map             =   Map.Initialize( mapLooseSize );
            SnakeBlock      snake           =   new SnakeBlock( map.CenterPoint, looseLength );
            SelfObserver    selfObserver    =   new SelfObserver( snake );
            PointsObserver  pointObserver   =   new PointsObserver( this.apple, map, snake );
            WallObserver    wallobserver    =   new WallObserver( map, snake );
            int             currentMoves    =   0;
            int             expectedMoves   =   3;
            bool            loose           =   false;
            apple.RandomPosition( map.FreeFields( snake ) );

            while ( expectedMoves > 0 ) {
                snake.UpdateDirection( moves[currentMoves] );
                snake.Move();
                try {
                    pointObserver.Update();
                    selfObserver.Update();
                    wallobserver.Update();
                } catch ( InterruptAppleException ) { 
                    apple   =   (Apple) apple.Clone();
                    try { apple.RandomPosition( map.FreeFields( snake ) ); }
                    catch ( AppleSpawnException ) { loose = false; }
                } catch ( OutOfMapException ) { loose = true; }
                currentMoves++;
                expectedMoves--;
            }

            Assert.IsTrue( loose );
            map.Destroy();
        }


    }

}

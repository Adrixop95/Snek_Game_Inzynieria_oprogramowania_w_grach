using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Snake.Snake;
using System.Drawing;
using Snake.Controller;

namespace UnitTests {

    [TestClass]
    public class SnakeTests {

        private readonly Direction[] inputDir = new Direction[] {
            Direction.UP,
            Direction.LEFT,
            Direction.NONE,
            Direction.UP,
            Direction.NONE,
            Direction.RIGHT,
            Direction.LEFT,
            Direction.NONE,
            Direction.NONE,
            Direction.DOWN,
            Direction.UP,
            Direction.NONE
        };

        private readonly Direction[] expectedDir = new Direction[] {
            Direction.UP,
            Direction.LEFT,
            Direction.LEFT,
            Direction.UP,
            Direction.UP,
            Direction.RIGHT,
            Direction.RIGHT,
            Direction.RIGHT,
            Direction.RIGHT,
            Direction.DOWN,
            Direction.DOWN,
            Direction.DOWN
        };

        private readonly Direction[] expectedTail = new Direction[] {
            Direction.RIGHT,
            Direction.UP,
            Direction.LEFT,
            Direction.LEFT,
            Direction.UP,
            Direction.UP,
            Direction.RIGHT,
            Direction.RIGHT,
            Direction.RIGHT,
            Direction.RIGHT,
            Direction.DOWN,
            Direction.DOWN
        };


        [TestMethod]
        public void TestSnakeLength() {
            int         length  =   3;
            Point       point   =   new Point( 0, 0 );
            SnakeBlock  snake   =   new SnakeBlock( point, length );
            SnakeBlock  child   =   snake;

            int         iter    =   0;
            while ( child != null ) {
                iter++;
                if ( child.ChildBlock == null ) Assert.AreEqual( iter, length );
                child   =   child.ChildBlock;
            }
        }


        [TestMethod]
        public void TestSnakePositioning() {
            int         xIter   =   3;
            Point       point   =   new Point( xIter, 0 );
            SnakeBlock  snake   =   new SnakeBlock( point, xIter );
            SnakeBlock  child   =   snake;

            while ( child != null ) {
                Assert.AreEqual( child.position.X, xIter );
                xIter--;
                child   =   child.ChildBlock;
            }
        }


        [TestMethod]
        public void TestMovingForward() {
            int         xIter   =   3;
            int         moves   =   3;
            Point       point   =   new Point( xIter, 0 );
            SnakeBlock  snake   =   new SnakeBlock( point, xIter );
            SnakeBlock  child   =   snake;

            for ( int i = 0; i < moves; i++ ) {
                xIter++;
                snake.Move();
            }

            while ( child != null ) {
                Assert.AreEqual( child.position.X, xIter );
                xIter--;
                child   =   child.ChildBlock;
            }
        }


        [TestMethod]
        public void TestTurning() {
            InputManager.Initialize();
            int             length  =   3;
            Point           point   =   new Point( 0, 0 );
            SnakeBlock      snake   =   new SnakeBlock( point, length );
            List<Direction> logs    =   new List<Direction>();

            foreach ( Direction dir in inputDir ) {
                InputManager.AddEvent( dir );
                snake.UpdateDirection( InputManager.NextEvent );
                snake.Move();
                logs.Add( snake.direction );
            }

            for ( int i = 0; i < Math.Min( logs.Count, expectedDir.Length ); i++ ) {
                Assert.AreEqual( expectedDir[i], logs[i] );
            }
        }


        [TestMethod]
        public void TestTail() {
            InputManager.Initialize();
            int             length  =   3;
            Point           point   =   new Point( 0, 0 );
            SnakeBlock      snake   =   new SnakeBlock( point, length );
            List<Direction> logs    =   new List<Direction>();

            foreach ( Direction dir in inputDir ) {
                InputManager.AddEvent( dir );
                snake.UpdateDirection( InputManager.NextEvent );
                snake.Move();

                SnakeBlock  child   =   snake;
                while ( child != null ) {
                    if ( child.ChildBlock == null ) logs.Add( child.direction );
                    child = child.ChildBlock;
                }
            }

            for ( int i = 0; i < Math.Min( logs.Count, expectedTail.Length ); i++ ) {
                Assert.AreEqual( expectedTail[i], logs[i] );
            }
        }

        
    }
}

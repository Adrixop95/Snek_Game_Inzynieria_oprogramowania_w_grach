using System;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Snake;

////////////////////////////////////////////////////////////////////////////////
// https://docs.microsoft.com/pl-pl/visualstudio/test/getting-started-with-unit-testing?view=vs-2019
////////////////////////////////////////////////////////////////////////////////
namespace UnitTests {

    [TestClass]
    public class MapTests {

        private readonly    Size    evenSize    =   new Size( 10, 8 );
        private readonly    Size    oddSize     =   new Size( 9, 7 );
        private readonly    Point   evenPoint   =   new Point( 5, 4 );
        private readonly    Point   oddPoint    =   new Point( 4, 3 );
        private             Map     map;


        [TestInitialize]
        public void MapTestsInitialize() {
            this.map    =   Map.Initialize( this.evenSize );
        }


        [TestMethod]
        public void TestMapSize() {
            Assert.AreEqual( this.evenSize, this.map.Size );
        }


        [TestMethod]
        public void TestEvenCenterPoint() {
            Assert.AreEqual( this.evenPoint, this.map.CenterPoint );
        }


        [TestMethod]
        public void TestOddCenterPoint() {
            this.map.Resize( oddSize );
            Assert.AreEqual( this.oddPoint, this.map.CenterPoint );
        }


        [TestCleanup]
        public void MapTestsClean() {
            this.map.Destroy();
        }


    }

}

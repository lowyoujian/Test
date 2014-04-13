using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FirstApplication;
using NUnit.Framework;
using Moq;

namespace RoomsTests
{
    [TestFixture]
    public class CreateMockWithMoqTest
    {
        private int countSetUp, countTearDown = 0;
        private int testFixtureCountSetUp, testFixtureCountTearDown = 0;
        Mock<IDisplayRoom> midr;
        Mock<ICalculatePrice> micp;
        Room rm1, rm2;

        [TestFixtureSetUp]
        public void DoTestFixtureSetUpOnce()
        {
            testFixtureCountSetUp++;
        }

        [TestFixtureTearDown]
        public void DoTestFixtureTearDownOnce()
        {
            testFixtureCountTearDown++;
        }

        [SetUp]
        public void DoSetUp()
        {
             midr = new Mock<IDisplayRoom>();
             rm1 = new Room(midr.Object);
             micp = new Mock<ICalculatePrice>();
             rm2 = new Room(micp.Object);
             countSetUp++; 
        }

        [TearDown]
        public void DoTearDown()
        {
            midr = null;
            rm1 = null;
            micp = null;
            rm2 = null;
            countTearDown++;
        }

        [Test]
        public void DoDisplay_usingMoq_DisplayRoomInfo()
        {            
            rm1.DoDisplay();
            midr.Verify(m => m.DisplayRoomInfo());

            Assert.AreEqual(2, countSetUp);
            Assert.AreEqual(1, countTearDown);
            Assert.AreEqual(1, testFixtureCountSetUp);
            Assert.AreEqual(0, testFixtureCountTearDown);
        }
        
        [Test]
        public void DoCalculatePrice_usingMoq_CalculatePrice()
        {
           
            rm2.DoCalculatePrice(1);
            micp.Verify(m => m.CalculatePrice(1));

            Assert.AreEqual(1, countSetUp);
            Assert.AreEqual(0, countTearDown);
            Assert.AreEqual(1, testFixtureCountSetUp);
            Assert.AreEqual(0, testFixtureCountTearDown);


        }
    }
}

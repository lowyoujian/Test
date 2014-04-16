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
        
        Mock<IDisplayRoom> midr;
        Mock<ICalculatePrice> micp;
        Room rm1, rm2;



        [Test]
        public void DoDisplay_usingMoq_DisplayRoomInfo()
        {
            midr = new Mock<IDisplayRoom>();
            rm1 = new Room(midr.Object);
            rm1.DoDisplay();
            midr.Verify(m => m.DisplayRoomInfo());

        }
        
        [Test]
        public void DoCalculatePrice_usingMoqwithOneParameter_CalculatePrice()
        {
            micp = new Mock<ICalculatePrice>();
            rm2 = new Room(micp.Object);
            rm2.DoCalculatePrice(1.00);
            micp.Verify(m => m.CalculatePrice(1.00));


        }

        [Test]
        public void DoCalculatePrice_usingMoqwithTwoParameter_CalculatePrice()
        {
            micp = new Mock<ICalculatePrice>();
            rm2 = new Room(micp.Object);
            rm2.DoCalculatePrice(1.00,1);
            micp.Verify(m => m.CalculatePrice(1.00,1));


        }
    }
}


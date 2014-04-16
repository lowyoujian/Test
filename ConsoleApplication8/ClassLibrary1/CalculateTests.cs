using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using FirstApplication;

namespace ClassLibrary1
{
    [TestFixture]
    public class CalculateTests
    {
        
        CustomDiscount calculate; 
        NormalCalculate calculate2;
        PublicHolidayCalculate calculate3;
        SchoolHolidayCalculate calculate4;
         
        [Test]
        public void CustomDiscount_CalculatePriceWithDiscount()
        {   
            calculate = new CustomDiscount();
            double calc = calculate.CalculatePrice(10.00,5);
            Assert.AreEqual(9.50, calc);

        }

        [Test]
        public void CustomDiscount_CalculatePriceWithoutDiscount()
        {
            calculate = new CustomDiscount();
            double calc = calculate.CalculatePrice(5.00);
            Assert.AreEqual(5.00, calc);

        }

        [Test]
        public void NormalDay_CalculatePriceWithDiscount()
        {
            calculate2 = new NormalCalculate();
            double calc2 = calculate2.CalculatePrice(5.00);
            Assert.AreEqual(5.00, calc2);

        }

        [Test]
        public void NormalDay_CalculatePriceWithoutDiscount()
        {
            calculate2 = new NormalCalculate();
            double calc2 = calculate2.CalculatePrice(5.00,2);
            Assert.AreEqual(5.00, calc2);

        }

        [Test]
        public void PublicHoliday_CalculatePriceWithDiscount()
        {
            calculate3 = new PublicHolidayCalculate();
            double calc3 = calculate3.CalculatePrice(20.00);
            Assert.AreEqual(10.00, calc3);

        }

        [Test]
        public void PublicHoliday_CalculatePriceWithoutDiscount()
        {
            calculate3 = new PublicHolidayCalculate();
            double calc3 = calculate3.CalculatePrice(25.00,25);
            Assert.AreEqual(25.00, calc3);

        }

        [Test]
        public void SchoolHoliday_CalculatePriceWithDiscount()
        {
            calculate4 = new SchoolHolidayCalculate();
            double calc4 = calculate4.CalculatePrice(1.00);
            Assert.AreEqual(0.50, calc4);

        }

        [Test]
        public void SchoolHoliday_CalculatePriceWithoutDiscount()
        {
            calculate4 = new SchoolHolidayCalculate();
            double calc4 = calculate4.CalculatePrice(1.00, 1);
            Assert.AreEqual(1.00, calc4);

       }
    }
}


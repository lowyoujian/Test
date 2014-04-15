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
        private int countSetUp, countTearDown = 0;
        private int testFixtureCountSetUp, testFixtureCountTearDown = 0;
        CustomDiscount calculate; 
        NormalCalculate calculate2;
        PublicHolidayCalculate calculate3;
        SchoolHolidayCalculate calculate4;

        [SetUp]
        public void DoSetUp()
        {
            calculate = new CustomDiscount();
            calculate2 = new NormalCalculate();
            calculate3 = new PublicHolidayCalculate();
            calculate4 = new SchoolHolidayCalculate();
            countSetUp++; 
        }

        [TearDown]
        public void DoTearDown()
        {
            calculate = null;
            calculate2 = null;
            calculate3 = null;
            calculate4 = null;
            countTearDown++;
        }

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

        [Test]
        public void CustomDiscount_CalculatePriceWithDiscount()
        {
            double calc = calculate.CalculatePrice(10.00,5);
            Assert.AreEqual(9.50, calc);

            Assert.AreEqual(1, countSetUp);
            Assert.AreEqual(0, countTearDown);
            Assert.AreEqual(1, testFixtureCountSetUp);
            Assert.AreEqual(0, testFixtureCountTearDown);
        }

        [Test]
        public void CustomDiscount_CalculatePriceWithoutDiscount()
        {
            double calc = calculate.CalculatePrice(5.00);
            Assert.AreEqual(5.00, calc);

            Assert.AreEqual(2, countSetUp);
            Assert.AreEqual(1, countTearDown);
            Assert.AreEqual(1, testFixtureCountSetUp);
            Assert.AreEqual(0, testFixtureCountTearDown);
        }

        [Test]
        public void NormalDay_CalculatePriceWithDiscount()
        {
            double calc2 = calculate2.CalculatePrice(5.00);
            Assert.AreEqual(5.00, calc2);

            Assert.AreEqual(3, countSetUp);
            Assert.AreEqual(2, countTearDown);
            Assert.AreEqual(1, testFixtureCountSetUp);
            Assert.AreEqual(0, testFixtureCountTearDown);
        }

        [Test]
        public void NormalDay_CalculatePriceWithoutDiscount()
        {
            double calc2 = calculate2.CalculatePrice(5.00,2);
            Assert.AreEqual(5.00, calc2);

            Assert.AreEqual(4, countSetUp);
            Assert.AreEqual(3, countTearDown);
            Assert.AreEqual(1, testFixtureCountSetUp);
            Assert.AreEqual(0, testFixtureCountTearDown);
        }

        [Test]
        public void PublicHoliday_CalculatePriceWithDiscount()
        {
            double calc3 = calculate3.CalculatePrice(20.00);
            Assert.AreEqual(10.00, calc3);

            Assert.AreEqual(5, countSetUp);
            Assert.AreEqual(4, countTearDown);
            Assert.AreEqual(1, testFixtureCountSetUp);
            Assert.AreEqual(0, testFixtureCountTearDown);
        }

        [Test]
        public void PublicHoliday_CalculatePriceWithoutDiscount()
        {
            double calc3 = calculate3.CalculatePrice(25.00,25);
            Assert.AreEqual(25.00, calc3);

            Assert.AreEqual(6, countSetUp);
            Assert.AreEqual(5, countTearDown);
            Assert.AreEqual(1, testFixtureCountSetUp);
            Assert.AreEqual(0, testFixtureCountTearDown);
        }

        [Test]
        public void SchoolHoliday_CalculatePriceWithDiscount()
        {
            double calc4 = calculate4.CalculatePrice(1.00);
            Assert.AreEqual(0.50, calc4);

            Assert.AreEqual(7, countSetUp);
            Assert.AreEqual(6, countTearDown);
            Assert.AreEqual(1, testFixtureCountSetUp);
            Assert.AreEqual(0, testFixtureCountTearDown);
        }

        [Test]
        public void SchoolHoliday_CalculatePriceWithoutDiscount()
        {
            double calc4 = calculate4.CalculatePrice(1.00, 1);
            Assert.AreEqual(1.00, calc4);

            DoTestFixtureTearDownOnce();
            Assert.AreEqual(8, countSetUp);
            Assert.AreEqual(7, countTearDown);
            Assert.AreEqual(1, testFixtureCountSetUp);
            Assert.AreEqual(1, testFixtureCountTearDown);
        }
    }
}

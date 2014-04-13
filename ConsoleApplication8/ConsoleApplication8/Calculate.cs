using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstApplication
{

    public interface ICalculatePrice
    {
        double CalculatePrice(double normalprice, int discount);
        double CalculatePrice(double normalprice);
    }
    public class SchoolHolidayCalculate : ICalculatePrice
    {
        public double CalculatePrice(double normalPrice)
        {
            double discountedPrice;
            discountedPrice = normalPrice * ((100 - 20) / 100);
            Console.WriteLine("this is the school holiday discount");

            return discountedPrice;
        }

       public double CalculatePrice(double normalprice, int discount)
       {
        return normalprice;
       }
    }

    public class NormalCalculate : ICalculatePrice
    {
        public double CalculatePrice(double normalPrice)
        {
            double discountedPrice;
            discountedPrice = normalPrice * (100 / 100);
            Console.WriteLine("this is the No discount");

            return discountedPrice;
        }

        public double CalculatePrice(double normalprice, int discount)
        {
            return normalprice;
        }
    }



    public class PublicHolidayCalculate : ICalculatePrice
    {
        public double CalculatePrice(double normalPrice)
        {
            double discountedPrice;
            discountedPrice = normalPrice * ((100 - 50) / 100);
            Console.WriteLine("this is the public holiday discount");

            return discountedPrice;
        }

        public double CalculatePrice(double normalprice, int discount)
        {
            return normalprice;
        }
    }

    public class CustomDiscount : ICalculatePrice
    {
        public double CalculatePrice(double normalPrice, int discount)
        {
            double discountedPrice;
            discountedPrice = normalPrice * ((100 - discount) / 100);
            Console.WriteLine("this is the custom discount");

            return discountedPrice;
        }

        public double CalculatePrice(double normalPrice)
        {
            return normalPrice;
        }
    }
}

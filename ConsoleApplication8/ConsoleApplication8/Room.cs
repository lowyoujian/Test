using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstApplication
{
    public interface IDisplayRoom
    {
        void DisplayRoomInfo();
    }

  

    public class Room
    {
        /* need Main to build solution
        static void Main(string[] args)
        {
        }
        */
<<<<<<< HEAD
        public string type = "luxury room"; 
=======
>>>>>>> 5c671ac35043f3aaab73e8b45dbc4e4e47d5ea2b
        private double price;
        protected double discountPrice;
        protected IDisplayRoom myRoom;
        protected ICalculatePrice myCalculate;


        public double DiscountPrice
        {
            get { return discountPrice; }
            set { discountPrice = value; }
        }

        public double Price
        {
            get { return price; }
            set { price = value; }
        }

        public ICalculatePrice MyCalculate
        {
            get { return myCalculate; }
            set { myCalculate = value; }
        }


        public IDisplayRoom MyRoom
        {
            get { return myRoom; }
            set { myRoom = value; }
        }

        public void DoDisplay()
        {
            myRoom.DisplayRoomInfo();
        }
        // Overloaded DoCalculatePrice
        public double DoCalculatePrice(double normalPrice,int discount)
        {
            double discountprice;
            discountprice = myCalculate.CalculatePrice(normalPrice,discount);
            return discountprice;
        }
        public double DoCalculatePrice(double normalPrice)
<<<<<<< HEAD
        {
            double discountprice;
            discountprice = myCalculate.CalculatePrice(normalPrice);
            return discountprice;
        }

        public Room(ICalculatePrice myCalculate)
        {
            this.myCalculate = myCalculate;
        }

        public Room()
        {
        }

        public Room(IDisplayRoom myRoom)
        {
=======
        {
            double discountprice;
            discountprice = myCalculate.CalculatePrice(normalPrice);
            return discountprice;
        }

        public Room(ICalculatePrice myCalculate)
        {
            this.myCalculate = myCalculate;
        }

        public Room()
        {
        }

        public Room(IDisplayRoom myRoom)
        {
>>>>>>> 5c671ac35043f3aaab73e8b45dbc4e4e47d5ea2b
            this.myRoom = myRoom;
        }
    }

   

    public class LuxuryRoom : Room
    {
<<<<<<< HEAD
        public string type = "luxury room";
=======

>>>>>>> 5c671ac35043f3aaab73e8b45dbc4e4e47d5ea2b
        public static double shownPrice = 300;
        static public double available  = 100 + 1; // one object created for display
        public LuxuryRoom()
        { 
            myRoom = new DisplayLuxuryRoom();
            myCalculate = new NormalCalculate();
            available--;
            
        }
    }

    public class NormalRoom : Room
    {
<<<<<<< HEAD
        public string type = "luxury room";
=======
>>>>>>> 5c671ac35043f3aaab73e8b45dbc4e4e47d5ea2b
        public static double shownPrice = 200;
        public double price = 200.00;
        static public int available = 200 + 1; // one object created for display
        public NormalRoom()
        { 
            myRoom = new DisplayNormalRoom();
            myCalculate = new NormalCalculate();
            available--;
        }
    }

    public class BudgetRoom : Room
    {
<<<<<<< HEAD
        public string type = "luxury room";
=======
>>>>>>> 5c671ac35043f3aaab73e8b45dbc4e4e47d5ea2b
        public static double shownPrice = 100;
        public double price = 100.00;
        static public int available = 300 + 1; // one object created for display

        public BudgetRoom()
        {
            myRoom = new DisplayBudgetRoom();
            myCalculate = new NormalCalculate();
            available--;
        }
        
    }

}

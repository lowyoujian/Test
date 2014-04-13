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

    public interface ICalculatePrice
    {
        double CalculatePrice(double normalprice,int discount);
        double CalculatePrice(double normalprice);
    }
    
    

    public abstract class Package
    {
        private List<Room> _rooms = new List<Room>();

        // Constructor calls abstract Factory method

        public Package()
        {
            this.CreateRooms();
        }

        public List<Room> Rooms
        {
            get { return _rooms; }
        }
        // Factory Method
        public abstract void CreateRooms();


    }

    public class FiveLuxuryAndNormalRoom : Package
    {
        // Factory Method implementation
        public override void CreateRooms()
        {
            for (int i = 0; i <= 4; i++)
            { Rooms.Add(new LuxuryRoom()); }

            for (int i = 0; i <= 4; i++)
            { Rooms.Add(new NormalRoom()); }   
        }
    }

    public class TwentyNormalRoom : Package
    {
        // Factory Method implementation
        public override void CreateRooms()
        {
            for (int i = 0; i <= 19; i++)
                Rooms.Add(new NormalRoom());
        }
    }

    


    public class Room
    {
        /* need Main to build solution
        static void Main(string[] args)
        {
        }
        */
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
            this.myRoom = myRoom;
        }
    }

   

    public class LuxuryRoom : Room
    {

        public static double shownPrice = 300;
        static public double available = 100;
        public LuxuryRoom()
        { 
            myRoom = new DisplayLuxuryRoom();
            myCalculate = new NormalCalculate();
            available--;
            
        }
        

    }

    public class NormalRoom : Room
    {
        public static double shownPrice = 200;
        public double price = 200.00;
        static public int available = 200;
        public NormalRoom()
        { 
            myRoom = new DisplayNormalRoom();
            myCalculate = new NormalCalculate();
            available--;
        }

    }

    public class BudgetRoom : Room
    {
        public static double shownPrice = 100;
        public double price = 100.00;
        static public int available = 300;

        public BudgetRoom()
        {
            myRoom = new DisplayBudgetRoom();
            myCalculate = new NormalCalculate();
            available--;
        }
        
    }

    public class DisplayLuxuryRoom : IDisplayRoom
    {
        public void DisplayRoomInfo()
        {
            // Code to show luxury room
            Console.Write("luxury room\t");
            Console.WriteLine("Price : {0} \tRooms available :{1}", LuxuryRoom.shownPrice, LuxuryRoom.available);

        }
    }

    public class DisplayNormalRoom : IDisplayRoom
    {
        public void DisplayRoomInfo()
        {
            // Code to show normal room
        }
    }

    public class DisplayBudgetRoom : IDisplayRoom
    {
        public void DisplayRoomInfo()
        {
            // Code to show Budget room
            Console.WriteLine("this is a budgetRoom");
        }
    }

    public class SchoolHolidayCalculate : ICalculatePrice
    {
        public double CalculatePrice(double normalPrice)
        {
            double discountedPrice;
            discountedPrice = normalPrice * ((100-20)/100);
            Console.WriteLine("this is the school holiday discount");

            return discountedPrice;
        }
    }

    public class NormalCalculate : ICalculatePrice
    {
        public double CalculatePrice(double normalPrice)
        {
            double discountedPrice;
            discountedPrice = normalPrice * (100/100);
            Console.WriteLine("this is the No discount");

            return discountedPrice;
        }
    }



    public class PublicHolidayCalculate : ICalculatePrice
    {
        public double CalculatePrice(double normalPrice)
        {
            double discountedPrice;
            discountedPrice = normalPrice * ((100-30)/100);
            Console.WriteLine("this is the public holiday discount");

            return discountedPrice;
        }
    }

    public class CustomDiscount : ICalculatePrice
    {
        public double CalculatePrice(double normalPrice,int discount)
        {
            double discountedPrice;
            discountedPrice = normalPrice * ((100-discount)/100);
            Console.WriteLine("this is the custom discount");

            return discountedPrice;
        }
        
    }
}

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
        void CalculatePrice(int discount);
    }
    
    public abstract class Room
    {

        private double discountPrice;
        

        protected IDisplayRoom myRoom;
        protected ICalculatePrice myCalculate;

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
        public void DoCalculatePrice(int discount)
        {
            myCalculate.CalculatePrice(discount);
        }
    }

   

    public class LuxuryRoom : Room
    {

        static public double price = 300;
        static public double available = 100;
        public LuxuryRoom()
        { 
            myRoom = new DisplayLuxuryRoom();
            myCalculate = new NormalCalculate();
            
        }
    }

    public class NormalRoom : Room
    {

        static public double price = 200.00;
        static public int available = 200;
        public NormalRoom()
        { 
            myRoom = new DisplayNormalRoom();
            myCalculate = new NormalCalculate();
        }

    }

    public class BudgetRoom : Room
    {
        static public double price = 100.00;
        static public int available = 300;

        public BudgetRoom()
        {
            myRoom = new DisplayBudgetRoom();
            myCalculate = new NormalCalculate();
        }
        
    }

    public class DisplayLuxuryRoom : IDisplayRoom
    {
        public void DisplayRoomInfo()
        {
            // Code to show luxury room
            Console.Write("luxury room\t");
            Console.WriteLine("Price : {0} \tRooms available :{1}",LuxuryRoom.price, LuxuryRoom.available);

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
        public void CalculatePrice(int discount)
        {
            double cost =0;
            //some calculation here
            
        }
    }

    public class NormalCalculate : ICalculatePrice
    {
        public void CalculatePrice(int discount)
        {
            double cost = 0;
            //some calculation here
            Console.WriteLine("normal Calculate");
            
        }
    }



    public class PublicHolidayCalculate : ICalculatePrice
    {
        public void CalculatePrice(int discount)
        {
            double cost = 0;
            //some calculation here
            
        }
    }

    public class CustomDiscount : ICalculatePrice
    {
        public void CalculatePrice(int discount)
        {
            double cost = 0;
            Console.WriteLine("this is the custom discount");

            
        }
        
    }





}

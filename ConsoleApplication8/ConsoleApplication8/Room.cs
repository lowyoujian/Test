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
        double DoCalculate();
    }
    
    public abstract class Room
    {
        private int available;

        protected IDisplayRoom myRoom;

        public IDisplayRoom MyRoom
        {
            get { return myRoom; }
            set { myRoom = value; }
        }

        public void DoDisplay()
        {
            myRoom.DisplayRoomInfo();
        }
        
    }

   

    public class LuxuryRoom : Room
    {
        private double price=300.00;

        public LuxuryRoom()
        { myRoom = new DisplayLuxuryRoom(); }
    }

    public class NormalRoom : Room
    {
        static private double price=200.00;     

        public NormalRoom()
        { myRoom = new DisplayNormalRoom(); }

    }

    public class BudgetRoom : Room
    {
        static private double price=100.00;

        public BudgetRoom()
        { myRoom = new DisplayBudgetRoom(); }
        
    }

    public class DisplayLuxuryRoom : IDisplayRoom
    {
        public void DisplayRoomInfo()
        {
            // Code to show luxury room
            Console.WriteLine("luxury room");
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
        // price for schoolholiday
    }

    public class NormalCalculate : ICalculatePrice
    {
        // price for schoolholiday
    }

    public class SchoolHolidayCalculate : ICalculatePrice
    {
        // price for schoolholiday
    }

    public class PublicHolidayCalculate : ICalculatePrice
    {
        // price for schoolholiday
    }

    public class CustomDiscount : ICalculatePrice
    {
        
    }





}

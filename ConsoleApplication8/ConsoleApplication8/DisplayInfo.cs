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
    public class DisplayLuxuryRoom : IDisplayRoom
    {
        public void DisplayRoomInfo()
        {
            // Code to show luxury room
            Console.Write("Luxury room\t");
            Console.WriteLine("Price : {0} \tRooms available :{1}", LuxuryRoom.shownPrice, LuxuryRoom.available);

        }
    }

    public class DisplayNormalRoom : IDisplayRoom
    {
        public void DisplayRoomInfo()
        {
            // Code to show normal room
            Console.Write("Normal room\t");
            Console.WriteLine("Price : {0} \tRooms available :{1}", NormalRoom.shownPrice, NormalRoom.available);

        }
    }

    public class DisplayBudgetRoom : IDisplayRoom
    {
        public void DisplayRoomInfo()
        {
            // Code to show Budget room
            Console.Write("Budget room\t");
            Console.WriteLine("Price : {0} \tRooms available :{1}", BudgetRoom.shownPrice, BudgetRoom.available);

        }
    }
}

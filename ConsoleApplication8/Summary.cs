using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstApplication
{
    public  class SummaryDisplay
    {
        private List<Room> roomList = new List<Room>();

        public void updateCurrent(List<Room> roomlist)
        {
            this.roomList = roomList.ToList();
            Console.WriteLine("Update summary roomlist");

        }

    }
}

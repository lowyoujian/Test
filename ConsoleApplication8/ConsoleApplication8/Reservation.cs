using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstApplication
{
    public  class Reservation
    {
        private int days=0;
        private double totalPrice=0;
        private List<Room> roomList;

        public double TotalPrice
        {
            get { return totalPrice; }
            set { totalPrice = value; }

        }

        public int Days
        {
            get { return days; }
            set { days = value; }

        }

        public List<Room> RoomList
        {
            get { return roomList; }
            set { roomList = value; }
        }

        public void CalculateTotalPrice()
        {
            foreach (Room room in RoomList)
            {
                this.totalPrice += room.DiscountPrice*days;
            }

        }





    }
}

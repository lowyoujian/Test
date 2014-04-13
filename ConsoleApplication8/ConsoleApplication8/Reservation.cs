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
<<<<<<< HEAD
            foreach (Room room in this.RoomList)
=======
            foreach (Room room in RoomList)
>>>>>>> 5c671ac35043f3aaab73e8b45dbc4e4e47d5ea2b
            {
                this.totalPrice += room.DiscountPrice*days;
            }

        }





    }
}

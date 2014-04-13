using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstApplication
{
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
            set { _rooms = value; }
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
            
            
            Rooms.Add(new LuxuryRoom());
            Rooms.Add(new LuxuryRoom());
            Rooms.Add(new LuxuryRoom());
            Rooms.Add(new LuxuryRoom());
            Rooms.Add(new LuxuryRoom());


            Rooms.Add(new NormalRoom());
            Rooms.Add(new NormalRoom());
            Rooms.Add(new NormalRoom());
            Rooms.Add(new NormalRoom());
            Rooms.Add(new NormalRoom());
<<<<<<< HEAD
            
            
=======
>>>>>>> 5c671ac35043f3aaab73e8b45dbc4e4e47d5ea2b
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
}

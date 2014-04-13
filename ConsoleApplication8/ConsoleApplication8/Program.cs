using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace FirstApplication
{
    public class Program
    {
        static void Main(string[] args)
        {

            string temp;

            Console.WriteLine("Welcome to this hotel");
            Console.WriteLine("Are you a new user?(Y/N)");
            temp = Console.ReadLine();
            User user = new User();
            if (temp.ToUpper() == "Y")
            {
                Console.WriteLine("please enter your desired username");
                user.Name = Console.ReadLine();
                Console.WriteLine("please enter your desired password");
                user.Password = Console.ReadLine();


                if (user.ValidateInput())
                    user.RegisterAccount();

            }
            else
            {
                Console.WriteLine("please enter username");
                user.Name = Console.ReadLine();
                Console.WriteLine("please enter password");
                user.Password = Console.ReadLine();
                if (user.Login())
                    user.DisplayWelcome();
                else
                    Console.WriteLine("failedlogin");
            }
            LuxuryRoom luxroom1 = new LuxuryRoom();
            NormalRoom normalroom1 = new NormalRoom();
            BudgetRoom budgetroom1 = new BudgetRoom();
            List<Room> showRoomList = new List<Room>();
            Console.WriteLine("Here are the rooms we have available");
            foreach (Room room in showRoomList)
            {
                room.DoDisplay();
            }
            showRoomList.Add(luxroom1);
            showRoomList.Add(budgetroom1);
            //change luxrom to customdiscount
            luxroom1.MyCalculate = new CustomDiscount();


            foreach (Room r in showRoomList)
            {
                r.DoDisplay();
                r.DiscountPrice = r.DoCalculatePrice(r.Price, 90);

            }
            Reservation reservation1 = new Reservation();
            Console.WriteLine("Would you be interested in one of our Packages like our bundle of 5 Luxury Rooms and 5 Normal Rooms for only half of its original price?");
            Console.WriteLine("Y/N?");
            temp = Console.ReadLine();
            if (temp.ToUpper() == "Y")
            {

                // Constructors call Factory method
                Package[] packages = new Package[2];

                packages[0] = new FiveLuxuryAndNormalRoom();
                packages[1] = new TwentyNormalRoom();

                Console.WriteLine("1) FiveLuxuryAndNormalRoom \n 2)TwentyNormalRoom \n 3) back");
                Console.WriteLine("choose 1");
                temp = Console.ReadLine();
                if (temp == "1")
                {
                    // Calling Factory Method
                    packages[0].CreateRooms();
                    reservation1.RoomList.AddRange(packages[0].Rooms);
                    Console.WriteLine(packages[0].Rooms);
                    Console.WriteLine(reservation1.RoomList);

                }
                if (temp == "2")
                {
                    packages[1].CreateRooms();
                    reservation1.RoomList.AddRange(packages[1].Rooms);
                    
                }


            }
            reservation1.CalculateTotalPrice();
            


            Console.ReadKey();

        }
    }
    //classes for File.exist for test 
    public interface IFile
    {
        bool Exists(string fn);
    }

    public class FileImpl : IFile
    {
        public virtual bool Exists(string fn)
        { return File.Exists(fn); }
    }

}


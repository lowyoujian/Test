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

        public class Room
        {
            
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
            public double DoCalculatePrice(double normalPrice, int discount)
            {
                double discountprice;
                discountprice = myCalculate.CalculatePrice(normalPrice, discount);
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
        static void Main(string[] args)
        {
            string temp;
            Console.WriteLine("Welcome to this hotel");
            Console.WriteLine("Are you a new user?(Y/N)");
            temp = Console.ReadLine();
            while (temp.ToUpper() != "Y" || temp.ToUpper() != "N")
            {
                if (temp.ToUpper() == "Y")
                {
                    Menu.NewUser();
                    Menu.DisplayRoom();
                }
                else if (temp.ToUpper() == "N")
                {
                    Menu.AlreadyUser();
                    Menu.DisplayRoom();
                }
                else
                {
                    Console.WriteLine("Invalid input. Please try again. Y/N ?");
                    temp = Console.ReadLine();
                }
            }

            Console.ReadKey();
        }
    }


    // Interfaces needed to mock Files system in System.IO
    public interface IFile
    {
        bool Exists(string fn);
    }

    public class FileImpl : IFile
    {
        public virtual bool Exists(string fn)
        { return File.Exists(fn); }
    }

    public class Menu
    {
        public static void Selection()
        {
            string selection;
            Console.WriteLine("Do you want to add more rooms? Y/N");
            selection = Console.ReadLine();

            if (selection.ToUpper() == "Y")
            {
                //Back to Room Menus
                Console.Clear();
                LuxuryRoom luxroom1 = new LuxuryRoom();
                NormalRoom normalroom1 = new NormalRoom();
                BudgetRoom budgetroom1 = new BudgetRoom();
                List<Room> showRoomList = new List<Room>();

                Console.WriteLine("Here are the rooms we have available");
                foreach (Room room in showRoomList)// Display rooms with price
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
                Console.ReadKey();

            }
            else if (selection.ToUpper() == "N")
            {
                //Proceed to receipt
            }
        }

        public static void NewUser()
        {
            User user = new User();
            Console.WriteLine("Please enter your desired username");
            user.Name = Console.ReadLine();
            Console.WriteLine("Please enter your desired password");
            user.Password = Console.ReadLine();
            Console.WriteLine("");
            if (user.ValidateInput())
            {
                user.RegisterAccount();
                Console.WriteLine("You are now logged in");
                Console.WriteLine("Press any key to continue");
                Console.ReadKey();
                Console.Clear();
            }



        }
        public static void AlreadyUser()
        {
            {
                User user = new User();
                Console.WriteLine("please enter username");
                user.Name = Console.ReadLine();
                Console.WriteLine("please enter password");
                user.Password = Console.ReadLine();
                if (user.Login())
                    user.DisplayWelcome();
                else
                    Console.WriteLine("failedlogin");


            }
        }



        public static void DisplayRoom()
        {
            string temp;


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
                reservation1.RoomList = new List<Room>();

                Console.WriteLine("1) FiveLuxuryAndNormalRoom \n 2)TwentyNormalRoom \n 3) back");
                Console.WriteLine("choose 1");
                temp = Console.ReadLine();
                if (temp == "1")
                {
                    // Calling Factory CreateRoom Method Method                  
                    foreach (Room room in packages[0].Rooms)
                    {
                        room.MyCalculate = new PublicHolidayCalculate();
                    }
                    reservation1.RoomList.Concat(packages[0].Rooms);
                    Selection();
                }
                if (temp == "2")
                {
                    reservation1.RoomList.AddRange(packages[1].Rooms);
                    Selection();
                }
            }

            else if (temp.ToUpper() == "N")
            {
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
            }
            reservation1.CalculateTotalPrice();
            Console.ReadKey();

        }
    }

    


}


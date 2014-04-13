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
            string choice;
            Console.WriteLine("Welcome to this hotel");
            Console.WriteLine("Are you a new user?(Y/N)");
            choice = Console.ReadLine();
            while (choice.ToUpper() != "Y" || choice.ToUpper() != "N")
            {
                if (choice.ToUpper() == "Y")
                { Menu.NewUser();}
                else if (choice.ToUpper() == "N")
                {Menu.AlreadyUser();   }
                else
                {
                    Console.WriteLine("Invalid input. Please try again. Y/N ?");
                    choice = Console.ReadLine();
                }
            }
            Menu.DisplayRoom();

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
            bool valid = true ;
            User user = new User();
            do
            {
                Console.WriteLine("Please enter your desired username. (must contain at least 3 and max of 20 characters");
                user.Name = Console.ReadLine();
                Console.WriteLine("Please enter your desired password. (must contain at least 7 characters)");
                user.Password = Console.ReadLine();
                Console.WriteLine("");
                valid = user.ValidateInput();// Returns false if doesn't meet criteria
                if (valid)
                {
                    user.RegisterAccount();
                    Console.WriteLine("You are now logged in");
                    Console.WriteLine("Press any key to continue");
                    Console.ReadKey();
                    Console.Clear();
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Username or password do not match criteria. Please try again.");
                }
            } while (!valid );


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
            string choice;


            Reservation reservation1 = new Reservation();
            Console.WriteLine("Would you be interested in one of our Packages like our bundle of 5 Luxury Rooms and 5 Normal Rooms for only half of its original price?");
            Console.WriteLine("Y/N?");
            choice = Console.ReadLine();
            if (choice.ToUpper() == "Y")
            {
                // Constructors call Factory method
                Package[] packages = new Package[2];

                packages[0] = new FiveLuxuryAndNormalRoom();
                packages[1] = new TwentyNormalRoom();
                reservation1.RoomList = new List<Room>();

                Console.WriteLine("1) FiveLuxuryAndNormalRoom \n 2)TwentyNormalRoom \n 3) back");
                Console.WriteLine("choose 1");
                choice = Console.ReadLine();
                if (choice == "1")
                {
                    // Calling Factory CreateRoom Method Method                  
                    foreach (Room room in packages[0].Rooms)
                    {
                        room.MyCalculate = new PublicHolidayCalculate();
                    }
                    reservation1.RoomList.Concat(packages[0].Rooms);
                    Selection();
                }
                if (choice == "2")
                {
                    reservation1.RoomList.AddRange(packages[1].Rooms);
                    Selection();
                }
            }

            else if (choice.ToUpper() == "N")
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


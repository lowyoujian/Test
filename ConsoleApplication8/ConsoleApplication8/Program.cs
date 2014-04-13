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
            while (temp.ToUpper() != "Y" || temp.ToUpper() != "N")
            {             
            if (temp.ToUpper() == "Y")
            {
                Option.NewUser();
                Option.DisplayRoom();   
            }
            else if (temp.ToUpper() == "N")
            {
                Option.AlreadyUser();
                Option.DisplayRoom();   
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



    public class Option
    {
        public static void Selection()
        {
            string selection;
            Console.WriteLine("Do you want to add more rooms? Y/N");
            selection = Console.ReadLine();
            if(selection.ToUpper() == "Y")
            {
                //Back to Room Options
                Console.Clear();
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
                 Console.ReadKey();
                
            }
            else if(selection.ToUpper() == "N")
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
            

     
    
































    public interface IDisplayRoom
    {
        void DisplayRoomInfo();
    }



    public class Room
    {
        /* need Main to build solution
static void Main(string[] args)
{
}
*/
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



    public class LuxuryRoom : Room
    {

        public static double shownPrice = 300;
        static public double available = 100 + 1; // one object created for display
        public LuxuryRoom()
        {
            myRoom = new DisplayLuxuryRoom();
            myCalculate = new NormalCalculate();
            available--;

        }
    }

    public class NormalRoom : Room
    {
        public static double shownPrice = 200;
        public double price = 200.00;
        static public int available = 200 + 1; // one object created for display
        public NormalRoom()
        {
            myRoom = new DisplayNormalRoom();
            myCalculate = new NormalCalculate();
            available--;
        }
    }

    public class BudgetRoom : Room
    {
        public static double shownPrice = 100;
        public double price = 100.00;
        static public int available = 300 + 1; // one object created for display

        public BudgetRoom()
        {
            myRoom = new DisplayBudgetRoom();
            myCalculate = new NormalCalculate();
            available--;
        }

    }

    public class User
    {


        private string name;
        private string password;


        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        //Methods
        public bool ValidateInput()
        {
            //Text from textfield are added to the object variables
            //Account stored in a file
            name = this.name.Trim();
            password = this.password.Trim();

            if (name.Length >= 3 && name.Length <= 20 && password.Length >= 7)
            {
                return true;
            }
            else
            {
                Console.WriteLine("fields not correct");
                return false;
            }
        }
        public void RegisterAccount()
        {
            using (StreamWriter writer = new StreamWriter("Users.txt"))
            {
                writer.Write(this.name);
                writer.Write(string.Format("\n" + this.password + "\n"));
                Console.WriteLine("register successfull");
            }
        }
        public bool Login()
        {

            this.name = "1234";
            this.password = "12345678";
            string firststr;
            string secondstr;
            try
            {
                using (StreamReader reader = new StreamReader("Users.txt"))
                {
                    while ((firststr = reader.ReadLine()) != null)
                    {


                        if (firststr == name)
                        {
                            secondstr = reader.ReadLine();

                            if (secondstr == password)
                            {
                                return true;
                            }
                        }
                    }
                    return false;

                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read: ");
                Console.WriteLine(e.Message);
                return false;
            }

        }
        public void DisplayWelcome()
        {
            Console.WriteLine("welcome! {0}", this.name);
        }

        public User()
        {
        }
        public User(Object objecta)
        {
        }

    }

    public interface ICalculatePrice
    {
        double CalculatePrice(double normalprice, int discount);
        double CalculatePrice(double normalprice);
    }
    public class SchoolHolidayCalculate : ICalculatePrice
    {
        public double CalculatePrice(double normalPrice)
        {
            double discountedPrice;
            discountedPrice = normalPrice * ((100 - 20) / 100);
            Console.WriteLine("this is the school holiday discount");

            return discountedPrice;
        }

        public double CalculatePrice(double normalprice, int discount)
        {
            return normalprice;
        }
    }

    public class NormalCalculate : ICalculatePrice
    {
        public double CalculatePrice(double normalPrice)
        {
            double discountedPrice;
            discountedPrice = normalPrice * (100 / 100);
            Console.WriteLine("this is the No discount");

            return discountedPrice;
        }

        public double CalculatePrice(double normalprice, int discount)
        {
            return normalprice;
        }
    }



    public class PublicHolidayCalculate : ICalculatePrice
    {
        public double CalculatePrice(double normalPrice)
        {
            double discountedPrice;
            discountedPrice = normalPrice * ((100 - 30) / 100);
            Console.WriteLine("this is the public holiday discount");

            return discountedPrice;
        }

        public double CalculatePrice(double normalprice, int discount)
        {
            return normalprice;
        }
    }

    public class CustomDiscount : ICalculatePrice
    {
        public double CalculatePrice(double normalPrice, int discount)
        {
            double discountedPrice;
            discountedPrice = normalPrice * ((100 - discount) / 100);
            Console.WriteLine("this is the custom discount");

            return discountedPrice;
        }

        public double CalculatePrice(double normalPrice)
        {
            return normalPrice;
        }
    }

    public class Reservation
    {
        private int days = 0;
        private double totalPrice = 0;
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
                this.totalPrice += room.DiscountPrice * days;
            }

        }





    }

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
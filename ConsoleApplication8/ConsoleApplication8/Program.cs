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
            
        public static void DisplayRoom()
        {
		string temp2;
                string temp3;
                
                /* 
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
                */

                Reservation reservation1 = new Reservation();
                Console.WriteLine("Would you be interested in one of our Packages like our bundle of 5 Luxury Rooms and 5 Normal Rooms for only half of its original price?");
                Console.WriteLine("Y/N?");
                temp2 = Console.ReadLine();
                if (temp2.ToUpper() == "Y")
                {   
                    // Constructors call Factory method
                    Package[] packages = new Package[2];
                    packages[0] = new FiveLuxuryAndNormalRoom();
                    packages[1] = new TwentyNormalRoom();
                    reservation1.RoomList = new List<Room>();
                
                    Console.WriteLine("1) FiveLuxuryAndNormalRoom \n 2)TwentyNormalRoom \n 3) back");
                    Console.WriteLine("choose 1");
                    temp3 = Console.ReadLine();
                    if(temp3 == "1")
                    {
                    // Calling Factory CreateRoom Method Method
                        foreach (Room room in packages[0].Rooms)
                        {
                        room.MyCalculate = new PublicHolidayCalculate();
                        }
                        reservation1.RoomList.Concat(packages[0].Rooms);
                        Selection();
                    }
                    else if (temp3 == "2")
                    {
                        reservation1.RoomList.AddRange(packages[1].Rooms);
                        Selection();
                    }
                }

<<<<<<< HEAD
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
                reservation1.RoomList = new List<Room>();
                


                Console.WriteLine("1) FiveLuxuryAndNormalRoom \n 2)TwentyNormalRoom \n 3) back");
                Console.WriteLine("choose 1");
                temp = Console.ReadLine();
                if (temp == "1")
                {
                    // Calling Factory CreateRoom Method Method
                    Console.WriteLine(packages[0].Rooms.Count);
                    Console.WriteLine(reservation1.RoomList.Count);
                    
=======
            reservation1.CalculateTotalPrice();

            Console.ReadKey();
>>>>>>> 5c776bf151fce90d55438efe6c174b3908700d00

        }
        
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
<<<<<<< HEAD
                    
                    reservation1.RoomList.AddRange(packages[1].Rooms);

=======
                    room.DoDisplay();
>>>>>>> 5c776bf151fce90d55438efe6c174b3908700d00
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
<<<<<<< HEAD
            reservation1.CalculateTotalPrice();
            Console.WriteLine(reservation1.TotalPrice);



            Console.ReadKey();

=======
>>>>>>> 5c776bf151fce90d55438efe6c174b3908700d00
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


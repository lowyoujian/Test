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
            string choice;
            int i = 1;
            bool valid = true;
            User user = new User(); // Create new User
            Reservation reservation1 = new Reservation();
            Console.WriteLine("Welcome to this hotel");
            do
            {
                Console.WriteLine("Are you a new user?(Y/N)");
                choice = Console.ReadLine();
                choice = choice.ToUpper();
                valid = Validate.ValidateYesOrNo(choice);
                
                    if (choice == "Y")
                    { user.NewUser();}
                    else if (choice == "N")
                    { user.AlreadyUser(); }

            } while (valid == false);

            LuxuryRoom luxroom1 = new LuxuryRoom();
            NormalRoom normalroom1 = new NormalRoom();
            BudgetRoom budgetroom1 = new BudgetRoom();
            List<Room> showRoomList = new List<Room>();

            showRoomList.Add(luxroom1);
            showRoomList.Add(normalroom1);
            showRoomList.Add(budgetroom1);
            Console.WriteLine("Here are the rooms we have available");

            foreach (Room room in showRoomList)
            {
                Console.Write("{0} ",i++);// Numbering of room
                room.DoDisplay();
            }
         
            do
            {
                Console.WriteLine("Please Choose the Room you want to book (1/2/3)");
                choice = Console.ReadLine();
                valid = Validate.ValidateYesOrNo(choice);
                if (valid)
                {
                    if ( choice == "Y")
                    {
                        //TODO validate data
                        if (choice == "1")
                        {
                            reservation1.RoomList.Add(new LuxuryRoom());
                        }
                        if (choice == "2")
                        {
                            reservation1.RoomList.Add(new NormalRoom());
                        }
                        if (choice == "3")
                        {
                            reservation1.RoomList.Add(new BudgetRoom());
                        }

                        //TODO ask again after choosing room
                        Console.WrietLine("Do you want to add more rooms? Y/N?");
                        choice=Console.ReadLine();
                        valid = Validate.ValidateYesOrNo(choice);
                        while(choice!="N")
                        {
                            Console.WriteLine("Please Choose the Room you want to book (1/2/3)");
                            choice=Console.ReadLine();
                            if (choice == "1")
                            {
                                reservation1.RoomList.Add(new LuxuryRoom());
                            }
                            if (choice == "2")
                            {
                                reservation1.RoomList.Add(new NormalRoom());
                            }
                            if (choice == "3")
                            {
                                reservation1.RoomList.Add(new BudgetRoom());
                            }
                            else 
                            {
                                Console.WriteLine("Invalid input, please try again.");
                                Console.WriteLine("Please Choose the Room you want to book (1/2/3)");
                            }
                        }
                        
                        //Checkout
                        

                    }
                    else if (choice == "N")
                    {
                        // TODO nothing
                    }
                }
                    

                
                {
                    //Proceed to receipt
                }
            }

            
            Menu.DisplayRoom(reservation1);

            Console.ReadKey();
        }
    }

    public class Validate
    {
        public static bool ValidateYesOrNo(string str)
        {
            str = str.ToUpper();
            if (str == "Y" || str == "N")
            { return true; }
            else
            { return false; }
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

  
       

        public static void DisplayRoom(Reservation reservation1)
        {
            string choice;


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
                


                
            }
            reservation1.CalculateTotalPrice();
            Console.ReadKey();

        }
    }

    


}


 public class Option
    {
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
        public static bool UserLogin()
        {
            string temp;            
            Console.WriteLine("Welcome to this hotel");
            Console.WriteLine("Are you a new user?(Y/N)");
            temp = Console.ReadLine();
            User user = new User();
            if (temp.ToUpper() == "Y")
            {
=======
        public static void NewUser()
        {
                User user = new User();
>>>>>>> 589882458299e0862bfae3ca2f293fc8e1a38a27
=======
        public static void NewUser()
        {
                User user = new User();
>>>>>>> 5c776bf151fce90d55438efe6c174b3908700d00
=======
        public static void NewUser()
        {
                User user = new User();
>>>>>>> 5c671ac35043f3aaab73e8b45dbc4e4e47d5ea2b
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
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
                return true;
                
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
                return false;
            }


        }
=======
=======
>>>>>>> 5c776bf151fce90d55438efe6c174b3908700d00
=======
>>>>>>> 5c671ac35043f3aaab73e8b45dbc4e4e47d5ea2b
                
                
            
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


        
<<<<<<< HEAD
<<<<<<< HEAD
>>>>>>> 589882458299e0862bfae3ca2f293fc8e1a38a27
=======
>>>>>>> 5c776bf151fce90d55438efe6c174b3908700d00
=======
>>>>>>> 5c671ac35043f3aaab73e8b45dbc4e4e47d5ea2b

        public static void DisplayRoom()
        {
                string temp2;
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
            Console.WriteLine("");
            Console.WriteLine("Would you be interested in one of our Packages like our bundle of\n5 Luxury Rooms and 5 Normal Rooms for only half of its original price?");
            Console.WriteLine("Y/N?");
            temp2 = Console.ReadLine();
            if (temp2.ToUpper() == "Y")
            {

                // Constructors call Factory method
                Package[] packages = new Package[2];

                packages[0] = new FiveLuxuryAndNormalRoom();
                packages[1] = new TwentyNormalRoom();

                Console.WriteLine("1) FiveLuxuryAndNormalRoom \n 2)TwentyNormalRoom \n 3) back");
                Console.WriteLine("choose 1");
                temp2 = Console.ReadLine();
                if (temp2 == "1")
                {
                    // Calling Factory Method
                    packages[0].CreateRooms();
                    reservation1.RoomList.AddRange(packages[0].Rooms);
                    Console.WriteLine(packages[0].Rooms);
                    Console.WriteLine(reservation1.RoomList);

                }
                if (temp2 == "2")
                {
                    packages[1].CreateRooms();
                    reservation1.RoomList.AddRange(packages[1].Rooms);

                }


            }
            reservation1.CalculateTotalPrice();
            
        }
            

     
    }

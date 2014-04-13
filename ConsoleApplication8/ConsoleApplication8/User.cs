using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

/*TODO
 *Add real code into methods related to room
 */

namespace FirstApplication
{
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
        public bool LoginCheck()
        {

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


        public  void NewUser()
        {
            bool valid = true;
            do
            {
                Console.WriteLine("Please enter your desired username. (must contain at least 3 and max of 20 characters");
                this.Name = Console.ReadLine();
                Console.WriteLine("Please enter your desired password. (must contain at least 7 characters)");
                this.Password = Console.ReadLine();
                Console.WriteLine("");
                valid = this.ValidateInput();// Returns false if doesn't meet criteria
                if (valid)
                {
                    this.RegisterAccount();
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
            } while (valid == false);


        }
        public void AlreadyUser()
        {
            {
                Console.WriteLine("please enter username");
                this.Name = Console.ReadLine();
                Console.WriteLine("please enter password");
                this.Password = Console.ReadLine();
                if (this.LoginCheck())
                    this.DisplayWelcome();
                else
                    Console.WriteLine("failedlogin");


            }
        }
        public User()
        {
        }
        public User(Object objecta)
        {
        }

    }
}
    


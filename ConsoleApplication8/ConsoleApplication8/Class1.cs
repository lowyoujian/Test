using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace FirstApplication
{
    public class User
    {
        private string name;
        private string password;
        public  string Name
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
            name     = this.name.Trim();
            password = this.password.Trim();

            if ( name.Length>=3 && name.Length <= 20 && password.Length >= 7) 
            {
                return true;
            }
            else 
            {
                return false;
            }
        }
        public void RegisterAccount()
        {
            using (StreamWriter writer = new StreamWriter("Users.txt"))
            {
                writer.Write(name);
                writer.Write(string.Format("\n" + password + "\n"));
            }
        }
        public bool Login()
        {

            this.name = "12h34";
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
        public void DisplayWelcome(bool value)
        {
            //TODO Welcome user
        }

    
                 



        public User()
        {
        }
        public User(Object objecta)
        {
        }

    }
    public class Program
    {
        static void Main(string[] args)
        {
            User user     = new User();
            user.Name     = "1234";
            user.Password = "12345678";
            if (user.ValidateInput())
            {
                user.RegisterAccount();
            }
            if (user.Login())
                Console.WriteLine("success");
            else
                Console.WriteLine("failed");
         
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

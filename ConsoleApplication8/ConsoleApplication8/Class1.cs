using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FirstApplication
{
    public class User
    {
        private string name;
        private string password;
        static bool namebool;
        static bool passwordbool;
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
        public bool RegisterAccount()
        {
            //Text from textfield are added to the object variables    
            //Account stored in a file
            name     = this.name.Trim();
            password = this.password.Trim();
           
            if ( name.Length>=3 && name.Length <= 20)
            {
                namebool=true;
            }
            else 
            {
               namebool=false;
            }


             if ( password.Length>=6)
            {
                passwordbool = true;
            }
            else 
            {
                passwordbool = false;
            }
             return (namebool && passwordbool);
        }
        public User()
        {
           
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            User user = new User();
            user.RegisterAccount();

            Console.ReadKey();
        }
    }
}

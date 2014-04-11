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


            using (StreamWriter writer = new StreamWriter(name+".txt"))
            {
                writer.Write(name);
                writer.Write(string.Format(" "+password+"\n"));
            }
           

        }
        public User()
        {
           
        }

    }
    class Program
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
            
            Console.ReadKey();
        }
    }
}

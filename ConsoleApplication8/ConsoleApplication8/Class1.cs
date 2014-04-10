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
        public void RegisterAccount()
        {
            //Text from textfield are added to the object variables    
            //Account stored in a file
           
            try
            {
                if (((this.name).Trim()).Length < 3
                   || ((this.name).Trim()).Length > 20
                   )
                {
                    throw new ArgumentOutOfRangeException();
                }
            }


            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
            }

            

        }
        public User(string name)
        {
            this.name = name;
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            User user = new User("Ls");
            user.RegisterAccount();

            Console.ReadKey();
        }
    }
}

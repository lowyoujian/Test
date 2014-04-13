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


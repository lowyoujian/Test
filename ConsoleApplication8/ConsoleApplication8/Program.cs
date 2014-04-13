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
            bool loginConfirmation;
            loginConfirmation=Option.UserLogin();            
            if (loginConfirmation)
            {
                Option.DisplayRoom();               
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


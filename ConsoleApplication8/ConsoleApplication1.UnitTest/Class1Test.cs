using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using FirstApplication;

namespace FirstApplicationTest
{
    

    class Class1Test
    {

        
        private User user;

        [SetUp]
        public void Setup()
        {
            user = new User("as");
        }

        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestRegisterAccount(string name)
        {
            user.RegisterAccount();

        }
    }
}



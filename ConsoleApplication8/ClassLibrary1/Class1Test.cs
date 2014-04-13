﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using FirstApplication;
using System.IO;
using Moq;
	
namespace ConsoleApplication8Test
{


    class Class1Test
    {
        private User user;

        [SetUp]
        public void Setup()
        {
            user = new User();
        }

        [Test]
        [TestCase("123", "1234567", true)]
        [TestCase("12", "1234567", false)]
        [TestCase("12", "123456", false)]
        [TestCase("123", "123456", false)]
        [TestCase("123456789012345678901", "123456", false)]
        [TestCase("123456789012345678901", "1234567", false)]
        public void TestRegisterAccount(string name, string password, bool boolvalue)
        {
            user.Name = name;
            user.Password = password;
            Assert.AreEqual(user.ValidateInput(), boolvalue);

        }
        [Test]
        public void TestRegisterAccount()
        {
            var filesystem = new Moq.Mock<IFile>();
            var obj = new User(filesystem);
            filesystem.Expect(fs => fs.Exists("Users.txt")).Returns(true);
            
        }
    }
}

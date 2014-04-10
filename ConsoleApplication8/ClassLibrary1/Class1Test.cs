﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
    using FirstApplication;
	
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
	//test
	    [Test]
        [TestCase("123","1234567",true)]
        [TestCase("", "aaaaaa", false)]
        [TestCase("12", "123456", false)]
        [TestCase("1234", "123456", false)]
        [TestCase("12345", "13245678", true)]
        [TestCase("132456789013245678911", "aaaaaaaaaaa", false)]
	    public void TestRegisterAccount(string name, string password, bool boolvalue)
	    {
            user.Name=name;
            user.Password=password;
            Assert.AreEqual(user.RegisterAccount(), boolvalue);
	
	    }
	}
}

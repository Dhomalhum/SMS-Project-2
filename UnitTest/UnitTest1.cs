using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SMS.Services;
using System.Collections.Generic;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            RestService.SendSMS(new List<string> { "0451762142" }, "test");
        }

        [TestMethod]
        public void TestEmail()
        {
            RestService.SendEmail("SMS notification", "lrb226677@gmail.com", "test message");
        }
    }
}

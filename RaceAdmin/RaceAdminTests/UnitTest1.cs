using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RaceAdmin;
using Moq;

namespace RaceAdminTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var mock = new Mock<ISdkWrapper>();

            RaceAdminMain ram = new RaceAdminMain(mock.Object);
        }
    }
}

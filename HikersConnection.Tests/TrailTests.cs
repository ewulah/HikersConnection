using HikersConnection.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HikersConnection.Tests
{
    [TestFixture]
    public class TrailTests
    {
        //declaring system under test
        Trail sut;

        [OneTimeSetUp]
        public void BeforeTestClass()
        {
            //Console.WriteLine("*** Before test class ", TestContext.CurrentContext.WorkDirectory);
            Console.WriteLine("*** Setup before test class*** ");
        }
        [SetUp]
        public void BeforeEachTest()
        {
            Console.WriteLine("Before {0}", TestContext.CurrentContext.Test.Name);

            //initializing sut
            sut = new Trail();
        }

        [Test]
        public void Test1()
        {
            return;
        }

        [TearDown]
        public void AfterEachTest()
        {
            Console.WriteLine("After {0}", TestContext.CurrentContext.Test.Name);

            sut = null;
        }

        [OneTimeTearDown]
        public void AfterTestClass()
        {
            //Console.WriteLine("*** Cleanup test class ", TestContext.CurrentContext.WorkDirectory);
            Console.WriteLine("*** Cleanup test class*** ");
        }
    }
}

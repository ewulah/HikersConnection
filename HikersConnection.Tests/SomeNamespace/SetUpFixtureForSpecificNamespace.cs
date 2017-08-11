using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HikersConnection.Models;
using NUnit.Framework;

//code to execute before all the tests in SomeNamespace
namespace HikersConnection.Tests.SomeNamespace
{
    [SetUpFixture]
    public class SetUpFixtureForSpecificNamespace
    {
        [SetUp]
        public void RunBeforeAnyTestInSomeNamespace()
        {
            Console.WriteLine("#### Run Before ANY Test In SomeNamespace ###");
        }

        [TearDown]
        public void RunAfterAllTestInSomeNamespace()
        {
            Console.WriteLine("#### Run After ALL Test In SomeNamespace ###");
        }
    }
}

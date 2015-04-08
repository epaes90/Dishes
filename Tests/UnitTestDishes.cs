using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Dishes.Classes;

namespace Tests
{
    [TestClass]
    public class UnitTestDishes
    {
        [TestMethod]
        public void TestCaseMorning_Basic()
        {
            string[] dishes = new string [] {"1","2", "3"};
            morning m = new morning();
            string result = m.getDishes(dishes);
            Assert.AreEqual(result, "eggs, toast, coffee");
        }

        [TestMethod]
        public void TestCaseMorning_Order()
        {
            string[] dishes = new string[] { "2", "1", "3" };
            morning m = new morning();
            string result = m.getDishes(dishes);
            Assert.AreEqual(result, "eggs, toast, coffee");
        }

        [TestMethod]
        public void TestCaseMorning_outOfBonds()
        {
            string[] dishes = new string[] { "1", "2", "3", "4" };
            morning m = new morning();
            string result = m.getDishes(dishes);
            Assert.AreEqual(result, "eggs, toast, coffee, error");
        }
        [TestMethod]
        public void TestCaseMorning_repeat()
        {
            string[] dishes = new string[] { "1", "2", "3", "3", "3" };
            morning m = new morning();
            string result = m.getDishes(dishes);
            Assert.AreEqual(result, "eggs, toast, coffee(x3)");
        }

        [TestMethod]
        public void TestCaseNight_basic()
        {
            string[] dishes = new string[] { "1", "2", "3", "4", };
            night m = new night();
            string result = m.getDishes(dishes);
            Assert.AreEqual(result, "steak, potato, wine, cake");
        }

        [TestMethod]
        public void TestCaseNight_repeat()
        {
            string[] dishes = new string[] { "1", "2", "2", "4", };
            night m = new night();
            string result = m.getDishes(dishes);
            Assert.AreEqual(result, "steak, potato(x2), cake");
        }

        [TestMethod]
        public void TestCaseNight_outOfBonds()
        {
            string[] dishes = new string[] { "1", "2", "3", "5", };
            night m = new night();
            string result = m.getDishes(dishes);
            Assert.AreEqual(result, "steak, potato, wine, error");
        }

        [TestMethod]
        public void TestCaseNight_wrongRepeat()
        {
            string[] dishes = new string[] { "1", "1", "2", "3", "5", };
            night m = new night();
            string result = m.getDishes(dishes);
            Assert.AreEqual(result, "steak, error");
        }
    }
}

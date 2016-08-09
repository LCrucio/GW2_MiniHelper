using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TimerLogic;

namespace GW2Helper.TimerLogicTests
{
    [TestClass()]
    public class TimeDbTests
    {
        [TestMethod()]
        public void GetTimeUntilTest()
        {
            TimeDb newDb = new TimeDb();
            TimeSpan timeSpanToTest = newDb.GetTimeUntil(Gw2Events.Tarir);

            Assert.IsTrue(timeSpanToTest.TotalMilliseconds< 7200000&& timeSpanToTest.TotalMilliseconds>=-2700000);
        }
    }
}
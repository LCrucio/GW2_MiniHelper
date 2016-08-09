using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TimerLogic;

namespace GW2Helper.TimerLogicTests
{
    [TestClass()]
    public class TimeToLocalTests
    {
        [TestMethod()]
        public void ConvertToLocalTest()
        {
           /// This time WILL fail in Different Timezones
           /// ConvertToLocalTest isn't used right now so the test can be skipped entirely

            TimeToLocal timeConv = new TimeToLocal();
            Assert.AreEqual(timeConv.ConvertToLocal(new TimeSpan(0, 0, 0)),new TimeSpan(2,0,0));
            Assert.AreNotEqual(timeConv.ConvertToLocal(new TimeSpan(0, 0, 0)), new TimeSpan(1, 0, 0));
        }
    }
}
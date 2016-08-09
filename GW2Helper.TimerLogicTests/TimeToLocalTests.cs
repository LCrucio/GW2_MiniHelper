using Microsoft.VisualStudio.TestTools.UnitTesting;
using TimerLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimerLogic.Tests
{
    [TestClass()]
    public class TimeToLocalTests
    {
        [TestMethod()]
        public void ConvertToLocalTest()
        {
            TimeToLocal timeConv = new TimeToLocal();
            Assert.AreEqual(timeConv.ConvertToLocal(new TimeSpan(0, 0, 0)),new TimeSpan(2,0,0));
            Assert.AreNotEqual(timeConv.ConvertToLocal(new TimeSpan(0, 0, 0)), new TimeSpan(1, 0, 0));
        }
    }
}
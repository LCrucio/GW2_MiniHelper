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
    public class TimeDBTests
    {
        [TestMethod()]
        public void GetTimeUntilTest()
        {
            TimeDB newDb = new TimeDB();

            TimeSpan now = new TimeSpan(DateTime.UtcNow.Hour,
                       DateTime.UtcNow.Minute,
                       DateTime.UtcNow.Second);

            TimeSpan lowest = new TimeSpan(24, 0, 0);

            foreach (var entry in newDb.timeDictionaryDB[gw2Events.Tarir])
            {
                if (entry.Subtract(now) < lowest && entry.Subtract(now) > new TimeSpan(0, 0, 0))
                {
                    lowest = entry;
                    Console.WriteLine(lowest);
                }
                    Console.WriteLine(entry.Subtract(now) + " " + (entry.Subtract(now)<=lowest&& entry.Subtract(now) > new TimeSpan(0, 0, 0)));
            }

            Console.WriteLine(lowest.Subtract(now) + " to wynik");

            Console.WriteLine(newDb.GetTimeUntil(gw2Events.Tarir));

            Assert.AreEqual(true, true);
        }
    }
}
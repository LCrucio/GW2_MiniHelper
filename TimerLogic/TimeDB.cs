using System;
using System.Collections.Generic;

namespace TimerLogic
{
    public class TimeDb
    {
        private TimeToLocal _timeConverter;
        public Dictionary<Gw2Events, List<TimeSpan>> TimeDictionaryDb;

        public TimeDb()
        {
            TimeDictionaryDb = new Dictionary<Gw2Events, List<TimeSpan>>();
            _timeConverter = new TimeToLocal();
            PopulateDb(TimeDictionaryDb);
        }


        private void PopulateDb(Dictionary<Gw2Events, List<TimeSpan>> dict)
        {
            SetEvent(dict, Gw2Events.Tarir);
            SetEvent(dict, Gw2Events.Tequatl);
        }



        public TimeSpan GetTimeUntil(Gw2Events type)
        {
            var now = new TimeSpan(DateTime.UtcNow.Hour,
                DateTime.UtcNow.Minute,
                DateTime.UtcNow.Second);
            var lowest = now.Add(new TimeSpan(9, 0, 0));

            foreach (var entry in TimeDictionaryDb[type])
            {
                if ((entry.Subtract(now).TotalMilliseconds < Math.Abs(lowest.Subtract(now).TotalMilliseconds))
                    &&
                    (entry.Subtract(now) >= new TimeSpan(0, 0, 0) ||
                     Math.Abs(entry.Subtract(now).TotalMilliseconds) <= GetDuration(type).TotalMilliseconds))
                {
                    if(type==Gw2Events.Tequatl)Console.WriteLine("Teraz:" + now);
                    if (type == Gw2Events.Tequatl) Console.WriteLine(entry);
                    lowest = entry;
                }
            }
            return lowest.Subtract(now);
        }


        public TimeSpan GetDuration(Gw2Events type)
        {
            switch (type)
            {
                case Gw2Events.Tarir:
                    return new TimeSpan(0, 45, 0);
                case Gw2Events.Tequatl:
                    return new TimeSpan(0, 15, 0);
            }

            return new TimeSpan(0, 0, 0);
        }

        private static void TarirAdd(Dictionary<Gw2Events, List<TimeSpan>> dict, Gw2Events type, List<TimeSpan> list)
        {
            for (var i = 0; i < 13; i++)
            {
                var temp = new TimeSpan(2 * i, 45, 0);
                list.Add(temp);
            }
            dict.Add(type, list);
        }

        private static void TequatlAdd(Dictionary<Gw2Events, List<TimeSpan>> dict, Gw2Events type, List<TimeSpan> list)
        {
            var spawn1 = new TimeSpan(24, 0, 0);
            list.Add(spawn1);
            var spawn2 = new TimeSpan(3, 0, 0);
            list.Add(spawn2);
            var spawn3 = new TimeSpan(7, 0, 0);
            list.Add(spawn3);
            var spawn4 = new TimeSpan(11, 30, 0);
            list.Add(spawn4);
            var spawn5 = new TimeSpan(16, 0, 0);
            list.Add(spawn5);
            var spawn6 = new TimeSpan(19, 0, 0);
            list.Add(spawn6);
            var spawn7 = new TimeSpan(0, 0, 0);
            list.Add(spawn7);
            dict.Add(type, list);
        }

        private void SetEvent(Dictionary<Gw2Events, List<TimeSpan>> dict, Gw2Events type)
        {
            var list = new List<TimeSpan>();

            switch (type)
            {
                case Gw2Events.Tarir:
                    TarirAdd(dict, type, list);
                    break;

                case Gw2Events.Tequatl:
                    TequatlAdd(dict, type, list);
                    break;

                default:
                    throw new ArgumentException();
                    break;
            }
        }
    }
}
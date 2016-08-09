using System;
using System.Collections.Generic;

namespace TimerLogic
{
    public enum Gw2Events
    {
        Tarir,
        Tequatl
    }

    public class ApiNode
    {
        private readonly TimeDb _eventTimeDb;

        public ApiNode(TimeDb vtimeDb)
        {
            _eventTimeDb = vtimeDb;
        }

        public TimeSpan TimeToStart(Gw2Events eventType)
        {
            return _eventTimeDb.GetTimeUntil(eventType);
        }
    }
}
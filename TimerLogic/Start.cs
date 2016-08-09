using System;

namespace TimerLogic
{
    public class Start
    {
        public ApiNode Api;
        private readonly TimeDb _timerDb;

        public Start()
        {
            _timerDb = new TimeDb();
            Api = new ApiNode(_timerDb);
        }

        public TimeSpan ExposeApi(Gw2Events type)
        {
            return Api.TimeToStart(type);
        }
    }
}
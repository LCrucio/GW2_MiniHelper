using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace TimerLogic
{
    public enum gw2Events
    {
        Tarir,
        Tequatl
    };

    public class API_Node
    {
        private TimeDB eventTimeDb;
        private Dictionary<gw2Events, bool> activeState;
        private Dictionary<gw2Events, TimeSpan> activeTime; 

        public API_Node(TimeDB vtimeDb)
        {
            activeState=new Dictionary<gw2Events, bool>();
            activeTime = new Dictionary<gw2Events, TimeSpan>();
            eventTimeDb = vtimeDb;
        }

        public TimeSpan TimeToStart(gw2Events eventType)
        {
            //if (!activeState.ContainsKey(eventType))
            //{
            //    activeState.Add(eventType,false);
            //}

            TimeSpan timeToStart = eventTimeDb.GetTimeUntil(eventType);
            //TimeSpan active;



            //if (CheckIfActive(timeToStart, eventType, out active))
            //{
            //    activeState[eventType] = true;
            //    return active;
            //}

            //if (activeState[eventType] && CheckIfActive(activeTime[eventType], eventType))
            //{
            //    activeState[eventType] = false;
            //    return timeToStart;
            //}

            //if (activeState[eventType])
            //{
            //    activeTime[eventType].Subtract();
            //    return activeTime[eventType];
            //}
            return timeToStart;

        }
        
        //private TimeSpan Duration(gw2Events eventType)
        //{
        //    return eventTimeDb.GetDuration(eventType);
        //}

        //private bool CheckIfActive(TimeSpan time, gw2Events eventType, out TimeSpan active)
        //{
        //    active = new TimeSpan(0,0,0);
        //    if (time.Equals(new TimeSpan(0, 0, 0)))
        //    {
        //        active=Duration(eventType);
        //        return true;

        //    }
        //    return false;
        //}

        //private bool CheckIfActive(TimeSpan time, gw2Events eventType)
        //{
        //    if (time.Equals(new TimeSpan(0, 0, 0)))
        //    {
        //        return true;
        //    }
        //    return false;
        //}


        //public void SpecialEvent(gw2Events eventType)
        //{
            
        //}


    }
}

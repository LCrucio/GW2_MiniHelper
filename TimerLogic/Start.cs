using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimerLogic
{
    public class Start
    {
        public API_Node API;
        private TimeDB timerDB;

        public Start()
        {
            timerDB = new TimeDB();
            API = new API_Node(timerDB);
        }

        public String ExposeApi(gw2Events type)
        {
            return API.TimeToStart(type).ToString();
        }
    }
}

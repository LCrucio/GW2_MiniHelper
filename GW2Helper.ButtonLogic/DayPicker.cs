using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GW2Helper.ButtonLogic
{
    public class DayPicker
    {
        PactSupply supplyDB;

        public DayPicker()
        {
            supplyDB=new PactSupply();
        }

        public String PickPasteForDay()
        {
            return supplyDB.GetPaste(ReturnToday());
        }

        public int ReturnToday()
        {
            int today = (int)DateTime.UtcNow.DayOfWeek;
            if (DateTime.UtcNow.Hour <= 8) today--;
            if (today == -1) today = 6;

            return today;
        }
    }
}

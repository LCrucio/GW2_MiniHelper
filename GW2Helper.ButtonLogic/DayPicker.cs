using System;

namespace GW2Helper.ButtonLogic
{
    public class DayPicker
    {
        private readonly PactSupply _supplyDb;

        public DayPicker()
        {
            _supplyDb = new PactSupply();
        }

        public string PickPasteForDay()
        {
            return _supplyDb.GetPaste(ReturnToday());
        }

        public int ReturnToday()
        {
            var today = (int) DateTime.UtcNow.DayOfWeek;
            if (DateTime.UtcNow.Hour <= 8) today--;
            if (today == -1) today = 6;

            return today;
        }
    }
}
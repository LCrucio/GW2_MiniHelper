using System;

namespace GW2Helper.ButtonLogic
{
    public class PactSupply

    {
        private readonly string[] _weekPaste = new string[7];

        public PactSupply()
        {
            SetPastes();
        }

        public string GetPaste(int day)
        {
            if (day < 7 && day >= 0)
                return _weekPaste[day];
            throw new ArgumentException();
        }

        public void SetPastes()
        {
            _weekPaste[0] = "[&BIsHAAA=], [&BDoBAAA=], [&BC0AAAA=], [&BP8DAAA=], [&BIUCAAA=], [&BCECAAA=]";
            _weekPaste[1] = "[&BIcHAAA=], [&BEwDAAA=], [&BKYBAAA=], [&BNIEAAA=], [&BIMCAAA=], [&BA8CAAA=]";
            _weekPaste[2] = "[&BH8HAAA=], [&BEgAAAA=], [&BBkAAAA=], [&BKgCAAA=], [&BGQCAAA=], [&BIMBAAA=]";
            _weekPaste[3] = "[&BH4HAAA=], [&BMIBAAA=], [&BKEAAAA=], [&BP0CAAA=], [&BDgDAAA=], [&BPEBAAA=]";
            _weekPaste[4] = "[&BKsHAAA=], [&BF0AAAA=], [&BIMAAAA=], [&BO4CAAA=], [&BF0GAAA=], [&BOQBAAA=]";
            _weekPaste[5] = "[&BJQHAAA=], [&BMMCAAA=], [&BNUGAAA=], [&BJsCAAA=], [&BHsBAAA=], [&BNMAAAA=]";
            _weekPaste[6] = "[&BH8HAAA=], [&BNMCAAA=], [&BJIBAAA=], [&BBEDAAA=], [&BEICAAA=], [&BBABAAA=]";
        }
    }
}
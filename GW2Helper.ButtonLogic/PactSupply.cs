using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GW2Helper.ButtonLogic
{
    public class PactSupply

    {
        String[] weekPaste = new string[7];

        public PactSupply()
        {
            SetPastes();
        }

        public String GetPaste(int day)
        {
            if (day < 7 && day >= 0)
                return weekPaste[day];
            throw new ArgumentException();
        }

        public void SetPastes()
        {
            weekPaste[0] = "[&BIsHAAA=], [&BDoBAAA=], [&BC0AAAA=], [&BP8DAAA=], [&BIUCAAA=], [&BCECAAA=]";
            weekPaste[1] = "[&BIcHAAA=], [&BEwDAAA=], [&BKYBAAA=], [&BNIEAAA=], [&BIMCAAA=], [&BA8CAAA=]";
            weekPaste[2] = "[&BH8HAAA=], [&BEgAAAA=], [&BBkAAAA=], [&BKgCAAA=], [&BGQCAAA=], [&BIMBAAA=]";
            weekPaste[3] = "[&BH4HAAA=], [&BMIBAAA=], [&BKEAAAA=], [&BP0CAAA=], [&BDgDAAA=], [&BPEBAAA=]";
            weekPaste[4] = "[&BKsHAAA=], [&BF0AAAA=], [&BIMAAAA=], [&BO4CAAA=], [&BF0GAAA=], [&BOQBAAA=]";
            weekPaste[5] = "[&BJQHAAA=], [&BMMCAAA=], [&BNUGAAA=], [&BJsCAAA=], [&BHsBAAA=], [&BNMAAAA=]";
            weekPaste[6] = "[&BH8HAAA=], [&BNMCAAA=], [&BJIBAAA=], [&BBEDAAA=], [&BEICAAA=], [&BBABAAA=]";
        }
    }
}

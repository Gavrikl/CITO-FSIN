using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CITO_FSIN.Models.HolidaysModel
{
    class Holidays
    {
        int id;
        double idstaff;
        DateTime datef;
        DateTime datet;

        public int Id { get => id; set => id = value; }
        public double Idstaff { get => idstaff; set => idstaff = value; }
        public DateTime Datef { get => datef; set => datef = value; }
        public DateTime Datet { get => datet; set => datet = value; }

        public override string ToString()
        {
            string temp = $"{Id},{Idstaff},{Datef.ToString(GetDateFormat())},{Datet.ToString(GetDateFormat())}";
            return temp;
        }

        public string GetDateFormat() { return "MM/dd/yyyy"; }
    }
}

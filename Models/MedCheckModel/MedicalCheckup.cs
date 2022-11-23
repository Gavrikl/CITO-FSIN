using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CITO_FSIN.Models.MedCheckModel
{
    class MedicalCheckup
    {
        int id;
        int idprisoner;
        int idemployee;
        string prs;
        string prvmedexm;

        public int Id { get => id; set => id = value; }
        public int Idprisoner { get => idprisoner; set => idprisoner = value; }
        public int Idemployee { get => idemployee; set => idemployee = value; }
        public string Prs { get => prs; set => prs = value; }
        public string Prvmedexm { get => prvmedexm; set => prvmedexm = value; }

        public override string ToString()
        {
            string temp = $"{Id}, {Idprisoner}, {Idemployee}, {Prs}, {Prvmedexm}";
            return temp;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;

namespace CITO_FSIN.Models.PrisonersModel
{
    public class Prisoners
    {
        int id;
        string surname;
        string name;
        string midname;
        string article;
        Image photo;
        public string photoPath = "";
        public int Id { get => id; set => id = value; }
        public string Surname { get => surname; set => surname = value; }
        public string Name { get => name; set => name = value; }
        public string Midname { get => midname; set => midname = value; }
        public string Article { get => article; set => article = value; }
        public Image Photo { get => photo; set => photo = value; }


        
        public override string ToString()
        {
            string temp = $"{id}, {surname}, {name}, {midname}, {article}";
            return temp;
        }








        



    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CITO_FSIN.Models.StaffModel
{
    class Staff
    {
        int id;
        string surname;
        string name;
        string midname;
        string department;
        string position;

        public int Id { get => id; set => id = value; }
        public string Surname { get => surname; set => surname = value; }
        public string Name { get => name; set => name = value; }
        public string Midname { get => midname; set => midname = value; }
        public string Department { get => department; set => department = value; }
        public string Position { get => position; set => position = value; }

        public override string ToString()
        {
            string temp = $"{id}, {surname}, {name}, {midname}, {department}, {position}";
            return temp;
        }
    }
}

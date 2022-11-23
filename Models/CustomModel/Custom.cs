using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CITO_FSIN.Models.CustomModel
{
    class Custom
    {
        int id;
        string department;
        string product;
        int quantity;
        DateTime date;

        public int Id { get => id; set => id = value; }
        public string Department { get => department; set => department = value; }
        public string Product { get => product; set => product = value; }
        public int Quantity { get => quantity; set => quantity = value; }
        public DateTime Date { get => date; set => date = value; }

        public override string ToString()
        {
            string temp = $"{Id}, {Department}, {Product}, {Quantity}, {Date.ToString("MM/dd/yyyy")}";
            return temp;
        }

        public string GetDateFormat() { return "MM/dd/yyyy"; }
        
    }
}

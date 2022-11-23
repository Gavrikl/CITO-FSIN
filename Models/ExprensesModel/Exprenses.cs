using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CITO_FSIN.Models.ExprensesModel
{
    class Exprenses
    {
        int id;
        double price;
        DateTime date;

        public int Id { get => id; set => id = value; }
        public double Price { get => price; set => price = value; }
        public DateTime Date { get => date; set => date = value; }

        public override string ToString()
        {
            string temp = $"ID: {Id}, Деньги: {Price} рублей, Дата: {Date.ToString(GetDateFormat())}";
            return temp;
        }

        public string GetDateFormat() { return "MM/dd/yyyy"; }
    }
}

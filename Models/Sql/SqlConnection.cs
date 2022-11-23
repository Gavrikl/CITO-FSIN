using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CITO_FSIN.Models.Sql
{
    internal class SqlConnection
    {
        const string SqlConnectionString1 = @"Data Source=LAPTOP-SU7H6358\SQLEXPRESS;Initial Catalog=WFTUTORIAL;Integrated Security=True"; 

        public static string SqlConnectionString => SqlConnectionString1;
    }
}

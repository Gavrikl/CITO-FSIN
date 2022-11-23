using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;


namespace CITO_FSIN.Models.ExprensesModel
{
    class ExprensesController : Exprenses
    {
        public List<Exprenses> GetStaff()
        {
            List<Exprenses> staffs = new List<Exprenses>();
            SqlConnection connection = new SqlConnection(Sql.SqlConnection.SqlConnectionString);
            string command = "SELECT * FROM Expenses";
            try
            {
                SqlCommand cmd = new SqlCommand(command, connection);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Exprenses staff = new Exprenses();
                    staff.Id = (int)reader[0];
                    staff.Price = Convert.ToDouble(reader[1]);
                    staff.Date = Convert.ToDateTime(reader[2]);
                    staffs.Add(staff);
                }
                reader.Close();
            }
            catch (SqlException er)
            {
                Console.WriteLine(er.Message);
            }
            finally
            {

                connection.Close();
            }

            return staffs;
        }

        public bool CreateStaff(Exprenses staff)//Добавляет
        {
            SqlConnection connection = new SqlConnection(Sql.SqlConnection.SqlConnectionString); // Строка подключения
            try
            {


                string command = $"INSERT INTO Expenses(Money, Date) VALUES({staff.Price},'{staff.Date}')";


                SqlCommand cmd = new SqlCommand(command, connection);

                connection.Open();
                cmd.ExecuteNonQuery();
            }
            catch (SqlException er)
            {
                Console.WriteLine(er.Message);
            }
            finally
            {
                connection.Close();
            }


            return true; //Возращает true если успешно
        }


        public bool DeleteStaff(Exprenses staff)//Удаляет по Id
        {
            SqlConnection connection = new SqlConnection(Sql.SqlConnection.SqlConnectionString); // Строка подключения
            try
            {
                string command = $"DELETE FROM Expenses WHERE Id = {staff.Id}";
                SqlCommand cmd = new SqlCommand(command, connection);
                connection.Open();
                cmd.ExecuteNonQuery();
            }
            catch (SqlException er)
            {
                Console.WriteLine(er.Message);
            }
            finally
            {
                connection.Close();
            }
            return true; //Возращает true если успешно
        }

        public bool ChangeStaff(Exprenses staff)
        {
            SqlConnection connection = new SqlConnection(Sql.SqlConnection.SqlConnectionString); // Строка подключения
            try
            {
                string command =
                    $"UPDATE Expenses SET " +
                    $"Money = '{staff.Price}', " +
                    $"Date = '{staff.Date}'" +
                    $"WHERE Id = {staff.Id}";

                SqlCommand cmd = new SqlCommand(command, connection);

                connection.Open();
                cmd.ExecuteNonQuery();
            }
            catch (SqlException er)
            {
                Console.WriteLine(er.Message);
            }
            finally
            {
                connection.Close();
            }
            return true; //Возращает true если успешно
        }


        public List<string[]> LoadData()
        {
            string connectString = Sql.SqlConnection.SqlConnectionString;
            SqlConnection myConnection = new SqlConnection(connectString);
            List<string[]> data = new List<string[]>();

            try
            {


                myConnection.Open();

                string query = "SELECT * FROM Expenses";

                SqlCommand command = new SqlCommand(query, myConnection);

                SqlDataReader reader = command.ExecuteReader();



                while (reader.Read())
                {
                    data.Add(new string[4]);

                    data[data.Count - 1][0] = reader[0].ToString();
                    data[data.Count - 1][1] = reader[1].ToString();
                    data[data.Count - 1][2] = reader[2].ToString();
                 
                }

                reader.Close();
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                myConnection.Close();
            }

            return data;
        }
    }
}

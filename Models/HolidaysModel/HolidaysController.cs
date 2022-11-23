using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;

namespace CITO_FSIN.Models.HolidaysModel
{
    class HolidaysController : Holidays
    {
        public List<Holidays> GetStaff()
        {
            List<Holidays> staffs = new List<Holidays>();
            SqlConnection connection = new SqlConnection(Sql.SqlConnection.SqlConnectionString);
            string command = "SELECT * FROM StaffHolidays";
            try
            {
                SqlCommand cmd = new SqlCommand(command, connection);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Holidays staff = new Holidays();
                    staff.Id = (int)reader[0];
                    staff.Idstaff = Convert.ToDouble(reader[1]);
                    staff.Datef = Convert.ToDateTime(reader[2]);
                    staff.Datet = Convert.ToDateTime(reader[2]);
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

        public bool CreateStaff(Holidays staff)//Добавляет
        {
            SqlConnection connection = new SqlConnection(Sql.SqlConnection.SqlConnectionString); // Строка подключения
            try
            {


                string command = $"INSERT INTO StaffHolidays(IdStaff, DateFrom, DateTo) VALUES({staff.Idstaff},'{staff.Datef}','{staff.Datet}')";


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


        public bool DeleteStaff(Holidays staff)//Удаляет по Id
        {
            SqlConnection connection = new SqlConnection(Sql.SqlConnection.SqlConnectionString); // Строка подключения
            try
            {
                string command = $"DELETE FROM StaffHolidays WHERE Id = {staff.Id}";
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

        public bool ChangeStaff(Holidays staff)
        {
            SqlConnection connection = new SqlConnection(Sql.SqlConnection.SqlConnectionString); // Строка подключения
            try
            {
                string command =
                    $"UPDATE StaffHolidays SET " +
                    $"IdStaff = '{staff.Idstaff}', " +
                    $"DateFrom = '{staff.Datef}'," +
                    $"DateTo = '{staff.Datet}'" +
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

                string query = "SELECT * FROM StaffHolidays";

                SqlCommand command = new SqlCommand(query, myConnection);

                SqlDataReader reader = command.ExecuteReader();



                while (reader.Read())
                {
                    data.Add(new string[5]);

                    data[data.Count - 1][0] = reader[0].ToString();
                    data[data.Count - 1][1] = reader[1].ToString();
                    data[data.Count - 1][2] = reader[2].ToString();
                    data[data.Count - 1][3] = reader[3].ToString();
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

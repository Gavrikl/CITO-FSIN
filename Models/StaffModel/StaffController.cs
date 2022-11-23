using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;

namespace CITO_FSIN.Models.StaffModel
{
    class StaffController : Staff
    {
        public List<Staff> GetStaff()
        {
            List<Staff> staffs = new List<Staff>();
            SqlConnection connection = new SqlConnection(Sql.SqlConnection.SqlConnectionString);
            string command = "SELECT * FROM Staff_headquarters";
            try
            {
                SqlCommand cmd = new SqlCommand(command, connection);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Staff staff = new Staff();
                    staff.Id = (int)reader[0];
                    staff.Name = reader[1].ToString();
                    staff.Surname = reader[2].ToString();
                    staff.Midname = reader[3].ToString();
                    staff.Department = reader[4].ToString();
                    staff.Position = reader[5].ToString();

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

        public bool CreateStaff(Staff staff)//Добавляет
        {
            SqlConnection connection = new SqlConnection(Sql.SqlConnection.SqlConnectionString); // Строка подключения
            try
            {


                string command = $"INSERT INTO Staff_headquarters(Surname, Name, Middlename, Department2, Position) VALUES('{staff.Surname}','{staff.Name}','{staff.Midname}','{staff.Department}', '{staff.Position}')";


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


        public bool DeleteStaff(Staff staff)//Удаляет заключенного по Id
        {
            SqlConnection connection = new SqlConnection(Sql.SqlConnection.SqlConnectionString); // Строка подключения
            try
            {
                string command = $"DELETE FROM Staff_headquarters WHERE Id = {staff.Id}";
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

        public bool ChangeStaff(Staff staff)
        {
            SqlConnection connection = new SqlConnection(Sql.SqlConnection.SqlConnectionString); // Строка подключения
            try
            {
                string command =
                    $"UPDATE Staff_headquarters SET " +
                    $"Surname = '{staff.Surname}', " +
                    $"Name = '{staff.Name}', " +
                    $"Middlename = '{staff.Midname}'," +
                    $"Department2 = '{staff.Department}', " +
                    $"Position = '{staff.Position}' " +
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

                string query = "SELECT * FROM Staff_headquarters";

                SqlCommand command = new SqlCommand(query, myConnection);

                SqlDataReader reader = command.ExecuteReader();



                while (reader.Read())
                {
                    data.Add(new string[6]);

                    data[data.Count - 1][0] = reader[0].ToString();
                    data[data.Count - 1][1] = reader[1].ToString();
                    data[data.Count - 1][2] = reader[2].ToString();
                    data[data.Count - 1][3] = reader[3].ToString();
                    data[data.Count - 1][4] = reader[4].ToString();
                    data[data.Count - 1][5] = reader[5].ToString();

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

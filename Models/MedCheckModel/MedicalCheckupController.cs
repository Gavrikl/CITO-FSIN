using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;

namespace CITO_FSIN.Models.MedCheckModel
{
    class MedicalCheckupController : MedicalCheckup
    {
        public List<MedicalCheckup> GetStaff()
        {
            List<MedicalCheckup> staffs = new List<MedicalCheckup>();
            SqlConnection connection = new SqlConnection(Sql.SqlConnection.SqlConnectionString);
            string command = "SELECT * FROM Medical_checkup";
            try
            {
                SqlCommand cmd = new SqlCommand(command, connection);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    MedicalCheckup staff = new MedicalCheckup();
                    staff.Id = (int)reader[0];
                    staff.Idprisoner = (int)reader[1];
                    staff.Idemployee = (int)reader[2];
                    staff.Prs = reader[3].ToString();
                    staff.Prvmedexm = reader[4].ToString();

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

        public bool CreateStaff(MedicalCheckup staff)//Добавляет
        {
            SqlConnection connection = new SqlConnection(Sql.SqlConnection.SqlConnectionString); // Строка подключения
            try
            {


                string command = $"INSERT INTO Medical_checkup(IdPrisoner, IdEmployee, Prs, Preventive_medical_examination) VALUES({staff.Idprisoner},{staff.Idemployee},'{staff.Prs}','{staff.Prvmedexm}')";


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


        public bool DeleteStaff(MedicalCheckup staff)//Удаляет заключенного по Id
        {
            SqlConnection connection = new SqlConnection(Sql.SqlConnection.SqlConnectionString); // Строка подключения
            try
            {
                string command = $"DELETE FROM Medical_checkup WHERE Id = {staff.Id}";
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

        public bool ChangeStaff(MedicalCheckup staff)
        {
            SqlConnection connection = new SqlConnection(Sql.SqlConnection.SqlConnectionString); // Строка подключения
            try
            {
                string command =
                    $"UPDATE Medical_checkup SET " +
                    $"IdPrisoner = '{staff.Idprisoner}', " +
                    $"IdEmployee = '{staff.Idemployee}', " +
                    $"Prs = '{staff.Prs}'," +
                    $"Preventive_medical_examination = '{staff.Prvmedexm}'" +
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

                string query = "SELECT * FROM Medical_checkup";

                SqlCommand command = new SqlCommand(query, myConnection);

                SqlDataReader reader = command.ExecuteReader();



                while (reader.Read())
                {
                    data.Add(new string[5]);

                    data[data.Count - 1][0] = reader[0].ToString();
                    data[data.Count - 1][1] = reader[1].ToString();
                    data[data.Count - 1][2] = reader[2].ToString();
                    data[data.Count - 1][3] = reader[3].ToString();
                    data[data.Count - 1][4] = reader[4].ToString();
                   

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


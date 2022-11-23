using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;

namespace CITO_FSIN.Models.PrisonersModel
{
    class PrisonersController : Models.PrisonersModel.Prisoners
    {

        public List<Prisoners> GetPrisoners()
        {
            List<Prisoners> prisoners = new List<Prisoners>();
            SqlConnection connection = new SqlConnection(Sql.SqlConnection.SqlConnectionString);
            string command = "SELECT * FROM Prisoners";
            try
            {
                SqlCommand cmd = new SqlCommand(command, connection);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Prisoners prisoner = new Prisoners();
                    prisoner.Id = (int)reader[0];
                    prisoner.Surname = reader[1].ToString();
                    prisoner.Name = reader[2].ToString();
                    prisoner.Midname = reader[3].ToString();
                    prisoner.Article = reader[4].ToString();

                    if (!DBNull.Value.Equals(reader[5]))
                    {
                        prisoner.Photo = toImage(reader[5] as byte[]);
                    }

                    prisoners.Add(prisoner);
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

            return prisoners;
        }
        public bool CreatePrisoner(Prisoners prisoner)//Добавляет
        {
            SqlConnection connection = new SqlConnection(Sql.SqlConnection.SqlConnectionString); // Строка подключения
            try
            {
                string command = "";
                if (prisoner.Photo != null)
                {
                    command = $"INSERT INTO Prisoners(Surname, Name, Middlename, Article, Photo) VALUES('{prisoner.Surname}','{prisoner.Name}','{prisoner.Midname}','{prisoner.Article}', @Image)";
                }
                else
                {
                    command = $"INSERT INTO Prisoners(Surname, Name, Middlename, Article) VALUES('{prisoner.Surname}','{prisoner.Name}','{prisoner.Midname}','{prisoner.Article}')";

                }

                SqlCommand cmd = new SqlCommand(command, connection);
                if (prisoner.Photo != null && prisoner.photoPath != "")
                {
                    byte[] image = toByteFromPath(prisoner.photoPath);
                    cmd.Parameters.AddWithValue("@Image", image);
                }
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


        public bool DeletePrisoner(Prisoners prisoner)//Удаляет заключенного по Id
        {
            SqlConnection connection = new SqlConnection(Sql.SqlConnection.SqlConnectionString); // Строка подключения
            try
            {
                string command = $"DELETE FROM Prisoners WHERE Id = {prisoner.Id}";
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

        public bool ChangePrisoner(Prisoners prisoner)
        {
            SqlConnection connection = new SqlConnection(Sql.SqlConnection.SqlConnectionString); // Строка подключения
            try
            {
                string command = "";
                if (prisoner.Photo != null)
                {
                    command =
                        $"UPDATE Prisoners SET " +
                        $"Surname = '{prisoner.Surname}', " +
                        $"Name = '{prisoner.Name}', " +
                        $"Middlename = '{prisoner.Midname}'," +
                        $"Article = '{prisoner.Article}', " +
                        $"Photo = @Image " +
                        $"WHERE Id = {prisoner.Id}";

                }
                else
                {
                    command =
                        $"UPDATE Prisoners SET " +
                        $"Surname = '{prisoner.Surname}', " +
                        $"Name = '{prisoner.Name}', " +
                        $"Middlename = '{prisoner.Midname}', " +
                        $"Article = '{prisoner.Article}' " +
                        $"WHERE Id = {prisoner.Id}";
                }
                SqlCommand cmd = new SqlCommand(command, connection);
                if (prisoner.Photo != null && prisoner.photoPath != "")
                {
                    byte[] image = toByteFromPath(prisoner.photoPath);
                    cmd.Parameters.AddWithValue("@Image", image);
                }
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

        public byte[] toByteFromPath(string path)
        {
            return File.ReadAllBytes(path);
        }
        public Image toImage(byte[] arrByte)
        {
            try
            {
                using (var ms = new MemoryStream(arrByte))
                {
                    return Image.FromStream(ms);
                }
            }
            catch
            {
                return null;
            }
        }



        public List<string[]> LoadData()
        {
            string connectString = Sql.SqlConnection.SqlConnectionString;
            SqlConnection myConnection = new SqlConnection(connectString);
            List<string[]> data = new List<string[]>();

            try
            {


                myConnection.Open();

                string query = "SELECT * FROM Prisoners";

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






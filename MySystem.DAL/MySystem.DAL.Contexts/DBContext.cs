using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MySystem.DAL.Entities;
using System.Data.SqlClient;
using System.Data.Common;
using System.Configuration;
using System.Drawing;
using System.IO;

namespace MySystem.DAL.Contexts
{
    public class DBContext
    {
        private SqlConnection con;
        private string connectionString;
        private List<User> users;
        private List<Account> accounts;
        private List<Notes> noteses;

        public DBContext()
        {
            this.connectionString = "Data Source=WIN-4ITBPNHRO6N\\SQLEXPRESS;Initial Catalog=UserDatabase;Integrated Security=True";
            //this.connectionString = ConfigurationManager.ConnectionStrings["UsersDBCon"].ConnectionString;
        }

        public List<User> Users
        {
            get { return this.users; }
            set { this.users = value; }
        }

        public List<Account> Accounts
        {
            get { return this.accounts; }
            set { this.accounts = value; }
        }

        public List<Notes> Noteses
        {
            get { return this.noteses; }
            set { this.noteses = value; }
        }

        public void GetUsersFromDatabase()
        {
            try
            {
                this.OpenConnection();
                SqlCommand sqlCom = new SqlCommand("SELECT * FROM Users", con);
                SqlDataReader dr = sqlCom.ExecuteReader();
                this.users = new List<User>();

                while (dr.Read())
                {
                    int id = int.Parse(dr[0].ToString());
                    string login = dr[1].ToString();
                    string password = dr[2].ToString();

                    this.Users.Add(new User { Id = id, Login = login, Password = password });
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("Current data are absent!", ex);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            finally
            {
                this.Dispose();
            }
        }

        public void GetAccountsFromDatabase()
        {
            try
            {
                this.OpenConnection();
                SqlCommand sqlCom = new SqlCommand("SELECT * FROM Accounts", con);
                SqlDataReader dr = sqlCom.ExecuteReader();
                this.accounts = new List<Account>();

                while (dr.Read())
                {
                    int id = int.Parse(dr[0].ToString());
                    string lastName = dr[1].ToString();
                    string firstName = dr[2].ToString();
                    string secondName = dr[3].ToString();
                    byte[] photo = dr[4] as byte[];
                    int idUser = int.Parse(dr[5].ToString());

                    this.Accounts.Add(new Account { Id = id, LastName = lastName, FirstName = firstName, SecondName = secondName, Photo = photo, IdUser = idUser });
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("Current data are absent!", ex);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            finally
            {
                this.Dispose();
            }
        }

        public void GetNotesFromDatabase()
        {
            try
            {
                this.OpenConnection();
                SqlCommand sqlCom = new SqlCommand("SELECT * FROM Notes", con);
                SqlDataReader dr = sqlCom.ExecuteReader();
                this.noteses = new List<Notes>();

                while (dr.Read())
                {
                    int id = int.Parse(dr[0].ToString());
                    string topic = dr[1].ToString();
                    string text = dr[2].ToString();
                    DateTime date = DateTime.Parse(dr[3].ToString());
                    byte[] image = dr[4] as byte[];
                    int idAccount = int.Parse(dr[5].ToString());

                    this.Noteses.Add(new Notes { Id = id, Topic = topic, Text = text, Date = date, Image = image, IdAccount = idAccount});
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("Current data are absent!", ex);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            finally
            {
                this.Dispose();
            }
        }

        public void InsertUser(User user)
        {
            try
            {
                this.OpenConnection();
                string comand = "Insert Into Users"
                    + "(login, password) Values('" + user.Login
                    + "','" + user.Password + "')";
                SqlCommand sqlCom = new SqlCommand(comand, con);
                sqlCom.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Cannot add the user!", ex);
            }
            finally
            {
                this.Dispose();
            }
        }

        public void InsertAccount(Account account)
        {
            try
            {
                this.OpenConnection();
                string comand = "Insert Into Accounts(lastname, firstname, secondname, image, idusers) Values(@lastName, @firstName, @secondName, @image, @idusers)";
                SqlCommand sqlCom = new SqlCommand(comand, con);
                sqlCom.Parameters.AddWithValue("@lastName", account.LastName);
                sqlCom.Parameters.AddWithValue("@firstName", account.FirstName);
                sqlCom.Parameters.AddWithValue("@secondName", account.SecondName);
                sqlCom.Parameters.AddWithValue("@image", account.Photo);
                sqlCom.Parameters.AddWithValue("@idusers", account.IdUser);
                sqlCom.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Cannot add the account!", ex);
            }
            finally
            {
                this.Dispose();
            }
        }

        public void InsertNotes(Notes notes)
        {
            try
            {
                this.OpenConnection();
                string comand = "Insert into Notes(topic, text, date, image, idaccounts) Values(@topic, @text, @date, @image, @idaccount)";
                SqlCommand sqlCom = new SqlCommand(comand, con);
                sqlCom.Parameters.AddWithValue("@topic", notes.Topic);
                sqlCom.Parameters.AddWithValue("@text", notes.Text);
                sqlCom.Parameters.AddWithValue("@date", notes.Date);
                sqlCom.Parameters.AddWithValue("@image", notes.Image);
                sqlCom.Parameters.AddWithValue("@idaccount", notes.IdAccount);
                sqlCom.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Cannot add the notes!", ex);
            }
            finally
            {
                this.Dispose();
            }
        }

        public void DropUser(User user)
        {
            try
            {
                this.OpenConnection();
                string comand = "delete from Users where id = '" + user.Id.ToString() + "'";
                SqlCommand sqlCom = new SqlCommand(comand, con);
                sqlCom.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Cannot delete the user!", ex);
            }
            finally
            {
                this.Dispose();
            }
        }

        public void DropAccount(Account account)
        {
            try
            {
                this.OpenConnection();
                string comand = "delete from Accounts where id = '" + account.Id.ToString() + "'";
                SqlCommand sqlCom = new SqlCommand(comand, con);
                sqlCom.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Cannot delete the account!", ex);
            }
            finally
            {
                this.Dispose();
            }
        }

        public void DropNotes(Notes notes)
        {
            try
            {
                this.OpenConnection();
                string comand = "delete from Notes where id = '" + notes.Id.ToString() + "'";
                SqlCommand sqlCom = new SqlCommand(comand, con);
                sqlCom.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Cannot delete the notes!", ex);
            }
            finally
            {
                this.Dispose();
            }
        }

        public void UpdateUser(User user)
        {
            try
            {
                this.OpenConnection();
                string comand = "Update Users Set login='" + user.Login
                        + "', password='" + user.Password
                        + "' Where Id='" + user.Id.ToString() + "'";
                SqlCommand sqlCom = new SqlCommand(comand, con);
                sqlCom.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Cannot update user data!", ex);
            }
            finally
            {
                this.Dispose();
            }
        }

        public void UpdateAccount(Account account)
        {
            try
            {
                this.OpenConnection();
                string comand = "Update Accounts Set lastname=@lastname, firstname=@firstname, secondname=@secondname, image=@image Where Id=@Id";
                SqlCommand sqlCom = new SqlCommand(comand, con);
                sqlCom.Parameters.AddWithValue("@Id", account.Id);
                sqlCom.Parameters.AddWithValue("@lastname", account.LastName);
                sqlCom.Parameters.AddWithValue("@firstname", account.FirstName);
                sqlCom.Parameters.AddWithValue("@secondname", account.SecondName);
                sqlCom.Parameters.AddWithValue("@image", account.Photo);
                sqlCom.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Cannot update account data!", ex);
            }
            finally
            {
                this.Dispose();
            }
        }

        public void UpdateNotes(Notes notes)
        {
            try
            {
                this.OpenConnection();
                string comand = "Update Notes Set topic=@topic, text=@text, date=@date, image=@image Where Id=@Id";
                SqlCommand sqlCom = new SqlCommand(comand, con);
                sqlCom.Parameters.AddWithValue("@id", notes.Id);
                sqlCom.Parameters.AddWithValue("@topic", notes.Topic);
                sqlCom.Parameters.AddWithValue("@text", notes.Text);
                sqlCom.Parameters.AddWithValue("@date", notes.Date);
                sqlCom.Parameters.AddWithValue("@image", notes.Image);
                sqlCom.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Cannot update notes data!", ex);
            }
            finally
            {
                this.Dispose();
            }
        }

        public void OpenConnection()
        {
            try
            {
                if (con == null)
                {
                    this.con = new SqlConnection(this.connectionString);
                    this.con.Open();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("There is wrong connection!", ex);
            }
        }

        public void Dispose()
        {
            if (con != null)
            {
                con.Close();
                con = null;
            }
        }
    }
}

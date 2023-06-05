using DAL.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace DAL
{
    public class AdoDotNet : IDal
    {
        public List<User> GetAllUsers(string connString)
        {
            List<User> users = new List<User>();
            using (SqlConnection con = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand("usp_GetAllUsers", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        User user = new();
                        user.Id = Convert.ToInt32(rdr["Id"]);
                        user.FirstName = rdr["FirstName"].ToString();
                        user.LastName = rdr["LastName"].ToString();
                        user.Age = Convert.ToInt32(rdr["Age"]);

                        users.Add(user);
                    }
                    con.Close();
                }

            }
            return users;
        }

        public User GetUserById(int id, string connString)
        {
            User user = new();

            using (SqlConnection con = new SqlConnection(connString))
            {
                string sqlQuery = "SELECT * FROM Users WHERE Id = @id";
                using (SqlCommand cmd = new SqlCommand(sqlQuery, con))
                {
                    con.Open();
                    cmd.Parameters.AddWithValue("@Id", id);
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        user.Id = Convert.ToInt32(rdr["Id"]);
                        user.FirstName = rdr["FirstName"].ToString();
                        user.LastName = rdr["LastName"].ToString();
                        user.Age = Convert.ToInt32(rdr["Age"]);
                    }
                }
            }
            return user;
        }

        public List<User> GetUsersByLastName(string lname, string connString)
        {
            List<User> users = new List<User>();
            using (SqlConnection con = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand("usp_GetUsersByLastName", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@lname", lname);
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        User user = new();
                        user.Id = Convert.ToInt32(rdr["Id"]);
                        user.FirstName = rdr["FirstName"].ToString();
                        user.LastName = rdr["LastName"].ToString();
                        user.Age = Convert.ToInt32(rdr["Age"]);

                        users.Add(user);
                    }
                    con.Close();
                }

            }
            return users;
        }
        public void DeleteUser(int id,string connString)
        {
            using (SqlConnection con = new SqlConnection(connString))
            {
                SqlTransaction tran = null;
                try
                {
                    con.Open();
                    tran = con.BeginTransaction();
                    using (SqlCommand cmd = new SqlCommand("usp_DeleteUser", con, tran))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Id", id);
                        cmd.ExecuteNonQuery();
                    }
                    tran.Commit();
                    con.Close();
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                }
                
            }
        }       

        public void InsertUser(User user, string connString)
        {
            using (SqlConnection con = new SqlConnection(connString))
            {
                SqlTransaction tran = null;
                try
                {
                    con.Open();
                    tran = con.BeginTransaction();
                    using (SqlCommand cmd = new SqlCommand("usp_InsertUser", con, tran))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@FirstName", user.FirstName);
                        cmd.Parameters.AddWithValue("@LastName", user.LastName);
                        cmd.Parameters.AddWithValue("@Age", user.Age);
                        cmd.ExecuteNonQuery();
                    }
                    tran.Commit();
                    con.Close();
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                }             
                    
            }
        }

        public void UpdateUser(int id, User user, string connString)
        {
            using (SqlConnection con = new SqlConnection(connString))
            {
                SqlTransaction tran = null;
                try
                {
                    con.Open();
                    tran = con.BeginTransaction();
                    using (SqlCommand cmd = new SqlCommand("usp_UpdateUser", con, tran))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Id", id);
                        cmd.Parameters.AddWithValue("@FirstName", user.FirstName);
                        cmd.Parameters.AddWithValue("@LastName", user.LastName);
                        cmd.Parameters.AddWithValue("@Age", user.Age);
                        cmd.ExecuteNonQuery();
                    }
                    tran.Commit();
                    con.Close();
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                }

            }
        }
    }
}

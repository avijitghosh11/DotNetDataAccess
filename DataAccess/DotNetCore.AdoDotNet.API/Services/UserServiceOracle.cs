using System.Data;
using DotNetCore.AdoDotNet.API.Models;
using Oracle.ManagedDataAccess.Client;


namespace DotNetCore.AdoDotNet.API.Services
{
    public class UserServiceOracle : IUserService
    {
        private readonly string connString;
        public UserServiceOracle(IConfiguration configuration) {
            connString = configuration.GetConnectionString("OracleConnection");
        }
        
        public List<User> GetAllUsers()
        {
            List<User> users = new List<User>();
            using (OracleConnection con = new OracleConnection(connString))
            {
                con.Open();
                try
                {
                    using (OracleCommand cmd = new OracleCommand("usp_GetAllUsers", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        OracleDataReader rdr = cmd.ExecuteReader();

                        while (rdr.Read())
                        {
                            User user = new();
                            user.Id = Convert.ToInt32(rdr["Id"]);
                            user.FirstName = rdr["FirstName"].ToString();
                            user.LastName = rdr["LastName"].ToString();
                            user.Age = Convert.ToInt32(rdr["Age"]);

                            users.Add(user);
                        }
                    }
                }
                catch (Exception ex)
                {

                }
                finally
                {
                    if (con.State == ConnectionState.Open)
                        con.Close();
                }
            }
            return users;
        }

        public User GetUserById(int id)
        {
            User user = new();

            using (OracleConnection con = new OracleConnection(connString))
            {
                string sqlQuery = "SELECT * FROM Users WHERE Id = :Id";
                con.Open();
                try
                {
                    using (OracleCommand cmd = new OracleCommand(sqlQuery, con))
                    {
                        cmd.Parameters.Add(new OracleParameter("Id", id));
                        OracleDataReader rdr = cmd.ExecuteReader();
                        while (rdr.Read())
                        {
                            user.Id = Convert.ToInt32(rdr["Id"]);
                            user.FirstName = rdr["FirstName"].ToString();
                            user.LastName = rdr["LastName"].ToString();
                            user.Age = Convert.ToInt32(rdr["Age"]);
                        }
                    }
                }
                catch (Exception ex)
                {

                }
                finally
                {
                    if (con.State == ConnectionState.Open)
                        con.Close();
                }
            }
            return user;
        }

        public List<User> GetUsersByLastName(string lname)
        {
            List<User> users = new List<User>();
            using (OracleConnection con = new OracleConnection(connString))
            {
                con.Open();
                try
                {
                    using (OracleCommand cmd = new OracleCommand("usp_GetUsersByLastName", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new OracleParameter("lname", lname));
                        OracleDataReader rdr = cmd.ExecuteReader();

                        while (rdr.Read())
                        {
                            User user = new();
                            user.Id = Convert.ToInt32(rdr["Id"]);
                            user.FirstName = rdr["FirstName"].ToString();
                            user.LastName = rdr["LastName"].ToString();
                            user.Age = Convert.ToInt32(rdr["Age"]);

                            users.Add(user);
                        }
                    }
                }
                catch(Exception ex)
                {

                }
                finally
                {
                    if (con.State == ConnectionState.Open)
                        con.Close();
                }

            }
            return users;
        }
        public void DeleteUser(int id)
        {
            using (OracleConnection con = new OracleConnection(connString))
            {
                OracleTransaction tran = null;
                try
                {
                    con.Open();
                    tran = con.BeginTransaction();
                    using (OracleCommand cmd = new OracleCommand("usp_DeleteUser", con))
                    {
                        cmd.Transaction = tran;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new OracleParameter("User_Id", id));
                        cmd.ExecuteNonQuery();
                    }
                    tran.Commit();
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                }
                finally
                {
                    if (con.State == ConnectionState.Open)
                        con.Close();
                }
            }
        }

        public void InsertUser(User user)
        {
            using (OracleConnection con = new OracleConnection(connString))
            {
                OracleTransaction tran = null;
                try
                {
                    con.Open();
                    tran = con.BeginTransaction();
                    using (OracleCommand cmd = new OracleCommand("usp_InsertUser", con))
                    {
                        cmd.Transaction = tran;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new OracleParameter("User_FirstName", user.FirstName));
                        cmd.Parameters.Add(new OracleParameter("User_LastName", user.LastName));
                        cmd.Parameters.Add(new OracleParameter("User_Age", user.Age));
                        cmd.ExecuteNonQuery();
                    }
                    tran.Commit();
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                }
                finally
                {
                    if (con.State == ConnectionState.Open)
                        con.Close();
                }
            }
        }

        public void UpdateUser(int id, User user)
        {
            using (OracleConnection con = new OracleConnection(connString))
            {
                OracleTransaction tran = null;
                try
                {
                    con.Open();
                    tran = con.BeginTransaction();
                    using (OracleCommand cmd = new OracleCommand("usp_UpdateUser", con))
                    {
                        cmd.Transaction = tran;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new OracleParameter("User_Id", id));
                        cmd.Parameters.Add(new OracleParameter("User_FirstName", user.FirstName));
                        cmd.Parameters.Add(new OracleParameter("User_LastName", user.LastName));
                        cmd.Parameters.Add(new OracleParameter("User_Age", user.Age));
                        cmd.ExecuteNonQuery();
                    }
                    tran.Commit();
                    
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                }
                finally
                {
                    if (con.State == ConnectionState.Open)
                        con.Close();
                }
            }
        }
    }
}

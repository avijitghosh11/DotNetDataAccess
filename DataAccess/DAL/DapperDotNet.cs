using DAL.Models;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;

namespace DAL
{
    public class DapperDotNet : IDal
    {
        public List<User> GetAllUsers(string connString)
        {
            List<User> users = new List<User>();
            using (SqlConnection con = new SqlConnection(connString))
            {
                con.Open();
                users = con.Query<User>("usp_GetAllUsers", commandType: CommandType.StoredProcedure).ToList();
                con.Close();
            }
            return users;
        }

        public User GetUserById(int id, string connString)
        {
            User user = new();

            using (SqlConnection con = new SqlConnection(connString))
            {
                string sqlQuery = "SELECT * FROM Users WHERE Id = @id";
                var parameters = new { id = id};
                con.Open();
                user = con.QuerySingleOrDefault<User>(sqlQuery, parameters);
                con.Close();
            }
            return user;
        }

        public List<User> GetUsersByLastName(string lname, string connString)
        {
            List<User> users = new List<User>();
            using (SqlConnection con = new SqlConnection(connString))
            {
                var parameters = new { lname = lname };
                con.Open();
                users = con.Query<User>("usp_GetUsersByLastName",param: parameters, commandType: CommandType.StoredProcedure).ToList();
                con.Close();
            }
            return users;
        }
        public void DeleteUser(int id, string connString)
        {
            using (SqlConnection con = new SqlConnection(connString))
            {
                SqlTransaction tran = null;
                try
                {
                    con.Open();
                    tran = con.BeginTransaction();
                    var parameters = new { id = id };
                    con.Query("usp_DeleteUser", param: parameters, 
                        commandType: CommandType.StoredProcedure,transaction:tran);
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
                    var parameters = new { FirstName = user.FirstName, LastName = user.LastName, Age = user.Age };
                    con.Query("usp_InsertUser", param: parameters,
                        commandType: CommandType.StoredProcedure, transaction: tran);
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
                    var parameters = new { Id = id, FirstName = user.FirstName, LastName = user.LastName, Age = user.Age };
                    con.Query("usp_UpdateUser", param: parameters,
                        commandType: CommandType.StoredProcedure, transaction: tran);
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

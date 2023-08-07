using DotNetCore.Dapper.API.Models;
using System.Data;
using Microsoft.Data.SqlClient;
using Dapper;

namespace DotNetCore.Dapper.API.Services
{
    public class UserService : IUserService
    {
        private readonly string connString;
        public UserService(IConfiguration configuration)
        {
            connString = configuration.GetConnectionString("ApplicationConnection");
        }
        public void DeleteUser(int id)
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

        public List<User> GetAllUsers()
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

        public User GetUserById(int id)
        {
            User user = new();

            using (SqlConnection con = new SqlConnection(connString))
            {
                string sqlQuery = "SELECT * FROM Users WHERE Id = @id";
                var parameters = new { id = id };
                con.Open();
                user = con.QuerySingleOrDefault<User>(sqlQuery, parameters);
                con.Close();
            }
            return user;
        }

        public List<User> GetUsersByLastName(string lname)
        {
            List<User> users = new List<User>();
            using (SqlConnection con = new SqlConnection(connString))
            {
                var parameters = new { lname = lname };
                con.Open();
                users = con.Query<User>("usp_GetUsersByLastName", param: parameters, commandType: CommandType.StoredProcedure).ToList();
                con.Close();
            }
            return users;
        }

        public void InsertUser(User user)
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

        public void UpdateUser(int id, User user)
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

using DotNetCore.Dapper.API.Models;
using System.Data;
using Dapper;
using Oracle.ManagedDataAccess.Client;

namespace DotNetCore.Dapper.API.Services
{
    public class UserServiceOracle : IUserService
    {
        private readonly string connString;
        public UserServiceOracle(IConfiguration configuration)
        {
            connString = configuration.GetConnectionString("OracleConnection");
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
                    var parameters = new { User_id = id };
                    con.Query("usp_DeleteUser", param: parameters,
                        commandType: CommandType.StoredProcedure, transaction: tran);
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

        public List<User> GetAllUsers()
        {
            List<User> users = new List<User>();
            using (OracleConnection con = new OracleConnection(connString))
            {
                con.Open();
                try
                {
                    users = con.Query<User>("usp_GetAllUsers", commandType: CommandType.StoredProcedure).ToList();
                }
                catch { }
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
                string sqlQuery = "SELECT * FROM Users WHERE Id = :id";
                var parameters = new { id = id };
                con.Open();
                try
                {
                    user = con.QuerySingleOrDefault<User>(sqlQuery, parameters);
                }
                catch { }
                finally
                {
                    if (con.State == ConnectionState.Open)
                        con.Close();
                }
            }
            return user;
        }

        public List<User> GetUsersByLastName(string lastname)
        {
            List<User> users = new List<User>();
            using (OracleConnection con = new OracleConnection(connString))
            {
                var parameters = new { User_LastName = lastname };
                con.Open();
                try
                {
                    users = con.Query<User>("usp_GetUsersByLastName", 
                        param: parameters, commandType: CommandType.StoredProcedure).ToList();
                }
                catch (Exception ex){ }
                finally
                {
                    if (con.State == ConnectionState.Open)
                        con.Close();
                }
            }
            return users;
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
                    var parameters = new { User_FirstName = user.FirstName, 
                        User_LastName = user.LastName, User_Age = user.Age };
                    con.Query("usp_InsertUser", param: parameters,
                        commandType: CommandType.StoredProcedure, transaction: tran);
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
                    var parameters = new { User_Id = id, User_FirstName = user.FirstName, 
                        User_LastName = user.LastName, User_Age = user.Age };
                    con.Query("usp_UpdateUser", param: parameters,
                        commandType: CommandType.StoredProcedure, transaction: tran);
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

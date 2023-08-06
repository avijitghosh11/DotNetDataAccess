using DAL;
using DAL.Models;
using System.Configuration;

namespace DotNetDataAccess
{
    public class Program
    {
        public static string connString = ConfigurationManager.ConnectionStrings["AppAdoDotNetConnection"].ConnectionString;
        public static IDal dal = new DapperDotNet();
        public static void Main(string[] args)
        {
            //List<User> users = dal.GetAllUsers(connString);
            //User usersById = dal.GetUserById(5, connString);
            //List<User> usersByLastName = dal.GetUsersByLastName("Gebb", connString);
            User user = new()
            {
                Age = 34,
                FirstName = "Avijit",
                LastName = "Ghosh"
            };
            //dal.InsertUser(user, connString);
            //dal.UpdateUser(1003,user, connString);
            dal.DeleteUser(1003,connString);

        }
    }
}

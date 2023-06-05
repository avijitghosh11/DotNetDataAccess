using DAL;
using System.Configuration;

namespace DotNetDataAccess
{
    public class Program
    {
        public static string connString = ConfigurationManager.ConnectionStrings["AppAdoDotNetConnection"].ConnectionString;
        public static IDal dal = new AdoDotNet();
        public static void Main(string[] args)
        {
            //List<User> users = dal.GetAllUsers(connString);
            //List<User> usersByLastName = dal.GetUsersByLastName("Gebb", connString);
            //User usersById = dal.GetUserById(5, connString);
            //User user = new()
            //{
            //    Age = 33,
            //    FirstName = "Avijit",
            //    LastName = "Ghosh"
            //};
            //dal.UpdateUser(1002,user, connString);
            //dal.DeleteUser(1002,connString);
        }
    }
}

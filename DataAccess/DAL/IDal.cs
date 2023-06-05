using DAL.Models;

namespace DAL
{
    public interface IDal
    {
        public List<User> GetUsersByLastName(string lname, string connString);
        public List<User> GetAllUsers(string connString);
        public User GetUserById(int id, string connString);
        public void UpdateUser(int id,User user, string connString);
        public void DeleteUser(int id, string connString);
        public void InsertUser(User user, string connString);
    }
}

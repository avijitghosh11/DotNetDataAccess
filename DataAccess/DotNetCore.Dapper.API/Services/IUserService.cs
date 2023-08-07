using DotNetCore.Dapper.API.Models;

namespace DotNetCore.Dapper.API.Services
{
    public interface IUserService
    {
        public List<User> GetUsersByLastName(string lname);
        public List<User> GetAllUsers();
        public User GetUserById(int id);
        public void UpdateUser(int id, User user);
        public void DeleteUser(int id);
        public void InsertUser(User user);
    }
}

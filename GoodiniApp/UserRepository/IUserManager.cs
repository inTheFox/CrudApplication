using GoodiniApp.Models;

namespace GoodiniApp.UserRepository;

public interface IUserManager
{
    public List<User> GetUsers();
    public User? GetUserById(int id);
    public User AddUser(User user);
    public User UpdateUserById(int id, User user);
    public void RemoveUserById(int id);
}
using GoodiniApp.Models;

namespace GoodiniApp.UserRepository
{
    public class UserManager : IUserManager
    {
        private readonly List<User> _users;

        public UserManager()
        {
            _users = new();
        }

        public List<User> GetUsers()
        {
            return _users;
        }

        public User? GetUserById(int id)
        {
            return _users.FirstOrDefault(p => p.Id == id);
        }

        public User AddUser(User user)
        {
            user.Id = _users.Count + 1;
            _users.Add(user);
            return user;
        }

        public User? UpdateUserById(int id, User user)
        {
            var currentUser = GetUserById(id);
            if (currentUser == null) return null;

            currentUser.Email = user.Email;
            currentUser.FirstName = user.FirstName;
            currentUser.LastName = user.LastName;
            return currentUser;
        }

        public void RemoveUserById(int id)
        {
            _users.RemoveAll(p => p.Id == id);
        }
    }
}

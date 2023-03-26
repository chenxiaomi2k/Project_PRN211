using PasswordLibrary.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordLibrary.Repository
{
    public class UserRepository : IUserRepository
    {
        public void AddUser(User user)
        {
            UserDAO.Instance.RegisterNewUser(user);
        }

        public bool CheckUser(string name)
        {
            return UserDAO.Instance.GetUserByName(name);
        }

        public User GetUser(string username)
        {
            return UserDAO.Instance.GetUser(username);
        }

        public User GetUserById(int id)
        {
            return UserDAO.Instance.GetUserById(id);
        }
    }
}

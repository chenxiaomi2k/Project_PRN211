using PasswordLibrary.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordLibrary.Repository
{
    public interface IUserRepository
    {
        User GetUser(string username);
        bool CheckUser(string name);
        void AddUser(User user);
        User GetUserById(int id);
    }
}

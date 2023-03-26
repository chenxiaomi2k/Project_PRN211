using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordLibrary.DataAccess
{
    public class UserDAO
    {
        private static UserDAO instance = null;
        private static readonly object instanceLock = new object();
        public static UserDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new UserDAO();
                    }
                }
                return instance;
            }
        }

        //Get user to login
        public User GetUser(string username)
        {
            User user = null;
            try
            {
                using var context = new ProjectPrn211Context();
                user = context.Users.SingleOrDefault(x => x.Username == username);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return user;
        }

        //Check user exist
        public bool GetUserByName(string name)
        {
            User u = null;
            try
            {
                using var context = new ProjectPrn211Context();
                u = context.Users.SingleOrDefault(x => x.Username == name);
                if (u == null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public User GetUserById(int id)
        {
            User u = null;
            try
            {
                using var context = new ProjectPrn211Context();
                u = context.Users.SingleOrDefault(x => x.Id == id);
                if (u == null)
                {
                    return null;
                }
                else
                {
                    return u;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //Register a new user
        public void RegisterNewUser(User user)
        {
            bool checkUser = GetUserByName(user.Username);
            if (checkUser)
            {
                try
                {
                    using var context = new ProjectPrn211Context();
                    context.Users.Add(user);
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            else
            {
                throw new Exception("User already exist!");
            }
        }
    }
}

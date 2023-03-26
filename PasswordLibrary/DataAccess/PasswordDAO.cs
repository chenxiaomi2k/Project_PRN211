using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PasswordLibrary.DataAccess
{
    public class PasswordDAO
    {
        private static PasswordDAO instance = null;
        private static readonly object instanceLock = new object();
        public static PasswordDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new PasswordDAO();
                    }
                }
                return instance;
            }
        }

        //Show list of passwords to bind into grid view
        public List<Password> GetPasswords(int id)
        {
            List<Password> passwords = new List<Password>();
            try
            {
                using var context = new ProjectPrn211Context();
                passwords = context.Passwords.Where(x => x.UserId == id).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return passwords;
        }

        //Check if password exist or not
        public bool CheckPasswordExist(string website, int uid)
        {
            Password password = null;
            try
            {
                using var context = new ProjectPrn211Context();
                password = context.Passwords.FirstOrDefault(x => x.Website == website && x.UserId == uid);
                if (password == null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //Insert new password into database
        public void AddNewPassword(Password pass, int uid)
        {
            bool checker = CheckPasswordExist(pass.Website, uid);
            if (!checker)
            {
                try
                {
                    using var context = new ProjectPrn211Context();
                    context.Passwords.Add(pass);
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            else
            {
                throw new Exception();
            }
        }

        //Search password saved by website name
        public List<Password> GetPasswordByWebsite(string website, int uid)
        {
            var passwords = new List<Password>();
            try
            {
                using var context = new ProjectPrn211Context();
                passwords = context.Passwords.Where(x => x.Website.Contains(website) && x.UserId == uid).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return passwords;
        }

        //Filter password by category
        public List<Password> FilterPassword(string category, int id)
        {
            var list = new List<Password>();
            try
            {
                using var context = new ProjectPrn211Context();
                list = context.Passwords.Where(x => x.Category == category && x.UserId == id).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return list;
        }

        //Delete password from database
        public void DeletePassword(int id)
        {
            try
            {
                using var context = new ProjectPrn211Context();
                Password password = context.Passwords.Find(id);
                context.Passwords.Remove(password);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //Get password by id
        public Password GetPasswordById(int id)
        {
            Password password = null;
            try
            {
                using var context = new ProjectPrn211Context();
                password = context.Passwords.Find(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return password;
        }

        //Update a password
        public void UpdatePassword(Password password, int uid)
        {
            try
            {
                using var context = new ProjectPrn211Context();
                context.Passwords.Update(password);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

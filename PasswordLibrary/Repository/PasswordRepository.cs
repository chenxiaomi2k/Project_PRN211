using PasswordLibrary.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordLibrary.Repository
{
    public class PasswordRepository : IPasswordRepository
    {
        public void AddPassword(Password pass, int uid)
        {
            PasswordDAO.Instance.AddNewPassword(pass, uid);
        }

        public void DeletePassword(int id)
        {
            PasswordDAO.Instance.DeletePassword(id);
        }

        public List<Password> Filter(string cate, int id)
        {
            return PasswordDAO.Instance.FilterPassword(cate, id);
        }

        public Password GetPasswordById(int id)
        {
            return PasswordDAO.Instance.GetPasswordById(id);
        }

        public List<Password> GetPasswordByWebsite(string website, int uid)
        {
            return PasswordDAO.Instance.GetPasswordByWebsite(website, uid);
        }

        public List<Password> GetPasswords(int id)
        {
            return PasswordDAO.Instance.GetPasswords(id);
        }

        public void UpdatePassword(Password password, int uid)
        {
            PasswordDAO.Instance.UpdatePassword(password, uid);
        }
    }
}

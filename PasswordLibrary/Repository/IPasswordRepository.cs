using PasswordLibrary.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordLibrary.Repository
{
    public interface IPasswordRepository
    {
        List<Password> GetPasswords(int id);
        void AddPassword(Password pass, int uid);
        List<Password> GetPasswordByWebsite(string website, int uid);
        List<Password> Filter(string cate, int id);
        void DeletePassword(int id);
        Password GetPasswordById(int id);
        void UpdatePassword(Password password, int uid);
    }
}

using Microsoft.AspNetCore.Mvc;
using PasswordLibrary.DataAccess;
using PasswordLibrary.Repository;

namespace Password_Management_WebApp.Controllers
{
    public class UserController : Controller
    {
        private IUserRepository userRepository = new UserRepository();

        public ActionResult Index()
        {
            ViewBag.logged = HttpContext.Session.GetString("isLogin");
            return View("Login");
        }

        public ActionResult Login(string username, string password)
        {
            User user = userRepository.GetUser(username);
            if (user != null)
            {
                if (BCrypt.Net.BCrypt.Verify(password, user.Password))
                {
                    HttpContext.Session.SetString("isLogin", user.Username);
                    return RedirectToAction("Index", "Password", new { id = user.Id, inx = 1 });
                }
                else
                {
                    ViewBag.mess = "Incorrect username or password!";
                    return View("Login");
                }
            }
            ViewBag.mess = "Incorrect username or password!";
            return View("Login");
        }

        public ActionResult RegisterIndex()
        {
            return View("Register");
        }

        public ActionResult Register(string username, string password, string repassword)
        {
            if (!password.Equals(repassword))
            {
                ViewBag.mess = "Re-enter password must be the same as Password!";
                return View("Register");
            }
            User user = new User { Username = username, Password = BCrypt.Net.BCrypt.HashPassword(password) };
            try
            {
                userRepository.AddUser(user);
                ViewBag.mess = "Sign up successfully!";
            }
            catch (Exception ex)
            {
                ViewBag.mess = ex.Message;
            }
            return View("Register");
        }

        public ActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "User");
        }
    }
}

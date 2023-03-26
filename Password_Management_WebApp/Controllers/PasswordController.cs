using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using NuGet.Protocol.Core.Types;
using Password_Management_WebApp.Models;
using PasswordLibrary.DataAccess;
using PasswordLibrary.Repository;
using System;
using System.Collections.Generic;

namespace Password_Management_WebApp.Controllers
{
    public class PasswordController : Controller
    {
        IUserRepository userRepository = new UserRepository();
        private IPasswordRepository passwordRepository = new PasswordRepository();
        public User User { get; set; }

        // GET: PasswordController
        public ActionResult Index(int id, int inx)
        {
            List<Password> list = passwordRepository.GetPasswords(id);
            this.User = userRepository.GetUserById(id);
            ViewBag.user = User;
            //HttpContext.Session.SetString("isLogin", User.Username);
            ViewBag.logged = HttpContext.Session.GetString("isLogin");
            //paging
            int pageSize = list.Count / 5;
            if (list.Count % 5 != 0)
            {
                pageSize++;
            }
            ViewData["prev"] = inx - 1;
            ViewData["next"] = inx + 1;
            if (inx == 1)
            {
                ViewData["prev"] = 1;
                if (pageSize == 1)
                {
                    ViewData["next"] = 1;
                }
            }
            else if (inx == pageSize)
            {
                ViewData["next"] = pageSize;
            }
            ViewBag.pageSize = pageSize;
            ViewBag.index = inx;
            List<Password> pagingList = list.OrderBy(p => p.Website)
                .Skip((inx - 1) * 5).Take(5).ToList();
            return View("Home", pagingList);
        }

        // GET: PasswordController/Create
        public ActionResult Create(int uid)
        {
            this.User = userRepository.GetUserById(uid);
            ViewBag.user = User;
            ViewBag.logged = HttpContext.Session.GetString("isLogin");
            ViewBag.uid = uid;
            return View("CreatePassword");
        }
        
        // POST: PasswordController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Password password)
        {
            try
            {
                passwordRepository.AddPassword(password, password.UserId);
                return RedirectToAction("Index", "Password", new { id = password.UserId, inx = 1 });
            }
            catch
            {
                ViewBag.mess = "This password is already exist!";
                this.User = userRepository.GetUserById(password.UserId);
                ViewBag.user = User;
                ViewBag.logged = HttpContext.Session.GetString("isLogin");
                ViewBag.uid = password.UserId;
                return View("CreatePassword");
            }
        }

        // GET: PasswordController/Edit/5
        public ActionResult Edit(int id, int uid)
        {
            this.User = userRepository.GetUserById(uid);
            ViewBag.user = User;
            ViewBag.logged = HttpContext.Session.GetString("isLogin");
            Password password = passwordRepository.GetPasswordById(id);
            return View("EditPassword", password);
        }

        // POST: PasswordController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            Password password = passwordRepository.GetPasswordById(id);
            string webname = collection["Website"];
            if (webname.Equals(password.Website))
            {
                try
                {
                    password.UserId = int.Parse(collection["UserId"]);
                    password.Username = collection["Username"];
                    password.SavedPassword = collection["SavedPassword"];
                    password.Category = collection["Category"];
                    password.Note = collection["Note"];
                    passwordRepository.UpdatePassword(password, password.UserId);
                    return RedirectToAction("Index", "Password", new { id = password.UserId, inx = 1 });
                }
                catch
                {
                    ViewBag.mess = "This password is already exist! Edit unsuccessful.";
                    this.User = userRepository.GetUserById(password.UserId);
                    ViewBag.user = User;
                    ViewBag.logged = HttpContext.Session.GetString("isLogin");
                    return View("EditPassword", password);
                }
            }
            Password pass = passwordRepository.GetPasswords(int.Parse(collection["UserId"]))
                .FirstOrDefault(p => p.Website == webname);
            if (pass == null)
            {
                try
                {
                    password.Website = webname;
                    password.UserId = int.Parse(collection["UserId"]);
                    password.Username = collection["Username"];
                    password.SavedPassword = collection["SavedPassword"];
                    password.Category = collection["Category"];
                    password.Note = collection["Note"];
                    passwordRepository.UpdatePassword(password, password.UserId);
                    return RedirectToAction("Index", "Password", new { id = password.UserId, inx = 1 });
                }
                catch
                {
                    ViewBag.mess = "This password is already exist! Edit unsuccessful.";
                    this.User = userRepository.GetUserById(password.UserId);
                    ViewBag.user = User;
                    return View("EditPassword", password);
                }
            }
            else
            {
                ViewBag.mess = "This password is already exist! Edit unsuccessful.";
                this.User = userRepository.GetUserById(password.UserId);
                ViewBag.user = User;
                return View("EditPassword", password);
            }
        }

        // GET: PasswordController/Delete/5
        public ActionResult Delete(int id, int uid)
        {
            Password password = passwordRepository.GetPasswordById(id);
            this.User = userRepository.GetUserById(uid);
            ViewBag.user = User;
            ViewBag.logged = HttpContext.Session.GetString("isLogin");
            return View("DeletePassword", password);
        }

        // POST: PasswordController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, int uid, IFormCollection collection)
        {
            try
            {
                passwordRepository.DeletePassword(id);
                this.User = userRepository.GetUserById(uid);
                ViewBag.user = User;
                ViewBag.logged = HttpContext.Session.GetString("isLogin");
                ViewBag.mess = "Password has been deleted! Go back to your password list.";
                return RedirectToAction("Index", "Password", new { id = uid, inx = 1 });
            }
            catch
            {
                this.User = userRepository.GetUserById(uid);
                ViewBag.user = User;
                ViewBag.logged = HttpContext.Session.GetString("isLogin");
                ViewBag.mess = "There is nothing to delete! Go back to your password list";
                return View("DeletePassword");
            }
        }

        //POST: Password/Search/webname
        [HttpPost]
        public ActionResult Search(int uid, IFormCollection collection)
        {
            if (collection["websearch"].ToString().IsNullOrEmpty())
            {
                return RedirectToAction("Index", "Password", new { id = uid, inx = 1 });
            }
            this.User = userRepository.GetUserById(uid);
            ViewBag.user = User;
            ViewBag.logged = HttpContext.Session.GetString("isLogin");
            ViewBag.search = collection["websearch"];
            List<Password> listSearch = passwordRepository
                .GetPasswordByWebsite(collection["websearch"], uid);
            return View("Home", listSearch.OrderBy(p => p.Website));
        }

        //POST: Password/Filter/categoryName
        [HttpPost]
        public ActionResult Filter(string cate, int uid, int inx)
        {
            if (cate.Equals("all"))
            {
                return RedirectToAction("Index", "Password", new { id = uid, inx = 1 });
            }
            List<Password> filter = passwordRepository.Filter(cate, uid);
            this.User = userRepository.GetUserById(uid);
            ViewBag.user = User;
            ViewBag.logged = HttpContext.Session.GetString("isLogin");
            ViewBag.filter = cate;  
            return View("Home", filter.OrderBy(p => p.Website));
        }
    }
}

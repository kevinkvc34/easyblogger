using System.Net;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using blog.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace blog.Controllers
{
    public class HomeController : Controller
    {
        private MyContext dbcontext;
        public HomeController(MyContext context) {
            dbcontext = context;
        }
        [HttpGet("")]
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet("register")]
        public IActionResult LoadRegisterPage() {
            return View("register");
        }
        [HttpGet("login")]
        public IActionResult LoadLoginPage() {
            return View("login");
        }
        [HttpPost("register-user")]
        public IActionResult PostRegisterUser(User user) {
            if(dbcontext.Users.Any(a => a.Username == user.Username)) {
                return Redirect("/");
            } else {
            PasswordHasher<User> Hasher = new PasswordHasher<User>();
            user.Password = Hasher.HashPassword(user, user.Password);
            dbcontext.Users.Add(user);
            dbcontext.SaveChanges();
            HttpContext.Session.SetInt32("logged_user", user.UserId);
            return Redirect("/dashboard");
            }
        }
        [HttpPost("login-user")]
        public IActionResult PostLoginUser(loginuser user) {
            if(dbcontext.Users.Any(a => a.Username == user.Username)) {
                User u = dbcontext.Users.FirstOrDefault(f => f.Username == user.Username);
                var hasher = new PasswordHasher<loginuser>();
                var result = hasher.VerifyHashedPassword(user, u.Password, user.Password);
                if(result == 0) {
                    return Redirect("/");
                } else {
                    HttpContext.Session.SetInt32("logged_user", u.UserId);
                    return Redirect("/dashboard");
                }
            } else {
                return Redirect("/");
            }
        }
        [HttpGet("/dashboard")]
        public IActionResult Dash() {
            if(HttpContext.Session.GetInt32("logged_user") == null) {
                return Redirect("/");
            } else {
            User u = dbcontext.Users.FirstOrDefault(f => f.UserId == HttpContext.Session.GetInt32("logged_user"));
            return View(u);
            }
        }
        [HttpGet("logout")]
        public IActionResult Logout() {
            HttpContext.Session.Clear();
            return Redirect("/");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

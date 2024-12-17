using PokemonGame.Data;
using PokemonGame.Main.Models;
using PokemonGame.Architecture.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Web;
using System.Web.Mvc;
using System.Web.SessionState;

namespace PokemonGame.Main.Controllers
{
    public class HomeController : Controller
    {
        private readonly PokemonBDEntities _db;
        private readonly UserService _userService;

        public HomeController()
        {
            _userService = new UserService();
            _db = new PokemonBDEntities();
        }

        public ActionResult Index()
        {
            var sessionId = Request.Cookies["session_id"]?.Value;

            if (!string.IsNullOrEmpty(sessionId))
            {
                return RedirectToAction("Index", "Trainer");
            }

            return View();
        }

        [HttpPost]
        public ActionResult Register(string name, string email, string password)
        {
            if (_db.Users.Any(x => x.Email == email))
            {
                ModelState.AddModelError("", "Email already register");
                return View("Index");
            }
            else
            {
                bool isSuccess = _userService.CreateUserDB(name, email, password);
                if (isSuccess)
                {
                    return View("Index");
                }
            }

            return View("Index");
        } 

        [HttpPost]
        public ActionResult Login(string email, string password)
        {
            var search = _userService.LoginUserDB(email, password);
            
            if (search != null)
            {
                var sessionId = Guid.NewGuid().ToString();

                var cookie = new HttpCookie("session_id", sessionId)
                {
                    HttpOnly = true,
                    Secure = true,
                    SameSite = SameSiteMode.Strict,
                    Expires = DateTime.Now.AddHours(2),
                    Value = search.UserId.ToString()
                };

                Response.Cookies.Add(cookie);

                var query = _db.Users.SingleOrDefault(x => x.Email == email);
                if (query.UserId == 1) 
                {
                    return RedirectToAction("Index","Admin");
                }


                return RedirectToAction("Index", "Trainer");
            }
            ModelState.AddModelError("", "The email or password are incorrect");
            return View("Index");
        }

        //Logout
        public ActionResult Logout()
        {
            if (Request.Cookies["session_id"] != null)
            {
                var cookie = new HttpCookie("session_id")
                {
                    Expires = DateTime.Now.AddDays(-1)
                };
                Response.Cookies.Add(cookie);
            }

            return View("Index");
        }
    }
}
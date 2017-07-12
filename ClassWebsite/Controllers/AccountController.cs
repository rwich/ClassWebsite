using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ClassWebsite.Models;

namespace ClassWebsite.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterViewModel mem)
        {
            // make sure model is valid
            if (ModelState.IsValid)
            {
                // if valid add to DB
                Member m = new Member()
                {
                    Username = mem.Username,
                    Password = mem.Password,
                    Email = mem.Email,
                };
                MemberDB.RegisterMember(m);
                return RedirectToAction("Index", "Home");
            }
            // if invalid, return view w/ errors
            return View(mem);
        }
    }
}
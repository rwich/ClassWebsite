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
            if (SessionHelper.IsUserLoggedIn())
            {
                return RedirectToAction("Index", "Home");
            }
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
                SessionHelper.LogUserIn(m);
                return RedirectToAction("Index", "Home");
            }
            // if invalid, return view w/ errors
            return View(mem);
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel loginData)
        {
            if (ModelState.IsValid)
            {
                Member m = MemberDB.FindMember(loginData.Username, loginData.Password);
                if(m == null)
                {
                    ModelState.AddModelError("InvalidCredentials", "No Account with those credentials was found");
                    return View(loginData);
                }

                //log them in
                SessionHelper.LogUserIn(m);
                //redirect to index page
                return RedirectToAction("Index", "Home");
            }

            return View(loginData);
        }

        public ActionResult LogOut()
        {
            Session.Abandon(); //ends user's session
            return RedirectToAction("Index", "Home");
        }

        public ActionResult MyAccount()
        {
            if (SessionHelper.IsUserLoggedIn())
            {
                Member currMember = MemberDB.GetCurrentMember();
                return View(currMember);
            }
            return RedirectToAction("Login", "Account");
        }
    }
}
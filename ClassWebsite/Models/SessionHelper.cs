using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClassWebsite.Models
{
    public static class SessionHelper
    {
        public static int GetCurrentUserId()
        {
            return (int)HttpContext.Current.Session["MemberID"];
        }

        public static void LogUserIn(Member m)
        {
            HttpContext.Current.Session["MemberID"] = m.MemberID;
        }

        public static bool IsUserLoggedIn()
        {
            if(HttpContext.Current.Session["MemberID"] == null)
            {
                return false;
            }
            return true;
        }
    }
}
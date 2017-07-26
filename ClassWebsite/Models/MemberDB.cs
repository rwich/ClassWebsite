using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClassWebsite.Models
{
    public static class MemberDB
    {
        /// <summary>
        /// Adds member to the database
        /// </summary>
        /// <param name="m"></param>
        public static void RegisterMember(Member m)
        {
            ECommerceDB db = new ECommerceDB();

            db.Members.Add(m);
            db.SaveChanges(); //MUST call SaveChanges for INSERTS, UPDATES, and DELETES!

        }

        /// <summary>
        /// Finds a member with the supplied credentials
        /// Returns null if there is no match
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static Member FindMember(string username, string password)
        {
            var db = new ECommerceDB();
            //finds users with supplied credentials
            return (from mem in db.Members
                    where mem.Username == username
                    && mem.Password == password
                    select mem).SingleOrDefault();
        }

        public static Member GetCurrentMember()
        {
            int id = SessionHelper.GetCurrentUserId();

            ECommerceDB db = new ECommerceDB();
            Member mem = (from m in db.Members
                          where m.MemberID == id
                          select m).Single();
            return mem;
        }
    }
}
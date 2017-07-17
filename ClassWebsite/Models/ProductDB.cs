using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClassWebsite.Models
{
    public static class ProductDB
    {
        public static List<Product> GetAllProducts()
        {
            ECommerceDB db = new ECommerceDB();
            //List<Product> prods = db.Products.ToList();
            List<Product> prods = (from p in db.Products
                                  select p).ToList();
            return prods;
        }
    }
}
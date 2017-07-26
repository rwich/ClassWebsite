using System;
using System.Collections.Generic;
using System.Data.Entity;
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

        /// <summary>
        /// Adds product to database
        /// </summary>
        /// <param name="p"></param>
        public static void AddProduct(Product p)
        {
            var db = new ECommerceDB();
            db.Products.Add(p);
            db.SaveChanges();
        }

        internal static Product GetProductById(int id)
        {
            ECommerceDB db = new ECommerceDB();
            //Product p = db.Products.Find(id);
            //return p;

            Product p = (from prod in db.Products
                         where prod.ProductID == id
                         select prod).SingleOrDefault();
            return p;
        }

        public static void UpdateProduct(Product p)
        {
            ECommerceDB db = new ECommerceDB();
            db.Entry(p).State = EntityState.Modified;
            db.SaveChanges();
        }

        public static void DeleteProductById(int value)
        {
            ECommerceDB db = new ECommerceDB();
            Product p = db.Products.Find(value);
            db.Products.Remove(p);
            db.SaveChanges();
        }
    }
}
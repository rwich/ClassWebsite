using ClassWebsite.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClassWebsite.Controllers
{
    public class ProductController : Controller
    {
        [HttpGet]
        public ActionResult Index(int? id)
        {
            int currentPage = (id.HasValue) ? id.Value : 1; // shorter version of if/else - turnary operator, ?:
            const int ProdsPerPage = 2;

            ECommerceDB db = new ECommerceDB();
            List<Product> prods = db.Products.OrderBy(p => p.Name).Skip((currentPage - 1) * ProdsPerPage).Take(ProdsPerPage).ToList();

            //cast to avoid integer division, & round up to nearest whole number
            ViewBag.MaxPage = Math.Ceiling(db.Products.Count() / (double)ProdsPerPage);
            ViewBag.CurrentPage = currentPage;
            return View(prods);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Product p, HttpPostedFileBase prodPhoto)
        {
            if (ModelState.IsValid)
            {
                if(prodPhoto != null && prodPhoto.ContentLength > 0)
                {
                    //check MIME type

                    //create filename
                    //string fileName = Path.GetFileName(prodPhoto.FileName);

                    //generate a unique filename to prevent being overwritten
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(prodPhoto.FileName);

                    //generate path w/ filename
                    string path = Path.Combine(Server.MapPath("~/Images"), fileName);

                    //save file
                    prodPhoto.SaveAs(path);
                    p.PhotoLocation = fileName;
                }

                ProductDB.AddProduct(p);
                return RedirectToAction("Index", "Product"); //redirect to index of product controller
            }
            
            // Return view with model errors
            return View(p);
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            //if no product id is supplied in the url, user is redirected
            if(id == null)
            {
                return RedirectToAction("Index", "Product");
            }

            Product p = ProductDB.GetProductById(id.Value);
            
            if(p == null)
            {
                return HttpNotFound();
            }

            return View(p);
        }

        [HttpPost]
        public ActionResult Edit(Product p)
        {
            if (ModelState.IsValid)
            {
                ProductDB.UpdateProduct(p);
                return RedirectToAction("Index");
            }

            return View(p);
        }

        public ActionResult Delete(int? id)
        {
            //TODO: check if ID is null
            ProductDB.DeleteProductById(id.Value);
            return RedirectToAction("Index");
        }
    }
}
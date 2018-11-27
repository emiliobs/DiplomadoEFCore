namespace WepApp.Controllers
{
    using NortWind.DAL;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using NorthWind.Entities;

    public class CategoriesController : Controller
    {
        public IActionResult Index()
        {
            var categories = new List<Category>();

            using (var db = new NorthWindContext())
            {
                categories = db.Categories.ToList();
            }

            return View(categories);
        }

        [HttpPost]
        public ActionResult Index(string categoryName)
        {
            using (var db = new NorthWindContext())
            {
                var newCategory = new Category()
                {
                    CategoryName = categoryName,
                };

                db.Categories.Add(newCategory);
                db.SaveChanges();

            }

            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            var categoryFound = new Category();

            using (var db = new NorthWindContext())
            {
                categoryFound = db.Categories.Where(c => c.CategoryId.Equals(id)).FirstOrDefault();


            }

            return View(categoryFound);
        }


        public ActionResult UpdateOrDelete(Category category, string btnEdit, string btnDelete)
        {
            using (var db = new NorthWindContext())
            {
                if (btnEdit != null)
                {
                    db.Categories.Update(category);

                }
                else if (btnDelete != null)
                {
                    db.Categories.Remove(category);
                    
                }


                try
                {
                    db.SaveChanges();
                }
                catch (Exception ex)
                {

                    ViewData["Error"] = ex.Message;

                    return View("Details");
                }

              

            }


            return RedirectToAction("Index");

        }



    }
}
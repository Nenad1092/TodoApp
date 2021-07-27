using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Repository.Models;
using Repository.GenericRepository;
using System.Collections;

namespace TreloApp.Controllers
{
    public class HomeController : Controller
    {
        // GET: Category

        //private IGenericRepository<Category> repository;
        //Category _category = new Category();
        private Category _category;

        public HomeController()
        {
            this._category = new Category();
        }
        
        public HomeController(Category _category)
        {
            this._category = _category;
        }
        

        public ActionResult Index()
        {
            IEnumerable<Category> model = _category.GetAllCategory();
            return View(model);
        }

        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddCategory(FormCollection form)
        {
            string categoryName = form["CategoryName"];

            var model = new Category()
            {
                CategortyName = categoryName
            };
            bool success = _category.AddNewCategory(model);
            return RedirectToAction("Index");
        }

        public ActionResult EditCategory(int CategoryId)
        {
            var category = _category.GetSpecificCategory(CategoryId);
            return View(category);
        }

        [HttpPost]
        public ActionResult EditCategory(FormCollection form)
        {
            var CategoryId = int.Parse(form["CategoryId"]);

            string categoryName = form["CategoryName"];
            //var edit = new Category()
            //{
            //    Id = Convert.ToInt32(CategoryId),
            //    CategortyName = categoryName
            //};

            var cat = _category.GetSpecificCategory(CategoryId);
            cat.CategortyName = categoryName;
            _category.EditExistingCategory(cat);
            return RedirectToAction("Index", "Home");
        }

        public ActionResult DeleteCategory(int CategoryId)
        {
            _category.DeleteSpecificCategory(CategoryId);
            return RedirectToAction("Index");
        }
    }
}
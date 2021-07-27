using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Repository.Models;
using Repository.GenericRepository;

namespace TrelloApp.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category

        private IGenericRepository<Category> repository;
        Category _category = new Category();

        public CategoryController()
        {
            this.repository = new GenericRepository<Category>();
        }
        public CategoryController(IGenericRepository<Category> _repository)
        {
            this.repository = _repository;
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
        public ActionResult AddCategory(Category model)
        {
            if (ModelState.IsValid)
            {
                bool success = _category.AddNewCategory(model);
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");


        }


    }
}
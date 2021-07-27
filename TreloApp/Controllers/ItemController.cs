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
    public class ItemController : Controller
    {
        private Item _item;

        public ItemController()
        {
            this._item = new Item();
        }

        public ItemController(Item _item)
        {
            this._item = _item;
        }

        // GET: Item
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult AddItem()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddItem(FormCollection form)
        {
            var add = form["ADD"];
            var categoryId = int.Parse(form["CategoryId"]);
            var items = new Item()
            {
                ItemName = add,
                DateAdded = DateTime.Now,
                IsDone = false,
                CategoryId = categoryId
            };

            bool success = _item.AddNewItem(items);

            return RedirectToAction( "index", "Home");
        }
        public ActionResult EditItem(int ItemId)
        {
            var item = _item.GetSpecificItem(ItemId);
            return View(item);
        }

        [HttpPost]
        public ActionResult EditItem(FormCollection form)
        {
            var categoryId = int.Parse(form["categoryId"]);
            var itemId = int.Parse(form["itemId"]);
            var editName = form["Edit"];
            var ite = _item.GetSpecificItem(itemId);
            ite.ItemName = editName;
            ite.CategoryId = categoryId;
            _item.EditExistingItem(ite);

            return RedirectToAction("Index", "Home");
        }

        
        public ActionResult DeleteItem(int ItemId)
        {
            _item.DeleteSpecificItem(ItemId);
            return RedirectToAction("index", "Home");
        }

        public ActionResult Done(int ItemId)
        {
            var item = _item.GetSpecificItem(ItemId);
            
            if(item.IsDone == false)
            {
                item.IsDone = true;
                
            }
            else 
            {
                item.IsDone = false;
            }
            _item.EditExistingItem(item);
            return RedirectToAction("index", "Home");
        }

    }
}
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
    public class TaskController : Controller
    {
        private Task _task;
        private Item _item;

        public TaskController()
        {
            this._task = new Task();
            this._item = new Item();
        }

        public TaskController(Task _task)
        {
            this._task = _task;
        }

        // GET: Item
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult AddTask(int ItemId)
        {
            var item = new Item();
            item.GetSpecificItem(ItemId);
            return View(item);
        }

        [HttpPost]
        public ActionResult AddTask(FormCollection form, int ItemId)
        {
            
            var add = form["ADDTask"];
            var itemId = ItemId;
            var task = new Task()
            {
                TaskName = add,
                DateAddedTask = DateTime.Now,
                IsDoneTask = false,
                ItemId = itemId
            };

            bool success = _task.AddNewTask(task);

            return RedirectToAction("index", "Home");
        }

        public ActionResult EditTask(int TaskId)
        {
            var task = _task.GetSpecificTask(TaskId);
            return View(task);
        }

        [HttpPost]
        public ActionResult EditTask(FormCollection form)
        {
            //var categoryId = int.Parse(form["categoryId"]);
            var itemId = int.Parse(form["itemId"]);
            var taskId = int.Parse(form["taskId"]);
            var editName = form["Edit"];
            var tas = _task.GetSpecificTask(taskId);
            tas.TaskName = editName;
            tas.ItemId = itemId;
            _task.EditExistingTask(tas);

            return RedirectToAction("Index", "Home");
        }


        public ActionResult DeleteTask(int TaskId)
        {
            _task.DeleteSpecificTask(TaskId);
            return RedirectToAction("index", "Home");
        }
        public ActionResult Done(int TaskId)
        {
            var task = _task.GetSpecificTask(TaskId);

            if (task.IsDoneTask == false)
            {
                task.IsDoneTask = true;

            }
            else
            {
                task.IsDoneTask = false;
            }
            _task.EditExistingTask(task);
            return RedirectToAction("index", "Home");
        }

    }
}
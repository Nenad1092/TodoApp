using Repository.GenericRepository;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Models
{
    public class Task
    {
        private int id;
        private string taskName;
        private DateTime dateAddedTask;
        private bool isDoneTask;
        private int? itemId;

        public int Id
        {
            get { return this.id; }
            set { this.id = value; }
        }
        public string TaskName
        {
            get { return this.taskName; }
            set { this.taskName = value; }
        }
        public DateTime DateAddedTask
        {
            get { return this.dateAddedTask; }
            set { this.dateAddedTask = value; }
        }
        public bool IsDoneTask
        {
            get { return this.isDoneTask; }
            set { this.isDoneTask = value; }
        }
        public virtual int? ItemId
        {
            get { return this.itemId; }
            set { this.itemId = value; }
        }
        public Task(int _id, string _taskName, DateTime _dateAddedTask, bool _isDoneTask, int _itemId)
        {
            this.id = _id;
            this.TaskName = _taskName;
            this.DateAddedTask = _dateAddedTask;
            this.IsDoneTask = _isDoneTask;
            this.ItemId = _itemId;
        }

        // CRUD

        private IGenericRepository<Task> repository;
        public Task()
        {
            this.repository = new GenericRepository<Task>();
        }
        public Task(IGenericRepository<Task> _repository)
        {
            this.repository = _repository;
        }

        public IEnumerable<Task> GetAllTask()
        {
            return repository.GetAll().ToList();
        }

        public bool AddNewTask(Task task)
        {
            try
            {
                repository.Insert(task);
                repository.Save();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool EditExistingTask(Task task)
        {
            try
            {
                repository.Update(task);
                repository.Save();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public bool DeleteSpecificTask(int TaskId)
        {
            try
            {
                Task task = repository.GetById(TaskId);
                repository.Delete(task);
                repository.Save();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Task GetSpecificTask(int TaskId)
        {
            return repository.GetById(TaskId);
        }


    }
}
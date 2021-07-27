using Repository.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Models
{
    public class Item
    {
        private int id;
        private string? itemName;
        private DateTime dateAdded;
        private bool isDone;
        private int? categoryId;
        private ICollection<Task> tasks;

        public int Id
        {
            get { return this.id; }
            set { this.id = value; }
        }
        public string? ItemName
        {
            get { return this.itemName; }
            set { this.itemName = value; }
        }
        public DateTime DateAdded
        {
            get { return this.dateAdded; }
            set { this.dateAdded = value; }
        }
        public bool IsDone
        {
            get { return this.isDone; }
            set { this.isDone = value; }
        }

        public virtual int? CategoryId
        {
            get { return this.categoryId; }
            set { this.categoryId = value; }
        }

        public virtual ICollection<Task> Tasks
        {
            get { return this.tasks; }
            set { this.tasks = value; }
        }

        public Item(int _id, string _itemName, DateTime _dateAdded, bool _isDone, int _categoryId, IList<Task> _task)
        {
            this.id = _id;
            this.ItemName = _itemName;
            this.DateAdded = _dateAdded;
            this.isDone = _isDone;
            this.CategoryId = _categoryId;
            this.tasks = _task;
        }

       

        // CRUD

        private IGenericRepository<Item> repository;
        public Item()
        {
            this.repository = new GenericRepository<Item>();
        }
        public Item(IGenericRepository<Item> _repository)
        {
            this.repository = _repository;
        }

        public IEnumerable<Item> GetAllItem()
        {
            return repository.GetAll().ToList();
        }

        public bool AddNewItem(Item item)
        {
            try
            {
                repository.Insert(item);
                repository.Save();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool EditExistingItem(Item item)
        {
            try
            {
                repository.Update(item);
                repository.Save();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public bool DeleteSpecificItem(int ItemId)
        {
            try
            {
                Item item = repository.GetById(ItemId);
                repository.Delete(item);
                repository.Save();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Item GetSpecificItem(int ItemId)
        {
            return repository.GetById(ItemId);
        }



    }
}

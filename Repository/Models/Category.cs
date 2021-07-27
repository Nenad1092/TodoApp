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
    public class Category
    {
        private int id;
        private string categoryName;
        private ICollection<Item> items;
              
        public int Id
        {
            get { return this.id; }
            set { this.id = value; }
        }
        public string CategortyName
        {
            get { return this.categoryName; }
            set { this.categoryName = value; }
        }
        public virtual ICollection<Item> Items
        {
            get { return this.items; }
            set { this.items = value; }
        }

        public Category(int _id, string _categoryName, IList<Item> _items)
        {
            this.Id = _id;
            this.CategortyName = _categoryName;
            this.items = _items;
        }

        // CRUD

        private IGenericRepository<Category> repository;
        public Category()
        {
            this.repository = new GenericRepository<Category>();
        }
        public Category(IGenericRepository<Category> _repository)
        {
            this.repository = _repository;
        }

        public IEnumerable<Category> GetAllCategory()
        {
            return repository.GetAll().ToList();
        }

        public bool AddNewCategory(Category category)
        {
            try
            {
                repository.Insert(category);
                repository.Save();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool EditExistingCategory(Category category)
        {
            try
            {
                repository.Update(category);
                repository.Save();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public bool DeleteSpecificCategory(int CategoryId)
        {
            try
            {
                Category category = repository.GetById(CategoryId);
                repository.Delete(category);
                repository.Save();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Category GetSpecificCategory(int CategoryId)
        {
            return repository.GetById(CategoryId);
        }

    }
}

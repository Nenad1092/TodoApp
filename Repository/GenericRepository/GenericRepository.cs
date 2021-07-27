using Repository.Contex;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.GenericRepository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private TrelloDBContex _context;
        private DbSet<T> table;
        public GenericRepository()
        {
            this._context = new TrelloDBContex();
            table = _context.Set<T>();
        }
        public GenericRepository(TrelloDBContex context)
        {
            this._context = context;
            table = _context.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return table.ToList();
        }

        public T GetById(int id)
        {
            return table.Find(id);
        }

        public void Insert(T obj)
        {
            table.Add(obj);
        }
        public void Update(T obj)
        {
            table.Attach(obj);
            _context.Entry(obj).State = EntityState.Modified;
        }

        public void Delete(T obj)
        {
            table.Remove(obj);
        }
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}

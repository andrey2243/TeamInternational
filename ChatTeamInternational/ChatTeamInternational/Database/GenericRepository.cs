using ChatTeamInternational.Database.Contracts;
using ChatTeamInternational.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatTeamInternational.Database
{
    public class GenericRepository<T> : IRepository<T> where T : class, IBaseModel
    {
        ChatContext _context;
        DbSet<T> table;


        public GenericRepository(ChatContext context)
        {
            this._context = context;
            table = context.Set<T>();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public IEnumerable<T> GetAll()
        {
            return table;
        }

        public T Get(int id)
        {
            return table.SingleOrDefault(el => el.Id == id);
        }

        public void Create(T item)
        {
            table.Add(item);
            Save();

        }

        public virtual void Update(T item)
        {
           var sItem =  table.Where<T>(t => t.Id ==  item.Id);            
            Save();
        }

        public void Delete(int id)
        {
            var item = table.SingleOrDefault(el => el.Id == id);
            item = null;
            Save();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}

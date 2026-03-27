using Microsoft.EntityFrameworkCore;
using RTCWebApi.IRepository;
using RTCWebApi.Model.Entities;
using RTCWebApi.Model.Entities.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTCWebApi.Repository
{
    public class GenericRepo<T>:IGenericRepo<T>where T:class
    {
        protected RTCContext db { get; set; }
        protected DbSet<T> table = null;

        public GenericRepo()
        {
            db = new RTCContext();
            table = db.Set<T>();
        }

        public GenericRepo(RTCContext db)
        {
            this.db = db;
            table = db.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return table.ToList();
        }

        public T GetByID(int id)
        {
            return table.Find(id);
        }

        public int Create(T item)
        {
            table.Add(item);
            return db.SaveChanges();
        }

        public int Update(T item)
        {
            table.Attach(item);
            db.Entry(item).State = EntityState.Modified;
            return db.SaveChanges();
        }

        public int Delete(int id)
        {
            table.Remove(table.Find(id));
            return db.SaveChanges();
        }

        public async Task<int> CreateAsync(T item)
        {
            await table.AddAsync(item);
            return await db.SaveChangesAsync();
        }

        public async Task<int> UpdateAsync(T item)
        {
            table.Attach(item);
            db.Entry(item).State = EntityState.Modified;
            return await db.SaveChangesAsync();
        }
    }
}

using CollegeManagementSystem.Core;
using CollegeManagmentSystem.Infrastructure.Data;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace CollegeManagmentSystem.Admin
{
    public abstract class BaseAdmin<T> : IBaseAdmin<T> where T : BaseEntity
    {
        private readonly ICollegeContext _db;

        public BaseAdmin(ICollegeContext db)
        {
            _db = db;
        }

        public virtual void Add(T entity)
        {
            _db.Set<T>().Add(entity);
            _db.SaveChanges();
        }
        public virtual void Delete(int id)
        {
            var entity = _db.Set<T>().FirstOrDefault(x => x.Id == id);
            _db.Set<T>().Remove(entity);
            _db.SaveChanges();
        }
        public virtual T Get(int id) 
        {
            return _db.Set<T>().FirstOrDefault(x => x.Id == id);
        }
        public virtual IList<T> GetAll()
        {
            return _db.Set<T>().ToList();
        }
        public virtual void Update(T entity)
        {
            _db.Set<T>().Attach(entity);
            var entry = _db.Entry(entity);
            entry.State = EntityState.Modified;
            _db.SaveChanges();
        }
    }
}

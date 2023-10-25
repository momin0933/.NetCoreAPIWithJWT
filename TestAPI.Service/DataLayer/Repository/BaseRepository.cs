using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TestAPI.Core.DataLayer.Interface;
using TestAPI.Core.Models;

namespace TestAPI.Core.DataLayer.Repository
{
    public class BaseRepository : IBaseRepository
    {

        protected DbContext _db;

        public BaseRepository(DbContext db)
        {
            _db = db;
        } 

        public virtual int Add<T>(T entity, bool save = true) where T : EntityBase
        {
            _db.Set<T>().Add(entity);
            if (save)
            {
                Save();
            }
            return entity.Id;
        }
        public virtual int Update<T>(T entity, bool save = true) where T : EntityBase
        {
            _db.Set<T>().Attach(entity);
            _db.Entry(entity).State = EntityState.Modified;
            if (save)
            {
                Save();
            }
            return entity.Id;
        }
        public virtual IEnumerable<T> GetAll<T>() where T : EntityBase
        {
            return _db.Set<T>().AsEnumerable();
        }
        public virtual T GetById<T>(int id) where T : EntityBase
        {
            return _db.Set<T>().FirstOrDefault(x => x.Id == id);
        }
        public virtual bool Remove<T>(T entity, bool save = true) where T : EntityBase
        {
            _db.Set<T>().Attach(entity);
            _db.Entry(entity).State = EntityState.Deleted;
            //ctx.Set<T>().Remove(entity);
            if (save)
                return Save() > 0;
            return false;
        }
        public virtual int AddRange<T>(List<T> entity, bool save = true) where T : EntityBase
        {
            _db.Set<T>().AddRange(entity);
            if (save)
            {
                Save();
            }
            return entity.FirstOrDefault().Id;
        }
        public virtual long Save()
        {
            _db.ChangeTracker.AutoDetectChangesEnabled = false;
            return _db.SaveChanges();
        }
        
    }
}

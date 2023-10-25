using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestAPI.Core.Models;

namespace TestAPI.Core.DataLayer.Interface
{
    public interface IBaseRepository
    {
        int Add<T>(T entity, bool save = true) where T : EntityBase;
        int Update<T>(T entity, bool save = true) where T : EntityBase;
        IEnumerable<T> GetAll<T>() where T : EntityBase;
        T GetById<T>(int id) where T : EntityBase;
        bool Remove<T>(T entity, bool save = true) where T : EntityBase;
        int AddRange<T>(List<T> entity, bool save = true) where T : EntityBase;
    }
}

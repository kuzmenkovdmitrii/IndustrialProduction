using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.Repository.Interface
{
    public interface IRepository<T> : IDisposable
        where T : class
    {
        IEnumerable<T> List();
        T Get(int id);

        void Create(T item);
        void Update(T item);
        void Delete(int id);
        void Save();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.IRepositories
{
    public interface IRepositoryBase<T> where T:class
    {
        T Get(int id);
        List<T> List();
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Delete(int id);
    }
}

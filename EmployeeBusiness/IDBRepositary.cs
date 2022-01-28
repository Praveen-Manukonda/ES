using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeBusiness
{
   public interface IDBRepositary<T> where T:class
    {
        void Save(T entity);
        void Update(T entity);
        void Delete(int id);
        T GetDataById(int id);
        IEnumerable<T> GetAllData();
        IEnumerable<T> GetDataByQuery(Expression<Func<T, bool>> predicate);
        IEnumerable<T> GetDataByPagging(int pageNumber=1, int PageSize=10, string sortColumnName="", string sortOrder="ASC");

    }
}

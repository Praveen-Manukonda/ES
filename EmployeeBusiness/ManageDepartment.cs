using EmployeeDBContext;
using EmployeeModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeBusiness
{
    class ManageDepartment : IDBRepositary<Department>
    {
        EmployeeContext cntxt = null;
        public ManageDepartment()
        {
            cntxt = new EmployeeContext();
        }

        public void Save(Department entity)
        {
            try
            {
                if (entity != null)
                {
                    cntxt?.departments?.Add(entity);
                    cntxt?.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void Update(Department entity)
        {
            try
            {

                if (entity != null)
                {
                    var department = cntxt?.departments?.Where(e => e.DeptId == entity.DeptId).SingleOrDefault();
                    if (department != null)
                    {
                        department.DepartmentName = entity?.DepartmentName;
                        cntxt.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Department GetDataById(int id)
        {
            try
            {

                return cntxt?.departments?.Find(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<Department> GetDataByPagging(int pageNumber=0, int PageSize=10, string sortColumnName="", string sortOrder="ASC")
        {
            try
            {
                Func<Department, object> orderBy = null;
                switch (sortColumnName.ToString().ToUpper())
                {
                    case "LOCATION":
                        orderBy = d => d.Location;
                        break;
                    default:
                        orderBy = d=>d.DepartmentName;
                        break;
                }
                if (sortOrder == "ASC")
                    return cntxt?.departments?.OrderBy(orderBy).Skip(pageNumber * PageSize)?.Take(PageSize);
                return cntxt?.departments?.OrderByDescending(orderBy).Skip(pageNumber * PageSize)?.Take(PageSize);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<Department> GetDataByQuery(Expression<Func<Department, bool>> predicate)
        {
            try
            {
                return cntxt?.departments?.Where(predicate).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<Department> GetAllData()
        {
            try
            {
                return cntxt?.departments?.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Delete(int id)
        {
            try
            {
                cntxt?.departments?.Remove(cntxt?.departments?.Find(id));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
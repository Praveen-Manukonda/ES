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
    public class ManageEmployee : IDBRepositary<Employee>
    {
        EmployeeContext cntxt = null;
        public ManageEmployee()
        {
            try
            {
                cntxt = new EmployeeContext();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Save(Employee entity)
        {
            try
            {
                if (entity != null)
                {
                    cntxt?.employees?.Add(entity);
                    cntxt?.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update(Employee entity)
        {
            try
            {
                if (entity != null)
                {
                    var employee = cntxt?.employees?.Where(e => e.EmpId == entity.EmpId).SingleOrDefault();
                    if (employee != null)
                    {
                        employee.EmpName = entity?.EmpName;
                        employee.DateofBirth = entity.DateofBirth;
                        employee.JoiningDate = entity.JoiningDate;
                        employee.Salary = entity.Salary;
                        employee.ManagerId = entity.ManagerId;
                        employee.EmailId = entity?.EmailId;
                        employee.DeptId = entity.DeptId;
                        cntxt.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Employee GetDataById(int id)
        {
            try
            {
                return cntxt?.employees?.Find(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<Employee> GetDataByPagging(int pageNumber=0, int PageSize=10,string sortColumnName="", string sortOrder="ASC")
        {
            try
            {
               Func<Employee, object> orderBy = null;
                switch (sortColumnName.ToString().ToUpper())
                {
                    case "DATEOFBIRTH":
                        orderBy = e => e.DateofBirth;
                        break;
                    case "JOININGDATE":
                        orderBy = e => e.JoiningDate;
                        break;
                    case "EMAILID":
                        orderBy = e => e.EmailId;
                        break;
                    case "SALARY":
                        orderBy = e => e.Salary;
                        break;
                    default:
                        orderBy = e => e.EmpName;
                        break;
                }
                if (sortOrder == "ASC")
                    return cntxt?.employees?.OrderBy(orderBy).Skip(pageNumber * PageSize)?.Take(PageSize);
                return cntxt?.employees?.OrderByDescending(orderBy).Skip(pageNumber * PageSize)?.Take(PageSize);
                
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public IEnumerable<Employee> GetDataByQuery(Expression<Func<Employee, bool>> predicate)
        {
            try
            {
                return cntxt?.employees?.Where(predicate).ToList();
            }
            catch (Exception ex) { throw ex; }
        }

        public IEnumerable<Employee> GetAllData()
        {
            try
            {
                return cntxt?.employees?.ToList();
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
                cntxt?.employees?.Remove(cntxt?.employees?.Find(id));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

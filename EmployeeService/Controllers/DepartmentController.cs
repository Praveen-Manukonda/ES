using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using EmployeeBusiness;
using EmployeeModels;
using EmployeeServiceLogger;

namespace EmployeeService.Controllers
{
    public class DepartmentController : ApiController
    {
        ManageDepartment mngDepartment = null;
        public DepartmentController()
        {
            mngDepartment = new ManageDepartment();
        }
        public void SaveDepartment(Department dept)
        {
            try
            {
                mngDepartment.Save(dept);
            }
            catch (Exception ex)
            {
                NLogger.Error(ex , $"Expection in SaveDepartment {ex.Message.ToString()}");
            }
        }

       public void UpdateDepartment(Department dept)
        {
            try
            {
                mngDepartment.Update(dept);
            }
            catch (Exception ex)
            {
                NLogger.Error(ex, $"Expection in UpdateDepartment {ex.Message.ToString()}");
            }
        }

        public List<Department> GetAllDepartments()
        {
            List<Department> departments = null;
            try
            {
                departments = mngDepartment.GetAllData().ToList();
            }
            catch (Exception ex)
            {
                NLogger.Error(ex, $"Expection in GetAllDepartments {ex.Message.ToString()}");
            }
            return departments;
        }

        public Department GetDepartmentById(int id)
        {
            Department department = null;
            try
            {
                department = mngDepartment.GetDataById(id);
            }
            catch (Exception ex)
            {
                NLogger.Error(ex, $"Expection in GetDepartmentById {ex.Message.ToString()}");
            }
            return department;
        }

        public List<Department> GetDepartmentByPagging(int pageNumber= 0, int pageSize = 10, string sortColumn="", string sortOrder = "")
        {
            List<Department> departments = null;
            try
            {
                departments = mngDepartment.GetDataByPagging(pageNumber,pageSize,sortColumn,sortOrder).ToList();
            }
            catch (Exception ex)
            {
                NLogger.Error(ex, $"Expection in GetDepartmentByPagging {ex.Message.ToString()}");
            }
            return departments;
        }
    }
}
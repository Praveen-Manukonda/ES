using EmployeeBusiness;
using EmployeeModels;
using EmployeeService.Models;
using EmployeeServiceLogger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace EmployeeService.Controllers
{
    public class EmployeeController : ApiController
    {
        ManageEmployee manageEmployee = null;
        public EmployeeController()
        {
            manageEmployee = new ManageEmployee();
        }

        [System.Web.Http.HttpPost]
        public void SaveEmployee(Employee employee)
        {
            try
            {
                manageEmployee.Save(employee);
            }
            catch (Exception ex)
            {
                NLogger.Error(ex, $"Exception on saving Employee {ex.Message}");
            }
        }

        [System.Web.Http.HttpPut]
        public void UpdateEmployee(Employee employee)
        {
            try
            {
                manageEmployee.Update(employee);
            }
            catch (Exception ex)
            {
                NLogger.Error(ex, $"Exception on updating Employee {ex.Message}");
            }
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            List<Employee> lstEmployees = null;
            try
            {
                lstEmployees = manageEmployee.GetAllData()?.ToList();
            }
            catch (Exception ex)
            {
                NLogger.Error(ex, $"Exception on Getting ALL Employee {ex.Message}");
            }
            return lstEmployees;
        }

        public Employee GetEmployeeById(int id)
        {
            Employee employee = null;
            try
            {
                employee = manageEmployee.GetDataById(id);
            }
            catch (Exception ex)
            {
                NLogger.Error(ex, $"Exception on Getting  Employee by Id {ex.Message}");
            }
            return employee;
        }

        public IEnumerable<Employee> GetEmployeeUsingPagging(int pageNumber=0, int pageSize =10, string columnName="empname", string order="ASC")
        {
            List<Employee> employees = null;
            try
            {
                employees = manageEmployee.GetDataByPagging(pageNumber, pageSize,columnName,order)?.ToList();
            }
            catch (Exception ex)
            {
                NLogger.Error(ex, $"Exception on Getting  dating by pagging{ex.Message}");
            }
            return employees;
        }
    }
}
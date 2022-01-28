using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeDBContext;
using EmployeeModels;
using EmployeeBusiness;
using EmployeeServiceLogger;

namespace TestEmployeeService
{
    class Program
    {
       static IDBRepositary<Employee> empDB = new ManageEmployee();
        private static void SaveData()
        {
            try
            {
                Employee employee = new Employee();
                employee.EmpName = "test Data";
                employee.DateofBirth = DateTime.Now;
                employee.JoiningDate = DateTime.Now;
                employee.Salary = 10000;
                employee.ManagerId = 2;
                employee.EmailId = "pra@gmail.com";
                employee.DeptId = 1;
                empDB.Save(employee);
            }
            catch (Exception ex)
            {
                NLogger.Error(ex, $"Exception in Saving Employee Data : {ex.Message}");
            }
        }

        private static void UpdateData()
        {
            try
            {
                //get data y id
                var emp = empDB.GetDataById(1);
                //update Data
                emp.EmpName = "test Data updated 2";
                empDB.Update(emp);
            }
            catch (Exception ex)
            {
                NLogger.Error(ex,$"Exception in Updating Emloyee Data : {ex.Message}");
               
            }
        }

        private static void GetDataByPage()
        {
            try
            {
               // var employees = empDB.GetDataByPagging(1, 10, e=>e.EmpName);
            }
            catch (Exception ex)
            {
                NLogger.Error(ex, $"Exception in Get Data By Page for Employee: {ex.Message}");
              
            }
        }

        static void Main(string[] args)
        {
            GetDataByPage();
            Console.ReadLine();
        }
    }
}
   
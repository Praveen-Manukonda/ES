using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeModels;

namespace EmployeeDBContext
{
    public class EmployeeContext : DbContext
    {
        public EmployeeContext() : base(ConfigurationManager.ConnectionStrings["EmployeeDBConnectionString"].ToString())
        { }
        public DbSet<Department> departments { get; set; }
        public DbSet<Employee> employees { get; set; }

    }
}


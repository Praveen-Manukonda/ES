using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeModels
{
	[Table(name: "tbl_Employee")]
	public class Employee
	{
		[Key]
		public int EmpId { get; set; }
		[Required(ErrorMessage = "Name is Required")]
		[MaxLength(200)]
		public string EmpName { get; set; }
		[Required(ErrorMessage = "DOB is Required")]
		public DateTime DateofBirth { get; set; }
		[Required(ErrorMessage ="Joining Date is Required")]
		public DateTime JoiningDate { get; set; }
		[Required(ErrorMessage ="Salary is Required")]
		public float Salary { get; set; }
		public int ManagerId { get; set; }
		[Required(ErrorMessage = "Salary is Required")]
		[EmailAddress(ErrorMessage ="Please provide valid Email Address")]
		public string EmailId { get; set; }
		public int DeptId { get; set; }
		public virtual Department department { get; set; }
	}
}

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
	[Table(name: "tbl_Dept")]
	public class Department
	{
		[Key]
		public int DeptId { get; set; }
		[Required (ErrorMessage = "Department Name is Required")]
		[DisplayName("Dept Name")]
		[StringLength(maximumLength:200)]
		public string DepartmentName { get; set; }
		[Required (ErrorMessage ="Location is Required")]
		public string Location { get; set; }
	}
}

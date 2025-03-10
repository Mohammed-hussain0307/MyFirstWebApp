using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyFirstWebApp.Models
{
	public class EmployeeModel
	{
		[Key]
		public int EmployeeId { get; set; }

		[Required]
		public string EmployeeName { get; set; }
		public string Designation { get; set; }
		public decimal Salary { get; set; }
	}
}
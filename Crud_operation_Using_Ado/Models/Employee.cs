using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Crud_operation_Using_Ado.Models
{
    public class Employee
    {
        public int Emp_id { get; set; }
        [Required]
        public string Emp_name { get; set; }
        [Required]
        public string Emp_gender { get; set; }
        [Required]
        public int Empage { get; set; }
        [Required]
        public int Empsalary { get; set; }
        [Required]
        public string Empcity { get; set; }
    }
}
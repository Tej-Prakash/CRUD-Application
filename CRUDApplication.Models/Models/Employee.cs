using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDApplication.Models.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string EmpName { get; set; }
        public string Designation { get; set; }
        public DateTime Doj { get; set; }
        public int DepartmentId { get; set; }
        public double Salary { get; set; }
        public int? ManagerId { get; set; }

       
    }
}

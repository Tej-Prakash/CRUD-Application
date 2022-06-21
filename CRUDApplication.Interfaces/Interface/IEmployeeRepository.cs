using CRUDApplication.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDApplication.Interfaces.Interface
{
    public interface IEmployeeRepository
    {
        public List<Employee> GetAllEmployees();
        public Employee GetById(int EmployeeID);
        public bool Insert(Employee employee);
        public bool Update(Employee employee);
        public bool Delete(int EmployeeID);
        public void Save();
        public List<Department> GetAllDepartment();
    }
}

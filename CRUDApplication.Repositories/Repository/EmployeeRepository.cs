using CRUDApplication.Data.EmployeeDbContext;
using CRUDApplication.Interfaces.Interface;
using CRUDApplication.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDApplication.Repositories.Repository
{    
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly employeedbContext _context;
        public EmployeeRepository(employeedbContext context)
        {
            _context = context;
        }
        public bool Delete(int EmployeeID)
        {
            var result = false;
            var emp = _context.Employees.Where(x=>x.Id==EmployeeID).FirstOrDefault();
            _context.Remove(emp);
            var status = _context.SaveChanges();
            result=(status==1)?true:false;
            return result;

        }

        public List<Department> GetAllDepartment()
        {
            var dept = _context.Departments.ToList();
            return dept;
        }

        public List<Employee> GetAllEmployees()
        {
            var employees = _context.Employees.ToList();
            return employees; 
        }

        public Employee GetById(int EmployeeID)
        {
            var emp=_context.Employees.Where(x=>x.Id==EmployeeID).FirstOrDefault();
            return emp;
        }

        public bool Insert(Employee employee)
        {
            _context.Employees.Add(employee);
            var status= _context.SaveChanges();
            var result=(status==1)?true:false;
            return result;
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public bool Update(Employee employee)
        {
            var _status = 0;
            var emp=(from e in _context.Employees.Where (x=>x.Id==employee.Id) select e).First();
            if(emp!=null)
            {
                emp.Doj = employee.Doj;
                emp.Salary = employee.Salary;
                emp.DepartmentId=employee.DepartmentId;
                emp.Designation=employee.Designation;
                emp.EmpName = employee.EmpName;
                emp.ManagerId = employee.ManagerId;
            }
            _context.Employees.Update(emp);
            _status=_context.SaveChanges();
            var result=(_status==1)?true:false;
            return result;
        }
    }
}

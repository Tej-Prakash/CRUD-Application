﻿using CRUDApplication.Interfaces.Interface;
using CRUDApplication.Models;
using CRUDApplication.Models.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net;

namespace CRUDApplication.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private IEmployeeRepository _employeeRepository;
        private readonly IJWTManagerRepository _jWTManager;
        //public EmployeeController()
        //{
           
        //}
        public EmployeeController(IEmployeeRepository employeeRepository, IJWTManagerRepository jWTManager)
        {
            _employeeRepository = employeeRepository;
            _jWTManager = jWTManager;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("authenticate")]
        public IActionResult Authenticate(Users usersdata)
        {
            var token = _jWTManager.Authenticate(usersdata);

            if (token == null)
            {
                return Unauthorized();
            }

            return Ok(token);
        }

        [Route("GetAllEmployees")]
        [HttpGet]
        public IActionResult GetAllEmployees()
        {
            var emp = _employeeRepository.GetAllEmployees();

            return Ok(emp);
        }

        [Route("Departments")]
        [HttpGet]
        public IActionResult Departments()
        {
            var dept = _employeeRepository.GetAllDepartment();

            return new JsonResult(dept);
        }

        [Route("GetEmployeOnId/{id}")]
        [HttpGet]
        public IActionResult GetEmployeOnId(int id)
        {
            try
            {
                var emp = _employeeRepository.GetById(id);
                if (emp == null)
                {
                    return NotFound("Invalid Id.");
                }
                
                return Ok(emp);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [Route("UpdateEmployeeDetails")]
        [HttpPut]
        public IActionResult UpdateEmployeeDetails(Employee employee)
        {
            var updateStatus = _employeeRepository.Update(employee);
            if (updateStatus == true)
            {
                return Ok("Employee Record Updated Sucessfully.");
            }
            else
            {
                return Ok("Failed to update employee record.");
            }          
        }
        [Route("AddNewEmployee")]
        [HttpPost]
        public IActionResult AddNewEmployee(Employee employee)
        {
            var status = _employeeRepository.Insert(employee);
            if (status == true)
            {
                return Ok("Record saved successfully.");
            }
            else
            {
                return BadRequest("Invalid Record. Failed to save employee data.");
            }            
        }
        [Route("DeleteEmployee/{id}")]
        [HttpDelete]
        public IActionResult DeleteEmployee(int id)
        {
            var status = _employeeRepository.Delete(id);
            if(status == true)
            {
                return Ok("Record deleted successfully.");
            }
            else
            {
                return BadRequest("Invalid employee id");
            }
        }        
    }
}

﻿using FirstWebApi.EmployeeData;
using FirstWebApi.Json;
using FirstWebApi.Models;
using FirstWebApi.Services;
using FirstWebApi.StudentData;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Xml;

namespace FirstWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        [HttpGet]
        public IList<Employee> GetEmployeesDetails()
        {
            var employeeList = StoreData.GetEmployeeData();
            return employeeList;
        }
        [HttpGet("employee/{id}")]
        public IActionResult GetEmployee(int id)
        {
            try
            {
                var serviceObj= new EmployeeService();
                
                return Ok(serviceObj.GetEmployee(id));
            }
            catch (Exception ex)
            {

                return NotFound(ex.Message);
            }
            
        }
        [HttpGet("student")]
        public IList<Student> GetStudentDetails()
        {
            return StudentData.StudentDetails.studentdata;
        }
        [HttpGet("Student/{id}")]
        public Student GetStudent(int id)
        {
            var student = StudentDetails.studentdata.FirstOrDefault(x => x.Id == id);
            if (student == null)
            {
                throw new Exception();
            }
            return student;
        }
        [HttpPost("employee")]
        public IActionResult AddEmployees(Employee inputRequest) 
        {
            try
            {
                var serviceObj = new EmployeeService();

                return Ok(serviceObj.CreateEmployees(inputRequest));
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
            
        }

    }
}

using Eyouth_APIs.DTOs;
using Eyouth_APIs.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Eyouth_APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly AppDbContext context;

        public EmployeeController(AppDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var emps = context.Employees.ToList();
            return Ok(emps);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id) 
        {
            var emp = context.Employees.Include(em=>em.Department).FirstOrDefault(e=>e.Id==id);

            var dto = new EmployeeWithDept();
            dto.Id = id;
            dto.Name = emp.Name;
            dto.Salary = emp.Salary;
            dto.DeptName = emp.Department.Name;

            return Ok(dto);//DTO === Data Transfer Object === View Model
        }
    }
}

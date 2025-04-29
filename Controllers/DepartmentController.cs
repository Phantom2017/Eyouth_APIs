using Eyouth_APIs.DTOs;
using Eyouth_APIs.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Eyouth_APIs.Controllers
{
    [Route("api/[controller]")]///api/Department
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly AppDbContext context;

        public DepartmentController(AppDbContext context)
        {
            this.context = context;
        }
        [HttpGet]
        public IActionResult getAll()
        {
            var depts = context.Departments.ToList();
            return Ok(depts);
        }

        [HttpGet("{id:int}")]
        //[Route("{id}")]///api/Department/id
        public IActionResult get(int id)
        {
            var dept = context.Departments.Include(d=>d.Employees).FirstOrDefault(d => d.Id == id);

            var dto = new DeptWithEmps();
            dto.Id = id;
            dto.Name = dept.Name;
            dto.Emps = new List<string>();

            foreach (var emp in dept.Employees)
            {
                dto.Emps.Add(emp.Name);
            }

            return Ok(dto);
        }

        [HttpGet("{name:alpha}")]//api/Department/mgr/{name}
        //route,Query ===> primitive data
        //Body ====> Complex obj
        public IActionResult GetByName([FromRoute]string name) 
        {
            var dept = context.Departments.FirstOrDefault(d => d.Name==name);
            return Ok(dept);
        }


        [HttpPost]
        [Authorize]
        public IActionResult Create(Department dept)
        {
            if (ModelState.IsValid)
            {
                context.Departments.Add(dept);
                context.SaveChanges();
                return Created();
            }
            //return BadRequest("Data is wrong");
            return BadRequest(ModelState);
        }

        [HttpPut]
        public IActionResult Edit(int id,Department newDept)
        {
            if (ModelState.IsValid)
            {
                var dept = context.Departments.Find(id);

                dept.Name=newDept.Name;
                dept.MgrName=newDept.MgrName;

                context.SaveChanges();
                return Ok();
            }
            else
                return BadRequest(ModelState);
        }

        [HttpDelete]
        public IActionResult Delete(int id) 
        {
            var dept= context.Departments.Find(id);
            context.Departments.Remove(dept);
            context.SaveChanges();
            return Ok();
        }
    }
}

using Eyouth_APIs.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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

        [HttpGet]
        [Route("{id}")]///api/Department/id
        public IActionResult get(int id)
        {
            var dept = context.Departments.FirstOrDefault(d => d.Id == id);
            return Ok(dept);
        }

        [HttpPost]
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
    }
}

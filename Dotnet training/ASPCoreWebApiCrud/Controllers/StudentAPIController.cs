using ASPCoreWebApiCrud.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ASPCoreWebApiCrud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentAPIController : ControllerBase
    {
        private readonly StudentDbContext context;

        public StudentAPIController(StudentDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task <ActionResult<List<Student>>> GetStudebts()
        {
            var data = await context.Students.ToListAsync();
            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> GetStudentById(int id)
        {
            var student = await context.Students.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            return student;
        }

        [HttpPost]
        public async Task<ActionResult<Student>> CreateStudent(Student student)
        {
            Console.WriteLine("Hello from the post method of create student");
            await context.Students.AddAsync(student);
            await context.SaveChangesAsync();
            return Ok(student);
        }
    }
}

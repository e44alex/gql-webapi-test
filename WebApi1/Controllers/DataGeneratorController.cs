using Microsoft.AspNetCore.Mvc;
using WebApi.Data.Fakers;
using WebApi.Domain;
using WebApi1.Models;

namespace WebApi1.Controllers
{
    [Microsoft.AspNetCore.Components.Route("api/[controller]")]
    [ApiController]
    public class DataGeneratorController : ControllerBase
    {
        private readonly WebApiDbContext _context;

        public DataGeneratorController(WebApiDbContext context)
        {
            _context = context;
        }

        [HttpPost, Route("students")]
        public async Task<ActionResult<List<Student>>> GenerateStudents([FromBody] GenerateModel model)
        {
            if (model.DropExisting)
            {
                _context.Students.RemoveRange(_context.Students);
            }

            List<Student>? students = DataFakers.StudentFaker.Generate(model.Count);

            if (students.Any())
            {
                _context.Students.AddRange(students);
            }

            await _context.SaveChangesAsync();

            return Ok(students);
        }

        [HttpPost, Route("messages")]
        public async Task<ActionResult<List<Message>>> GenerateMessages([FromBody] GenerateModel model)
        {
            if (model.DropExisting)
            {
                _context.Messages.RemoveRange(_context.Messages);
            }

            List<Message>? messages = DataFakers.MessageFaker.Generate(model.Count);

            if (messages.Any())
            {
                _context.Messages.AddRange(messages);
            }

            await _context.SaveChangesAsync();

            return Ok(messages);
        }
    }
}

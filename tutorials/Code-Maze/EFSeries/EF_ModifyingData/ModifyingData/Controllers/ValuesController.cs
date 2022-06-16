using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ModifyingData
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {

        private readonly ApplicationContext _context;

        public ValuesController(ApplicationContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_context.Students);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Student student)
        {
            if (student == null)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest();

            
            _context.Add(student);
            _context.SaveChanges();
            return Created("URI of the created entity", student);
        }

        [HttpPut("{id}")]
        public IActionResult PUT(Guid id, [FromBody] Student student)
        {
            var dbStudent = _context.Students
                .FirstOrDefault(s => s.Id.Equals(id));
            dbStudent.Age = student.Age;
            dbStudent.Name = student.Name;
            dbStudent.IsRegularStudent = student.IsRegularStudent;

            var isAgeModified = _context.Entry(dbStudent).Property("Age").IsModified;
            var isNameModified = _context.Entry(dbStudent).Property("Name").IsModified;
            var isIsRegularStudentModified = _context.Entry(dbStudent).Property("IsRegularStudent").IsModified;

            _context.SaveChanges();
            return NoContent();
        }

        [HttpPost("postrange")]
        public IActionResult PostRange([FromBody] IEnumerable<Student> students)
        {
            //additional checks
            _context.AddRange(students);
            _context.SaveChanges();
            return Created("URI is going here", students);
        }

        [HttpPut("{id}/relationship")]
        public IActionResult UpdateRelationship(Guid id, [FromBody] Student student)
        {
            var dbStudent = _context.Students
                .Include(s => s.StudentDetails)
                .FirstOrDefault(s => s.Id.Equals(id));
            dbStudent.Age = student.Age;
            dbStudent.Name = student.Name;
            dbStudent.IsRegularStudent = student.IsRegularStudent;
            dbStudent.StudentDetails.AdditionalInformation = "Additional information updated";
            _context.SaveChanges();
            return NoContent();
        }

        [HttpPut("{id}/relationship2")]
        public IActionResult UpdateRelationhip2(Guid id, [FromBody] Student student)
        {
            var dbStudent = _context.Students
                .FirstOrDefault(s => s.Id.Equals(id));
            dbStudent.StudentDetails = new StudentDetails
            {
                Id = new Guid("e2a3c45d-d19a-4603-b983-7f63e2b86f14"),
                Address = "added address",
                AdditionalInformation = "Additional information for student 2"
            };
            _context.SaveChanges();
            return NoContent();
        }

        [HttpPut("disconnected")]
        public IActionResult UpdateDisconnected([FromBody] Student student)
        {
            _context.Students.Attach(student);
            _context.Entry(student).State = EntityState.Modified;
            _context.SaveChanges();
            return NoContent();
        }

        [HttpPut("disconnected2")]
        public IActionResult UpdateDisconnected2([FromBody] Student student)
        {
            _context.Update(student);
            _context.SaveChanges();
            return NoContent();
        }

        
    }

    [Route("api/delete")]
    [ApiController]
    public class DeleteController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public DeleteController(ApplicationContext context)
        {
            _context = context;
        }


        [HttpDelete("soft/{id}")]
        public IActionResult DeleteSoft(Guid id)
        {
            var student = _context.Students
                .FirstOrDefault(s => s.Id.Equals(id));
            if (student == null)
                return BadRequest();
            student.Deleted = true;
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var student = _context.Students
                .FirstOrDefault(s => s.Id.Equals(id));
            if (student == null)
                return BadRequest();
            _context.Remove(student);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{relationship/{id}")]
        public IActionResult DeleteRelationships(Guid id)
        {
            var student = _context.Students
                .Include(s => s.StudentDetails)
                .FirstOrDefault(s => s.Id.Equals(id));
            if (student == null)
                return BadRequest();
            _context.Remove(student);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
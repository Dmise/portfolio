using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EF_queries.Controllers
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
        [Route("EagerLoading_1")]

        public IActionResult Eager_1()
        {
            // Eager Loading
            var students = _context.Students
           .AsNoTracking()
           .Where(s => s.Age > 25)
           .ToList();

            return Ok(students);
        }

        [HttpGet]
        [Route("EagerLoading_2")]
        public IActionResult Eager_2()
        {
            // Eager Loading

            var students = _context.Students
                 .Include(e => e.Evaluations)
                 .FirstOrDefault();

            return Ok(students);
        }

        [HttpGet]
        [Route("EagerLoading_3")]
        public IActionResult Eager_3()
        {
            // Eager Loading
            var students = _context.Students
                .Include(e => e.Evaluations)
                .Include(ss => ss.StudentSubjects)
                .ThenInclude(s => s.Subject)
                .FirstOrDefault();

            return Ok(students);
        }

        [HttpGet]
        [Route("Explicit_1")]
        public IActionResult Explicit_1()
        {
            //Explicit Loading
            var student = _context.Students.FirstOrDefault();
            _context.Entry(student)
                .Collection(e => e.Evaluations)
                .Load();
            _context.Entry(student)
                .Collection(ss => ss.StudentSubjects)
                .Load();
            foreach (var studentSubject in student.StudentSubjects)
            {
                _context.Entry(studentSubject)
                    .Reference(s => s.Subject)
                    .Load();
            }


            return Ok(student);
        }

        [HttpGet]
        [Route("Explicit_2")]
        public IActionResult Explicit_2()
        {
            //Explicit Loading Query request
            
             var student = _context.Students.FirstOrDefault();
            var evaluationsCount = _context.Entry(student)
                .Collection(e => e.Evaluations)
                .Query()
                .Count();
            var gradesPerStudent = _context.Entry(student)
                .Collection(e => e.Evaluations)
                .Query()
                .Select(e => e.Grade)
                .ToList();
            


            return Ok(student);
        }



        [HttpGet]
        [Route("Select")]
        public IActionResult Get()
        {                    
            //Select (Projection) Loading
            //This way we project only the data that we want to return in a response.
            var student = _context.Students
            .Select(s => new
            {
                s.Name,
                s.Age,
                NumberOfEvaluations = s.Evaluations.Count
            })
            .ToList();

            return Ok(student);
        }

        [HttpGet]
        [Route("ServerEvaluation")]
        public IActionResult Get_ClientVsServerEvaluation()
        {
            //Client vs Server Evaluation
            var student = _context.Students
            .Where(s => s.Name.Equals("John Doe"))
            .Select(s => new
            {
                s.Name,
                s.Age,
                Explanations = string.Join(",", s.Evaluations
                    .Select(e => e.AdditionalExplanation))
            })
            .FirstOrDefault();


            return Ok(student);
        }

        [HttpGet]
        [Route("RawSQL")]
        public IActionResult Get_RawSQL()
        {
            //raw sql
            var student = _context.Students
            .FromSqlRaw(@"SELECT * FROM Student WHERE Name = {0}", "John Doe")
            .FirstOrDefault();

            var student2 = _context.Students
            .FromSqlRaw("SELECT * FROM Student WHERE Name = {0}", "John Doe")
            .Include(e => e.Evaluations)
            .FirstOrDefault();

            return Ok(new { student, student2 });
        }


        [HttpGet]
        [Route("ExecuteRawSql")]

        public IActionResult Get_ExecuteRawSQL()
        {
            //execute raw sql   //@ - using string interpolation
            var rowsAffected = _context.Database
            .ExecuteSqlRaw(
                @"UPDATE Student
                  SET Age = {0} 
                  WHERE Name = {1}", 29, "Mike Miles");
            return Ok(new { RowsAffected = rowsAffected });
        }

        [HttpGet]
        [Route("Reload")]

        public IActionResult Reload()
        {
            var studentForUpdate = _context.Students
                 .FirstOrDefault(s => s.Name.Equals("Mike Miles"));
            var age = 28;

            var rowsAffected = _context.Database
                .ExecuteSqlRaw(@"UPDATE Student 
                       SET Age = {0} 
                       WHERE Name = {1}", age, studentForUpdate.Name);


            _context.Entry(studentForUpdate).Reload();

            return Ok(new { RowsAffected = rowsAffected });
        }


    }
}
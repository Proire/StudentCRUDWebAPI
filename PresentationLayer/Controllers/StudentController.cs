using BusinessLayer.Interface;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using ModelLayer;

namespace PresentationLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
            private readonly IStudentService studentService;
            public StudentController(IStudentService studentService)
            {
                this.studentService = studentService;
            }
            
            // GET: api/<StudentController>
            [HttpGet]
            public IActionResult GetStudents()
            {
                var students = studentService.GetAllStudents();
                if (students == null) { return NotFound("No Students Found"); }
                return Ok(students);
            }

            // GET api/<StudentController>/5
            [HttpGet("{id}")]
            public IActionResult GetOneStudent(int id)
            {
                var student = studentService.GetStudent(id);
                if (student == null) { return NotFound("No Student with such Id Found"); }
                return Ok(student);
            }

            // POST api/<StudentController>
            [HttpPost]
            public IActionResult PostStudent([FromBody] StudentModel Studentmodel)
            {
                 var student = studentService.AddStudent(Studentmodel);
                 if (student == null) { return NotFound("Not able to Add Student"); }
                 return Ok(student);
            }

            // PUT api/<StudentController>/5
            [HttpPut("{id}")]
            public IActionResult EditStudent(int id,[FromBody] StudentModel Studentmodel)
            {
                var student = studentService.UpdateStudent(id,Studentmodel);
            if (student == null) { return NotFound("Not able to Edit Student"); }
                return Ok(student);
            }

            // DELETE api/<StudentController>/5
            [HttpDelete("{id}")]
            public IActionResult RemoveStudent(int id)
            {
                var student = studentService.DeleteStudent(id);
            if (student == null) { return NotFound("Not able to Remove Student"); }
                return Ok(student);
            }
    }
}

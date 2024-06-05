using BusinessLayer.Interface;
using Microsoft.AspNetCore.Mvc;
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
            public IEnumerable<StudentModel> GetStudents()
            {
                return studentService.GetAllStudents();
            }

            // GET api/<StudentController>/5
            [HttpGet("{id}")]
            public StudentModel GetOneStudent(int id)
            {
                return studentService.GetStudent(id);
            }

            // POST api/<StudentController>
            [HttpPost]
            public StudentModel PostStudent([FromBody] StudentModel Studentmodel)
            {
                return studentService.AddStudent(Studentmodel);
            }

            // PUT api/<StudentController>/5
            [HttpPut("{id}")]
            public StudentModel EditStudent(int id,[FromBody] StudentModel Studentmodel)
            {
                return studentService.UpdateStudent(id,Studentmodel);
            }

            // DELETE api/<StudentController>/5
            [HttpDelete("{id}")]
            public StudentModel RemoveStudent(int id)
            {
                return studentService.DeleteStudent(id);
            }
        }
}

using BusinessLayer.Interface;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using ModelLayer;
using RepositoryLayer.Exceptions;

namespace PresentationLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
            private readonly IStudentService studentService;
            private readonly ResponseModel responseModel;
            public StudentController(IStudentService studentService)
            {
                this.studentService = studentService;
                this.responseModel = new ResponseModel();
            }
            
            // GET: api/<StudentController>
            [HttpGet]
            public ResponseModel GetStudents()
            {
                try
                {
                    var students = studentService.GetAllStudents();
                    responseModel.message = "Students retrieved successfully.";
                    string studentsAsString = string.Join(" | ", students.Select(s => s.ToString()));
                responseModel.data = studentsAsString;
                }
                catch (UserException e) 
                {
                    responseModel.message = e.Message;
                    responseModel.status = false;
                    responseModel.data = "No Data Found";
                }
            return responseModel;
            }

        // GET api/<StudentController>/5
        [HttpGet("{id}")]
        public ResponseModel GetOneStudent(int id)
        { 
            try
            {
                var student = studentService.GetStudent(id);
                responseModel.message = "Student retrieved successfully.";
                responseModel.data = student.ToString();
            }
            catch (UserException e)
            {
                responseModel.message = e.Message;
                responseModel.status = false;
                responseModel.data = null;
            }
            return responseModel;
        }

            // POST api/<StudentController>
        [HttpPost]
        public ResponseModel PostStudent([FromBody] StudentModel Studentmodel)
        {
            try
            {
                var student = studentService.AddStudent(Studentmodel);
                responseModel.message = "Student Added successfully.";
                responseModel.data = student.ToString();
            }
            catch (UserException e)
            {
                responseModel.message = e.Message;
                responseModel.status = false;
                responseModel.data = null;
            }
            return responseModel;

        }

            // PUT api/<StudentController>/5
        [HttpPut("{id}")]
        public ResponseModel EditStudent(int id,[FromBody] StudentModel Studentmodel)
        {
            try
            {
                var student = studentService.UpdateStudent(id, Studentmodel);
                responseModel.message = "Student Edited successfully.";
                responseModel.data = student.ToString();
            }
            catch (UserException e)
            {
                responseModel.message = e.Message;
                responseModel.status = false;
                responseModel.data = null;
            }
            return responseModel;
        }

            // DELETE api/<StudentController>/5
        [HttpDelete("{id}")]
        public ResponseModel RemoveStudent(int id)
        {
            try
            {
                var student = studentService.DeleteStudent(id);
                responseModel.message = "Student Deleted successfully.";
                responseModel.data = student.ToString();
            }
            catch (UserException e)
            {
                responseModel.message = e.Message;
                responseModel.status = false;
                responseModel.data = null;
            }
            return responseModel;
        }
    }
}

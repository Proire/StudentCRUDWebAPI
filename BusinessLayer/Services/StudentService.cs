using BusinessLayer.Interface;
using Microsoft.IdentityModel.Tokens;
using ModelLayer;
using RepositoryLayer.Entities;
using RepositoryLayer.Exceptions;
using RepositoryLayer.Interface;

namespace BusinessLayer.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository studentRepository;
        public StudentService(IStudentRepository studentRepository)
        {
            this.studentRepository = studentRepository;
        }
       
        public IEnumerable<StudentModel> GetAllStudents()
        {
            List<Student> currentstudents = null;
            try
            {
                currentstudents = studentRepository.GetAllStudents().ToList();
            }
            catch (UserException e) { 
                Console.WriteLine(e.Message);
                throw;
            }
            List<StudentModel> students = null;
            if (!currentstudents.IsNullOrEmpty())
            {
                students = new List<StudentModel>();
                foreach (Student student in currentstudents)
                {
                    students.Add(new StudentModel(student.Name, student.Address, student.Email));
                }
            }
            return students;
        }

        public StudentModel GetStudent(int id)
        {
            Student student = null;
            try
            {
                student = studentRepository.GetStudent(id);
            }
            catch (UserException e) {
                Console.WriteLine(e.Message);
                throw;
            }
            StudentModel model = null;
            if (student != null)
                model = new StudentModel(student.Name, student.Address, student.Email);
            return model;
        }
       
        public StudentModel AddStudent(StudentModel studentModel)
        {
            Student student = new Student(studentModel.Name, studentModel.Address, studentModel.Email);
            Student Addedstudent = null;
            try
            {
                Addedstudent = studentRepository.AddStudent(student);
            }
            catch(UserException e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
            if(Addedstudent != null)
                return new StudentModel(Addedstudent.Name, Addedstudent.Address, Addedstudent.Email);
            return null;
        }

        public StudentModel UpdateStudent(int id,StudentModel studentModel)
        {
            Student student = new Student(studentModel.Name, studentModel.Address, studentModel.Email);
            Student updatedstudent = null;
            try
            {
                updatedstudent = studentRepository.UpdateStudent(id, student);
            }
            catch(UserException e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
            if(updatedstudent != null)
                return new StudentModel(updatedstudent.Name, updatedstudent.Address, updatedstudent.Email);
            return null;
        }

        public StudentModel DeleteStudent(int id)
        {
            Student deletedstudent = null;
            try
            {
                deletedstudent = studentRepository.DeleteStudent(id);
            }
            catch (UserException e)
            {
                Console.WriteLine(e.Message);  
                throw;
            }
            if(deletedstudent != null)
                return new StudentModel(deletedstudent.Name, deletedstudent.Address, deletedstudent.Email);
            return null;
        }
    }
}

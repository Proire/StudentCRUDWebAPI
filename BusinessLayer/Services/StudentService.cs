using BusinessLayer.Interface;
using Microsoft.IdentityModel.Tokens;
using ModelLayer;
using RepositoryLayer.Entities;
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
            var currentstudents = studentRepository.GetAllStudents();
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
            Student student = studentRepository.GetStudent(id);
            StudentModel model = null;
            if (student != null)
                model = new StudentModel(student.Name, student.Address, student.Email);
            return model;
        }
       
        public StudentModel AddStudent(StudentModel studentModel)
        {
            Student student = new Student(studentModel.Name, studentModel.Address, studentModel.Email);
            Student Addedstudent = studentRepository.AddStudent(student);
            if(Addedstudent != null)
                return new StudentModel(Addedstudent.Name, Addedstudent.Address, Addedstudent.Email);
            return null;
        }

        public StudentModel UpdateStudent(int id,StudentModel studentModel)
        {
            Student student = new Student(studentModel.Name, studentModel.Address, studentModel.Email);
            Student updatedstudent = studentRepository.UpdateStudent(id,student);
            if(updatedstudent != null)
                return new StudentModel(updatedstudent.Name, updatedstudent.Address, updatedstudent.Email);
            return null;
        }

        public StudentModel DeleteStudent(int id)
        {
            Student deletedstudent = studentRepository.DeleteStudent(id);
            if(deletedstudent != null)
                return new StudentModel(deletedstudent.Name, deletedstudent.Address, deletedstudent.Email);
            return null;
        }
    }
}

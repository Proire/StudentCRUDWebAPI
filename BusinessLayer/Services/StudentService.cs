using BusinessLayer.Interface;
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
            List<StudentModel> students = new List<StudentModel>();
            foreach(Student student in studentRepository.GetAllStudents())
            {
                students.Add(new StudentModel(student.Name,student.Address,student.Email));
            }
            return students;
        }

        public StudentModel GetStudent(int id)
        {
            Student student = studentRepository.GetStudent(id);
            return new StudentModel(student.Name, student.Address, student.Email);
        }
       
        public StudentModel AddStudent(StudentModel studentModel)
        {
            Student student = new Student(studentModel.Name, studentModel.Address, studentModel.Email);
            Student Addedstudent = studentRepository.AddStudent(student);
            return new StudentModel(Addedstudent.Name, Addedstudent.Address, Addedstudent.Email);
        }

        public StudentModel UpdateStudent(int id,StudentModel studentModel)
        {
            Student student = new Student(studentModel.Name, studentModel.Address, studentModel.Email);
            Student updatedstudent = studentRepository.UpdateStudent(id,student);
            return new StudentModel(updatedstudent.Name, updatedstudent.Address, updatedstudent.Email);
        }

        public StudentModel DeleteStudent(int id)
        {
            Student deletedstudent = studentRepository.DeleteStudent(id);
            return new StudentModel(deletedstudent.Name, deletedstudent.Address, deletedstudent.Email);
        }
    }
}

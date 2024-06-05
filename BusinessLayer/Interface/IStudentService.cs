using ModelLayer;
using RepositoryLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interface
{
    public interface IStudentService
    {
        StudentModel GetStudent(int Id);
        IEnumerable<StudentModel> GetAllStudents();
        StudentModel AddStudent(StudentModel Studentmodel);
        StudentModel UpdateStudent(int id,StudentModel Studentmodel);
        StudentModel DeleteStudent(int Id);
    }
}

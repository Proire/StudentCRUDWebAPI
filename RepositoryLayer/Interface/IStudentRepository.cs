using RepositoryLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Interface
{
    public interface IStudentRepository
    {
        Student GetStudent(int Id);
        IEnumerable<Student> GetAllStudents();
        Student AddStudent(Student Student);
        Student UpdateStudent(int id,Student StudentChanges);
        Student DeleteStudent(int Id);
    }

}

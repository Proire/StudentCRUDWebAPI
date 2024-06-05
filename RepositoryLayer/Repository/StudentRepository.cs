using Microsoft.EntityFrameworkCore;
using RepositoryLayer.DBContexts;
using RepositoryLayer.Entities;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly StudentDBContext context;

        public StudentRepository(StudentDBContext context)
        {
            this.context = context;
        }
        public Student AddStudent(Student Student)
        {
            context.Students.Add(Student);
            context.SaveChanges();
            return Student;
        }

        public Student DeleteStudent(int Id)
        {
            Student Student = context.Students.Find(Id);
            if (Student != null)
            {
                context.Students.Remove(Student);
                context.SaveChanges();
            }
            return Student;
        }
        public IEnumerable<Student> GetAllStudents()
        {
            return context.Students;
        }

        public Student GetStudent(int Id)
        {
            return context.Students.Find(Id);
        }

        public Student UpdateStudent(int id,Student updatedStudent)
        {
            updatedStudent.Prn = id;
            // Attach the updated student entity to the context
            var existingStudent = context.Students.Find(id);

            if (existingStudent != null)
            {
                existingStudent.Prn = id;
                existingStudent.Name = updatedStudent.Name;
             existingStudent.Email = updatedStudent.Email;
                    existingStudent.Address = updatedStudent.Address;
            }

            // Save the changes to the database
            context.SaveChanges();

            // Return the updated student entity
            return existingStudent;
        }

    }

}

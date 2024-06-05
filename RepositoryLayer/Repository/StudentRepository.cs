using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using RepositoryLayer.DBContexts;
using RepositoryLayer.Entities;
using RepositoryLayer.Exceptions;
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
            try
            {
                context.Students.Add(Student);
                context.SaveChanges();
            }
            catch(UserException e)
            {
                
                Console.WriteLine(e.Message);
                throw;
            }
            
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
            else
                throw new UserException($"Student with ID {Id} not found.");
            return Student;
        }
        public IEnumerable<Student> GetAllStudents()
        {
            var students = context.Students;
            if (students.IsNullOrEmpty()) { throw new UserException($"No Students Found"); }
            return students;
        }

        public Student GetStudent(int Id)
        {
            var student = context.Students.Find(Id);
            if (student != null) { return student; }
            else { throw new UserException($"Student with ID { Id } not found."); }
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
            else
                throw new UserException($"Student with ID { id } not found.");

            // Save the changes to the database
            context.SaveChanges();

            // Return the updated student entity
            return existingStudent;
        }

    }

}

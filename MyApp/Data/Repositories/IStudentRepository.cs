using System.Collections.Generic;
using MyApp.Models;

namespace MyApp.Data.Repositories
{
    public interface IStudentRepository
    {
        void AddStudent(Student student);
        IEnumerable<Student> GetAllStudent();
        Student GetStudent(int id);
        void Save();
    }
}
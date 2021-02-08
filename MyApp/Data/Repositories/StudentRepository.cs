using MyApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApp.Data.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly MyAppContext _context;

        public StudentRepository(MyAppContext context)
        {
            _context = context;
        }

        public void AddStudent(Student student)
        {
            /*
            DB 변동없음
            EntityFramework에서 메모리 내에 Student Entity가 DB에 추가될 준비가 되었다는 변동사항만 추적하고 있음
            */
            _context.Students.Add(student);
        }

        public void Save()
        {
            //변동사항들을 DB에 저장
            _context.SaveChanges();
        }

        public IEnumerable<Student> GetAllStudent()
        {
            var result = _context.Students.ToList();
            return result;
        }

        public Student GetStudent(int id)
        {
            var result = _context.Students.Find(id);
            return result;
        }

        public void Edit(Student student)
        {
            /*
            DB 변동없음
            EntityFramework에서 메모리 내에 Student Entity가 DB에 변화가 되었다는 변동사항만 추적하고 있음
            */
            _context.Update(student);
        }
    }
}

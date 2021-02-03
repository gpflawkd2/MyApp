using MyApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApp.Data.Repositories
{
    public class TeacherRepository : ITeacherRepository
    {
        private readonly MyAppContext _context;

        public TeacherRepository(MyAppContext context)
        {
            _context = context;
        }

        //IEnumerable: 컬렉션
        //IEnumerable vs List 차이점: 데이터를 읽어 올 때 IEnumerable이 List보다 효율성면에서 조금 더 뛰어남
        public IEnumerable<Teacher> GetAllTeachers()
        {
            var result = _context.Teachers.ToList();
            return result;
        }

        public Teacher GetTeacher(int id)
        {
            var result = _context.Teachers.Find(id);
            return result;
        }
    }
}

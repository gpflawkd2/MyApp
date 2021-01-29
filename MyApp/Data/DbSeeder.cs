using MyApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApp.Data
{
    public class DbSeeder
    {
        private MyAppContext _context;

        //생성자
        public DbSeeder(MyAppContext context)
        {
            _context = context;
        }

        //async : 비동기 프로그래밍 키워드(사용시 Task 타입 붙여서 사용)
        public async Task SeedDatabase()
        {
            if (!_context.Teachers.Any())
            {
                List<Teacher> teachers = new List<Teacher>()
                {
                    new Teacher(){Name="세종대왕", Class="한글"},
                    new Teacher(){Name="이순신", Class="해상전략"},
                    new Teacher(){Name="제갈량", Class ="지략"},
                    new Teacher(){Name="을지문덕", Class = "지상전략"}
                };

                //하나의 객체만 추가하는 경우, AddAsync() 함수 사용
                //await _context.AddAsync(new Teacher() { Name = "세종대왕", Class = "한글" });

                //리스트인 경우, AddRangeAsync() 함수 사용
                await _context.AddRangeAsync(teachers);
                //DB 저장
                await _context.SaveChangesAsync();
            }
        }
    }
}

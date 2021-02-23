using Microsoft.AspNetCore.Identity;
using MyApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApp.Data
{
    public class DbSeeder
    {
        private readonly MyAppContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        //생성자
        public DbSeeder(MyAppContext context,
                        UserManager<ApplicationUser> userManager,
                        RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
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

            //운영자 Role 생성
            var adminAccount = await _userManager.FindByNameAsync("admin@gmail.com");
            //Admin Role 생성 및 AspNetRoles 테이블에 추가
            var adminRole = new IdentityRole("Admin");
            await _roleManager.CreateAsync(adminRole);
            //adminAccount 계정에 운영자 Role 부여
            await _userManager.AddToRoleAsync(adminAccount, adminRole.Name);
        }
    }
}

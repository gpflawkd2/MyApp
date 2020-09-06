using Microsoft.EntityFrameworkCore;
using MyApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApp.Data
{
    public class MyAppContext : DbContext
    {
        //ctor + Tab 2번 -> 생성자 생성
        public MyAppContext(DbContextOptions options) : base(options) { }

        //DataBase Table로 매핑
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }

    }
}

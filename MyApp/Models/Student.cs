using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApp.Models
{
    public class Student
    {
        //특정 필드만 제외시킬 때 BindNever 사용
        [BindNever]
        public string Name { get; set; }

        public int Age { get; set; }
        public string Country { get; set; }
    }
}

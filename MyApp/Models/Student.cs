using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyApp.Models
{
    public class Student
    {
        //특정 필드만 제외시킬 때 BindNever 사용
        //[BindNever]

        //Validation Check => DataAnnotation 활용
        [Required]  //필수값
        [MaxLength(50)] //최대 50자까지 허용
        public string Name { get; set; }
        [Range(15, 70)] //15~70까지만 허용
        public int Age { get; set; }
        [Required, MinLength(5)]  //필수값, 최소 5자부터 허용
        public string Country { get; set; }
    }
}

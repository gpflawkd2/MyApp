using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApp.Models
{
    public class Teacher
    {
        //Context Mapping시 오류 방지를 위해 Id 속성 추가
        public int Id { get; set; }

        public string Name { get; set; }
        public string Class { get; set; }

        //1:1 or 1:Many 관계를 정의할 수 있음 -> DB 생성시 자동으로 관계가 매핑됨
        //public Student Student { get; set;}

    }
}

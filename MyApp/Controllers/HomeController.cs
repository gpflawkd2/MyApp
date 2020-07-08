using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyApp.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyApp.Controllers
{
    public class HomeController : Controller
    {
        //GET: /<controller>/
        //IActionResult: 함수안에 짜놓은 코드들을 알맞게 View에 매핑해서 return함
        //Views 폴더에 Controller Class의 이름과 동일한 폴더명이 있어야함
        //Views > Home 폴더에 Controller Class의 Action 함수명(Student)과 동일한 Razor View 파일을 추가해주어야함
        //Razor View를 display 하는 역할
        public IActionResult Student()
        {
            return View();
        }

        //HTML View에서 넘어오는 값들을 받는 역할(Model Binding)
        [HttpPost]
        //받고 싶은 데이터만 받는 방법: Bind 사용
        //public IActionResult Student([Bind("Name, Age")] Student model)
        public IActionResult Student(Student model)
        {
            //유효성 검사
            if (ModelState.IsValid)
            {
                //true 리턴시
                //model 데이터를 Student 테이블에 저장
            }
            else
            {
                //TagHelper를 이용한 에러내용 보여줌
            }
            return View();
        }
    }
}

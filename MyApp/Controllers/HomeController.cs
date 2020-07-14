using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyApp.Models;
using MyApp.ViewModels;

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
            List<Teacher> teachers = new List<Teacher>()
            {
                new Teacher(){Name="세종대왕", Class="한글"},
                new Teacher(){Name="이순신", Class="해상전략"},
                new Teacher(){Name="제갈량", Class ="지략"},
                new Teacher(){Name="을지문덕", Class = "지상전략"}
            };

            //StudentTeacherViewModel 인스턴스화
            var viewModel = new StudentTeacherViewModel()
            {
                Student = new Student(),
                Teachers = teachers
            };

            //return View();
            return View(viewModel);
        }

        //HTML View에서 넘어오는 값들을 받는 역할
        //post 요청으로 Controller에 들어왔을 때 Model Binding 처리함
        [HttpPost]
        // 사이트간 요청 위조 예방 > html페이지 Form의 Token 체크(recommend!!)
        [ValidateAntiForgeryToken]
        public IActionResult Student(StudentTeacherViewModel model)
        //받고 싶은 데이터만 받는 방법: Bind 사용
        //public IActionResult Student([Bind("Name, Age")] Student model)
        {
            //유효성 검사
            if (ModelState.IsValid)
            {
                //true 리턴시
                //model 데이터를 Student 테이블에 저장
            }
            else
            {
                //TagHelper를 이용한 에러내용 출력
            }
            return View();
        }
    }
}

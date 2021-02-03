using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyApp.Data.Repositories;
using MyApp.Models;
using MyApp.ViewModels;

namespace MyApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITeacherRepository _repository;

        //생성자 생성
        public HomeController(ITeacherRepository repository)
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
            var teachers = _repository.GetAllTeachers();

            //StudentTeacherViewModel 인스턴스화
            var viewModel = new StudentTeacherViewModel()
            {
                Student = new Student(),
                Teachers = teachers
            };

            //return View();
            return View(viewModel);
        }

        //GET: /<controller>/
        //IActionResult: 함수안에 짜놓은 코드들을 알맞게 View에 매핑해서 return함

        /*
        Controller에서 View까지 도달하는 MVC 규칙
        1. Views 폴더 안에 해당 Controller 이름과 매칭하는 폴더를 생성
        2. 또, 그 안에 Action 함수 이름과 매칭하는 Razor View를 생성
        */

        //Razor File을 display 하는 역할 
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

            //F12: 상세보기
            //return View();
            return View(viewModel);
        }

        //View에서 post 요청으로 Controller에 넘어오는 값들을 받는 역할
        [HttpPost]
        //사이트간 요청 위조 예방 > html페이지 Form의 Token 체크(recommend!!)
        [ValidateAntiForgeryToken]
        public IActionResult Student(StudentTeacherViewModel model)
        //받고 싶은 데이터만 받는 방법: Bind Attribute 사용
        //public IActionResult Student([Bind("Name, Age")] Student model)
        //public IActionResult Student(Student model)
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyApp.Data.Repositories;
using MyApp.Models;
using MyApp.ViewModels;

namespace MyApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITeacherRepository _teacherRepository;
        private readonly IStudentRepository _studentRepository;

        //생성자 생성
        public HomeController(ITeacherRepository teacherRepository,
                              IStudentRepository studentRepository)
        {
            //필드화
            _teacherRepository = teacherRepository;
            _studentRepository = studentRepository;
        }

        public IActionResult Index()
        {
            var teachers = _teacherRepository.GetAllTeachers();

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

        // GET: Student
        // 로그인시에만 페이지 접근 가능함
        [Authorize]
        public IActionResult Student()
        {

            var students = _studentRepository.GetAllStudent();

            //StudentTeacherViewModel 인스턴스화
            var viewModel = new StudentTeacherViewModel()
            {
                Student = new Student(),
                Students = students
            };

            //F12: 상세보기
            //return View();
            return View(viewModel);
        }

        // POST: Student
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
                //true 리턴시, model 데이터를 Student 테이블에 저장
                _studentRepository.AddStudent(model.Student);
                _studentRepository.Save();

                //입력 Data 초기화
                ModelState.Clear();
            }
            else
            {
                //TagHelper를 이용한 에러내용 출력
            }

            var students = _studentRepository.GetAllStudent();

            var viewModel = new StudentTeacherViewModel()
            {
                Student = new Student(),
                Students = students
            };

            return View(viewModel);
        }

        public IActionResult Detail(int id)
        {
            var result = _studentRepository.GetStudent(id);

            return View(result);
        }

        // GET: Edit
        public IActionResult Edit(int id)
        {
            var result = _studentRepository.GetStudent(id);

            return View(result);
        }

        // POST: Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Student student)
        {
            //유효성 검사
            if (ModelState.IsValid)
            {
                _studentRepository.Edit(student);
                _studentRepository.Save();

                return RedirectToAction("Student");
            }

            //유효성 검사 False인 경우, 기존 정보를 다시 보여줌
            return View(student);
        }

        public IActionResult Delete(int id)
        {
            var result = _studentRepository.GetStudent(id);

            if (result != null)
            {
                _studentRepository.Delete(result);
                _studentRepository.Save();
            }

            return RedirectToAction("Student");
        }
    }
}
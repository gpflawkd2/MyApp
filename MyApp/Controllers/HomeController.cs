using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyApp.Controllers
{
    public class HomeController : Controller
    {
        // GET: /<controller>/
        //IActionResult: 함수안에 짜놓은 코드들을 알맞게 View에 매핑해서 return함
        //Views 폴더에 Controller Class의 이름과 동일한 폴더명이 있어야함
        //Views > Home 폴더에 Controller Class의 Action 함수명(Student)과 동일한 Razor View 파일을 추가해주어야함
        //Razor View 파일: C#코드가 HTML코드와 함께 렌더링되는 View 파일
        public IActionResult Student()
        {
            return View();
        }
    }
}

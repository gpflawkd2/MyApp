using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyApp.Models;
using MyApp.ViewModels;

namespace MyApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;

        //생성자 생성
        public AccountController(UserManager<ApplicationUser> userManager)
        {
            //의존성주입을 위한 필드화
            _userManager = userManager;
        }

        public IActionResult Register()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                //model에서 넘어온 입력값을 ApplicationUser 테이블의 해당속성에 Mapping 처리함
                var user = new ApplicationUser { UserName = model.Email, Email = model.Email, FullName = model.FullName, Gender = model.Gender };
                //ApplicationUser 변수와 model에서 넘어온 Password를 Identity에서 제공하는 UserManager를 통해 매개변수로 넘기고 새로운 계정을 생성함
                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                    return RedirectToAction("Login");

                ModelState.AddModelError("", "회원가입 실패");
            }

            return View(model);
        }
    }
}

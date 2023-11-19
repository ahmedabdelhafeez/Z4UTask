
using Microsoft.AspNetCore.Mvc;
using Task.Domain.Services.AuthDomain;
using Task.Domain.Services.AuthDomain.Models;

namespace Z4UTask.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthService authService;

        public AuthController(IAuthService authService)
        {
            this.authService = authService;
        }
        [HttpGet]
        public ActionResult Login(string returnUrl = null)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginViewModel model, string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");
            ViewBag.ReturnUrl = returnUrl;
            if (!ModelState.IsValid)
                return View(model);
            var res = authService.Login(model).Result;
            if (!res.IsSuccess)
            {
                ModelState.AddModelError("", res.Message);
                return View(model);
            }
            return RedirectToAction("Index", "Home");

        }

        [HttpGet]
        public ActionResult Register(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        public  ActionResult Register(User user, string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");
            ViewBag.ReturnUrl = returnUrl;
            if (!ModelState.IsValid)
                return View(user);
             var res=   authService.Register(user).Result;
            if(!res.IsSuccess)
            {
                ModelState.AddModelError("", res.Message);
                return View(user);
            }
               
            return  RedirectToAction("Index", "Home");

 
        }

    }
}

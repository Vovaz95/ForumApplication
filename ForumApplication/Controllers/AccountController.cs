using AutoMapper;
using ForumApplication.Models.ViewModels;
using ForumApplication.Service;
using ForumApplication.Service.Auth;
using ForumApplication.Service.DTO;
using System.Web.Mvc;

namespace ForumApplication.Controllers
{
    public class AccountController : Controller
    {
        CustomAuthentication _authentication = new CustomAuthentication(System.Web.HttpContext.Current);

        public ActionResult UserSignIn()
        {
            UserView user = null;
            if (_authentication.CurrentUser != null)
            {
                user = Mapper.Map<UserView>(_authentication.CurrentUser);
            }
            return PartialView("SignInPanelPartialView", user);
        }

        public ActionResult SignOut()
        {
            _authentication.LogOut();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult SignIn()
        {
            return View("SignIn");
        }

        [HttpPost]
        public ActionResult SignIn(SignInView user)
        {
            if (ModelState.IsValid)
            {
                if (_authentication.Login(user.Login, user.Password, false))
                {
                    return RedirectToAction("Index", "Home");
                }
            }

            ViewBag.Message = "No such user or invalid password!";

            return View("SignIn");
        }

        public ActionResult SignUp()
        {
            return View("SignUp");
        }

        [HttpPost]
        public ActionResult SignUp(SignUpView user)
        {
            if (ModelState.IsValid)
            {
                UserService service = new UserService();

                UserDTO userDto = Mapper.Map<UserDTO>(user);

                service.SignUp(userDto);
                _authentication.Login(user.Login, user.Password, false);
            }

            return RedirectToAction("Index", "Home");
        }

        public JsonResult CheckUserLogin(string login)
        {
            var service = new UserService();
            var result = !service.CheckUserLoginForExist(login);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}
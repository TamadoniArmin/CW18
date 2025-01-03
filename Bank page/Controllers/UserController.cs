using App.Domain.AppServices.Bank.User;
using Bank_page.Models;
using Microsoft.AspNetCore.Mvc;

namespace Bank_page.Controllers
{
    public class UserController : Controller
    {
        UserAppService _userApp= new UserAppService();
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            InmmemoryDB.ResetAllData();
            var Result=_userApp.Login(username, password);
            if(!Result)
            {
                ViewBag.ErroMassage = "Your username or password is incorrect";
                return RedirectToAction("Login");              
            }
            else
            {
                InmmemoryDB.Username = username;
                return RedirectToAction("UserCards", "Cards", username);
            }

        }
        [HttpGet]
        public IActionResult Logout()
        {
            InmmemoryDB.ResetAllData();
            return RedirectToAction("Login");
        }
    }
}

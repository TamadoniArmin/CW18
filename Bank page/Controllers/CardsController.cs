using App.Domain.AppServices.Bank.Cards;
using Bank_page.Models;
using Microsoft.AspNetCore.Mvc;

namespace Bank_page.Controllers
{
    public class CardsController : Controller
    {
        CardAppService _appService=new CardAppService();

        
        public IActionResult UserCards()
        {
            var Username=InmmemoryDB.Username;
            var cards=_appService.GetListOfUserCards(Username);
            return View(cards);
        }


        public IActionResult GetBalance()
        {
            return View();
        }
        [HttpGet]
        public IActionResult GetBalance(string cardNumber)
        {
            InmmemoryDB.CurrentCardNumber = cardNumber;
            var balance=_appService.GetCardBalance(cardNumber);
            return View(balance);
        }


        [HttpGet]
        public IActionResult GoToTransactionPage(string CardNumber)
        {
            return RedirectToAction( "Index", "TransAction" , CardNumber);
        }


        public IActionResult ChangePassword()
        {
            
            return View();
        }
        [HttpPost]
        public IActionResult ChangePassword(string Cardnumbre,string PriorPassword,string newPassword)
        {
            var CheckPass = _appService.CheckPassword(Cardnumbre, PriorPassword);
            if(CheckPass)
            {
                _appService.ChangePassword(Cardnumbre, newPassword);
                TempData["Password changed"] = "Your password has been changed succesfully";
                return RedirectToAction("UserCards", "Cards");
            }
            TempData["Password is not correct"] = "Password is not correct!";
            return View();
        }
    }
}

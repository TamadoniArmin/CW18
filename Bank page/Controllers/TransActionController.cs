using App.Domain.AppServices.Bank.Cards;
using App.Domain.AppServices.Bank.TransAction;
using App.Domain.Core.Bank.Cards.AppServices;
using App.Domain.Core.Bank.Cards.Entities;
using App.Domain.Core.Bank.TransAction.AppServices;
using App.Infra.Data.Repos.Ef.Bank.TempPassword;
using Bank_page.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Timers;

namespace Bank_page.Controllers
{
    public class TransActionController : Controller
    {
        TransactionAppService _transactionAppService=new TransactionAppService();
        [HttpGet]
        public IActionResult Index(string CardNumber)
        {
            InmmemoryDB.ResetForTransaction();
            InmmemoryDB.CurrentCardNumber = CardNumber;
            return View(CardNumber);
        }
        [HttpGet]
        public IActionResult GoToTransactionPage()//<--رو دکمه ست میشه
        {
            return RedirectToAction("GetTransactionDitail");
        }
        public IActionResult GetTransactionDitail()
        {
            return View();
        }

        [HttpPost]
        public IActionResult GetTransactionDitail(string DestinationCard,int EnteredMoney)
        {
            var UserCardNumber = InmmemoryDB.CurrentCardNumber;
            CardAppService cardAppService = new CardAppService();//<<<-----
            var destansCard=cardAppService.GetDistancCard(DestinationCard);
            if (destansCard != null)
            {
                InmmemoryDB.FindDesCard = true;
                InmmemoryDB.DestanceCardNumber = destansCard.CardNumber;
                InmmemoryDB.TransactionMoney = EnteredMoney;
                return RedirectToAction("ShowTransactionInfo", destansCard);
            }
            else
            {
                _transactionAppService.AddTransaction(UserCardNumber, DestinationCard, 1);
                TempData["Can't find destinationCard"] = "Unsuccessful transaction due to not finding the destination card";
                return RedirectToAction("index");
            }
        }
        //نمایش اطلاعات تراکنش
        [HttpGet]
        public IActionResult ShowTransactionInfo(Card destansCard)
        {
            return View(destansCard);
        }
        [HttpGet]
        public IActionResult ConfirmInfo()
        {
            return RedirectToAction("ValidationPassword");
        }
        public IActionResult ValidationPassword()
        {
            return View();
        }
        [HttpPost]
        public IActionResult ValidationPassword(string VPassword)
        {
            FileRepository fileRepository = new FileRepository();
            var FilePassword = fileRepository.GetPasswordFromFile();
            if (VPassword == FilePassword)
            {
                return RedirectToAction("Transaction");
            }
            else
            {
                TempData["Validation-password error"] = "The validation code is incorrect";
                return RedirectToAction("Idex");
            }
        }
        [HttpGet]
        public void Transaction()
        {
            var Result = _transactionAppService.AddTransaction(InmmemoryDB.CurrentCardNumber, InmmemoryDB.DestanceCardNumber, InmmemoryDB.TransactionMoney);
            if (Result)
            {
                TempData["successful Transaction"] = "The transaction was completed successfully";
                RedirectToAction("UserCards", "Cards");
            }
            TempData["Error in transaction"] = "Oops... something went wrong!";
            RedirectToAction("index");
        }
        [HttpGet]
        public IActionResult ReturnToIndex()
        {
            return RedirectToAction("Index");
        }
        //تا اینجا
        //قسمت نمایش لیست تراکش های این کارت
        [HttpPost]//<---دکمه میخواد تو Index
        public IActionResult ShowTransactionInList()
        {
            var transactions= _transactionAppService.GetListOfSourceAction(InmmemoryDB.CurrentCardNumber);
            TempData["destanceTeans"]=_transactionAppService.GetListOfDestanceAction(InmmemoryDB.CurrentCardNumber);
            return View(transactions);
        }
        //قسمت دریافت رمز موقت
        [HttpGet]
        public void GetTemporaryPassword()
        {
            System.Timers.Timer timer = new();
            timer = new(1 * 20 * 1000);
            timer.Elapsed += TimeUp;
            timer.AutoReset = false;
            timer.Start();
        }
        public void TimeUp(object sender, ElapsedEventArgs e)
        {
            TempData["TimeUp"] = "The time of entering validation code is expaired!";
            RedirectToAction("Index");
        }
        //تا اینجا
    }
}

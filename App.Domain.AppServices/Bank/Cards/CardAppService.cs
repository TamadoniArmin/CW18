using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Domain.Core.Bank.Cards.AppServices;
using App.Domain.Services.Bank.Cards;


namespace App.Domain.AppServices.Bank.Cards
{
    public class CardAppService : ICardAppService
    {
        CardService _cardService=new CardService();

        public bool ActionsPermition(string Cardnumber)
        {
            return _cardService.ActionsPermition(Cardnumber);
        }

        public void ChangeStatus(string Cardnumber)
        {
            _cardService.ChangeStatus(Cardnumber);
        }

        public void CheckTimesOfInsertingPasswordIncorrectly(string Cardnumber)
        {
            var Cout = _cardService.CheckTimesOfInsertingPasswordIncorrectly(Cardnumber);
            if (Cout >= 3)
            {
                _cardService.ChangeStatus(Cardnumber);
                Console.WriteLine("Account locked due to too many incorrect attempts.");
            }
        }

        public void CountInstertPasswordWrong(string Cardnumber)
        {
            _cardService.CountInstertPasswordWrong(Cardnumber);
        }

        public double GetCardBalance(string Cardnumber)
        {
            return _cardService.GetCardBalance(Cardnumber);
        }

        public bool GetCardByNumber(string Cardnumber)
        {
            var Card = _cardService.GetCardByNumber(Cardnumber);
            if (Card is null)
            {
                return false;
            }
            return true;
        }

        public List<App.Domain.Core.Bank.Cards.Entities.Card> GetListOfUserCards(string username)
        {
            return _cardService.GetListOfUserCards(username);
        }

        public void IncreasAmount(double money, string cartnumber)
        {
            var CheckExist = _cardService.GetCardByNumber(cartnumber);
            if (CheckExist == null)
            {
                Console.WriteLine("We can not Find Your Destonation Card!");
            }
            _cardService.IncreasAmount(money, cartnumber);
        }

        public bool IncreasDailyTransaction(double money, string cartnumber)
        {
            return _cardService.IncreasDailyTransaction(money, cartnumber);
        }

        public bool CheckPassword(string Cardnumber, string password)
        {
            return _cardService.ChangePassword(Cardnumber, password);
        }

        public bool ReduceAmount(double money, string cartnumber, string DistansCardnumber)
        {
            var DistanceCard = _cardService.GetCardByNumber(DistansCardnumber);
            if (DistanceCard is null)
            {
                Console.WriteLine("We can not Find Your Destonation Card!");
                return false;
            }
            else
            {
                if (money <= 0)
                {
                    Console.WriteLine("The enterd amount must be more than ZERO");
                    return false;
                }
                else
                {
                    double MoneyWithTax;
                    if (money > 1000)
                    {
                        MoneyWithTax = money * 0.015;

                        var action = _cardService.ReduceAmount(MoneyWithTax + money, cartnumber);
                        if (!action)
                        {
                            Console.WriteLine("You don't have enough nomey!");
                            return false;
                        }
                    }
                    else if (10 <= money && money < 1000)
                    {
                        MoneyWithTax = money * 0.005;
                        var action = _cardService.ReduceAmount(MoneyWithTax + money, cartnumber);
                        if (!action)
                        {
                            Console.WriteLine("You don't have enough nomey!");
                            return false;
                        }
                    }
                    return true;
                }
            }
        }

        public void ResetLastTransactionDate(string Cardnumber)
        {
            _cardService.ResetLastTransactionDate(Cardnumber);
        }

        public void SetLastTransactionDate(string Cardnumber)
        {
            _cardService.SetLastTransactionDate(Cardnumber);
        }

        public void ChangePassword(string Cardnumber, string newpassword)
        {
            var ResultOfChangePass = _cardService.ChangePassword(Cardnumber, newpassword);
            if (ResultOfChangePass)
            {
                Console.WriteLine("Done.");
            }
            else
            {
                Console.WriteLine("Ooops....Something Goes wrong! Please try again.");
            }
        }

        public App.Domain.Core.Bank.Cards.Entities.Card GetDistancCard(string Cardnumber)
        {
            return _cardService.GetCardByNumber(Cardnumber);
        }

    }
}

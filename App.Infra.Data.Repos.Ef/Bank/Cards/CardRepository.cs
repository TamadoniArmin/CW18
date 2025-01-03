using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Domain.Core.Bank.Cards;
using App.Domain.Core.Bank.Cards.Data.Repositories;
using Connection;
using Microsoft.EntityFrameworkCore;

namespace App.Infra.Data.Repos.Ef.Bank.Cards
{
    public class CardRepository : ICardRepository
    {
        AppDbContext _context = new AppDbContext();

        public bool ActionsPermition(string Cardnumber)
        {
            return _context.Cards.Any(c => c.CardNumber == Cardnumber && c.Daylitransaction < 250);
        }

        public bool CardIsActive(string Cardnumber)
        {
            var card = _context.Cards.FirstOrDefault(c => c.CardNumber == Cardnumber && c.IsActice == true);
            if (card is not null)
            {
                return true;
            }
            return false;
        }

        public void ChangeStatus(string Cardnumber)
        {
            var card = GetCardByNumber(Cardnumber);
            card.IsActice = false;
            _context.SaveChanges();
        }

        public int CheckTimesOfInsertingPasswordIncorrectly(string Cardnumber)
        {
            var Card = GetCardByNumber(Cardnumber);
            return Card.InsertingPasswordWrongly;
        }

        public void CountInstertPasswordWrong(string Cardnumber)
        {
            var Card = GetCardByNumber(Cardnumber);
            Card.InsertingPasswordWrongly++;
            _context.SaveChanges();
        }

        public double GetCardBalance(string Cardnumber)
        {
            var card = _context.Cards.FirstOrDefault(c => c.CardNumber == Cardnumber);
            _context.Entry(card).Reload();
            return card.Balance;
        }

        public App.Domain.Core.Bank.Cards.Entities.Card? GetCardByNumber(string Cardnumber)
        {
            return _context.Cards.Include(u => u.Holder).FirstOrDefault(c => c.CardNumber == Cardnumber);
        }

        public List<App.Domain.Core.Bank.Cards.Entities.Card> GetListOfUserCards(string username)
        {
            return _context.Cards.Where(c => c.Holder.UserName == username).ToList();
        }

        public void IncreasAmount(double money, string cartnumber)
        {
            var card = GetCardByNumber(cartnumber);
            if (card is not null)
            {
                card.Balance += money;
                _context.SaveChanges();
            }

        }

        public bool IncreasDailyTransaction(double money, string cartnumber)
        {
            var card = GetCardByNumber(cartnumber);
            if (card.Daylitransaction + money <= 100000)
            {
                card.Daylitransaction += money;
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public bool CheckPassword(string Cardnumber, string password)
        {
            bool res1 = CardIsActive(Cardnumber);
            bool res2 = _context.Cards.Any(c => c.CardNumber == Cardnumber && c.Password == password);
            if (res1 == true && res2 == true)
            {
                return true;
            }
            return false;
        }

        public bool ReduceAmount(double money, string cartnumber)
        {
            var card = GetCardByNumber(cartnumber);
            var balance = GetCardBalance(cartnumber);
            if (balance < money)
            {
                return false;
            }
            else
            {
                card.Balance -= money;
                _context.SaveChanges();
                return true;
            }
        }

        public void ResetLastTransactionDate(string Cardnumber)
        {
            var card = GetCardByNumber(Cardnumber);
            if ((DateTime.Now - card.SetedLimitationDate).TotalHours > 24)
            {
                card.Daylitransaction = 0;
                card.SetedLimitationDate = DateTime.Now;
                _context.SaveChanges();
            }
        }

        public void SetLastTransactionDate(string Cardnumber)
        {
            var card = GetCardByNumber(Cardnumber);
            if (card.Daylitransaction >= 250)
            {
                card.SetedLimitationDate = DateTime.Now;
                _context.SaveChanges();
            }
        }

        public bool ChangePassword(string Cardnumber, string newpassword)
        {
            var card = GetCardByNumber(Cardnumber);
            if (card is not null)
            {
                card.Password = newpassword;
                _context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}

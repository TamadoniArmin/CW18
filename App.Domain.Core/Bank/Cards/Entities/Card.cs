using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using App.Domain.Core.Bank.TransAction.Entities;

namespace App.Domain.Core.Bank.Cards.Entities
{
    public class Card
    {

        public int Id { get; set; }
        public string CardNumber { get; set; }
        public App.Domain.Core.Bank.User.Entities.User Holder { get; set; }
        public int HolderId { get; set; }
        public double Balance { get; set; }
        public bool IsActice { get; set; } = true;
        public string Password { get; set; }
        public double Daylitransaction { get; set; }
        public DateTime SetedLimitationDate { get; set; }
        public int InsertingPasswordWrongly { get; set; } = 0;
        public List<App.Domain.Core.Bank.TransAction.Entities.TransAction> SourceTransactions { get; set; }
        public List<App.Domain.Core.Bank.TransAction.Entities.TransAction> DestinationTransactions { get; set; }
    }
}

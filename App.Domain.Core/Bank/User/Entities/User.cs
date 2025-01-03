using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Bank.User.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Email { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
        public List<App.Domain.Core.Bank.Cards.Entities.Card>? cards { get; set; }
    }
}

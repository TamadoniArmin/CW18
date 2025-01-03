using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Domain.Core.Bank.Cards.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Connection.Configuration
{
    public class CardConfiguration : IEntityTypeConfiguration<Card>
    {
        public void Configure(EntityTypeBuilder<Card> builder)
        {
            builder.HasKey(x => x.CardNumber);
            builder.HasData(
                new Card { Id = 1, CardNumber = "5859831000619801", HolderId = 1, Password = "123", Balance = 2000 },
                new Card { Id = 2, CardNumber = "5859831000619802", HolderId = 1, Password = "123", Balance = 2000 },
                new Card { Id = 3, CardNumber = "5859831000619803", HolderId = 2, Password = "123", Balance = 2000 },
                new Card { Id = 4, CardNumber = "5859831000619804", HolderId = 2, Password = "123", Balance = 2000 },
                new Card { Id = 5, CardNumber = "5859831000619805", HolderId = 3, Password = "123", Balance = 2000 }
                );
        }
    }
}

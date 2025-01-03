using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using App.Domain.Core.Bank.TransAction.Entities;

namespace Connection.Configuration
{
    public class TransacrionConfiguration : IEntityTypeConfiguration<TransAction>
    {
        public void Configure(EntityTypeBuilder<TransAction> builder)
        {
            builder.HasKey(x => x.TransactionId);
            builder.HasOne(t => t.SourceCard)
            .WithMany(c => c.SourceTransactions)
            .HasForeignKey(t => t.SourceCardNumber)
            .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(t => t.DestinationCard)
            .WithMany(c => c.DestinationTransactions)
            .HasForeignKey(t => t.DestinationCardNumber)
            .OnDelete(DeleteBehavior.NoAction);
        }
    }
}

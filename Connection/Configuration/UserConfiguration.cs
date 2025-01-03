using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using App.Domain.Core.Bank.User.Entities;

namespace Connection.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasMany(c => c.cards).WithOne(c => c.Holder).HasForeignKey(c => c.HolderId).IsRequired();
            builder.HasData(
                new User { Id = 1, UserName = "armin", Name = "Armin", Password = "123", Email = "Armin@gmail.com" },
                new User { Id = 2, UserName = "ali", Name = "Ali", Password = "123", Email = "Ali@gmail.com" },
                new User { Id = 3, UserName = "mehdi", Name = "Mehdi", Password = "123", Email = "Mehdi@gmail.com" },
                new User { Id = 4, UserName = "nazanin", Name = "Nazanin", Password = "123", Email = "Nazanin@gmail.com" }
                );
        }
    }
}

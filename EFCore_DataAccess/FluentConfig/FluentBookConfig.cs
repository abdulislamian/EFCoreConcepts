using EFCore_Models.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore_DataAccess.FluentConfig
{
    public class FluentBookConfig : IEntityTypeConfiguration<Fulent_Book>
    {
        public void Configure(EntityTypeBuilder<Fulent_Book> modelBuilder)
        {
            modelBuilder.Property(u => u.ISBN).HasMaxLength(50);
            modelBuilder.Property(u => u.ISBN).IsRequired();
            modelBuilder.HasKey(u => u.BookId);
            modelBuilder.Ignore(u => u.PriceRange);
            modelBuilder.HasOne(u => u.Publisher).WithMany(u => u.Books)
                .HasForeignKey(u => u.Publisher_Id);
        }
    }
}

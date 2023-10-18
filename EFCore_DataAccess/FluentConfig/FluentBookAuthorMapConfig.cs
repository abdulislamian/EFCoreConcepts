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
    public class FluentBookAuthorMapConfig : IEntityTypeConfiguration<Fulent_BookAuthorMap>
    {
        public void Configure(EntityTypeBuilder<Fulent_BookAuthorMap> modelBuilder)
        {


            modelBuilder.HasKey(u => new { u.AuthorId, u.BookId});
            modelBuilder.HasOne(u => u.Book).WithMany(u => u.BookAuthorsMap)
                .HasForeignKey(u => u.BookId);
            modelBuilder.HasOne(u => u.Authors).WithMany(u => u.BookAuthorMap)
                .HasForeignKey(u => u.AuthorId);

        }
    }
}

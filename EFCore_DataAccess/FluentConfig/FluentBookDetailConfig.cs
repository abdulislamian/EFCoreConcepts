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
    public class FluentBookDetailConfig : IEntityTypeConfiguration<Fulent_BookDetails>
    {
        public void Configure(EntityTypeBuilder<Fulent_BookDetails> modelBuilder)
        {
            //name of table
            modelBuilder.ToTable("Fluent_BookDetails");
            //name of columns
            modelBuilder.Property(u => u.NoOfChapters).HasColumnName("NoOfChapters");

            //primary key
            modelBuilder.HasKey(u => u.BookDetails_Id);

            //other validations
            modelBuilder.Property(u => u.NoOfChapters).IsRequired();

            //relations
            modelBuilder.HasOne(b => b.Book).WithOne(b => b.BookDetails)
                .HasForeignKey<Fulent_BookDetails>(u => u.Fulent_BookId);
        }
    }
}

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
    public class FluentAuthorConfig : IEntityTypeConfiguration<Fulent_Authors>
    {
        public void Configure(EntityTypeBuilder<Fulent_Authors> modelBuilder)
        {
            modelBuilder.Property(u => u.FirstName).HasMaxLength(50);
            modelBuilder.Property(u => u.FirstName).IsRequired();
            modelBuilder.Property(u => u.LastName).IsRequired();
            modelBuilder.HasKey(u => u.Author_Id);
            modelBuilder.Ignore(u => u.FullName);
        }
    }
}

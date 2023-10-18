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
    public class FluentPublisherConfig : IEntityTypeConfiguration<Fulent_Publisher>
    {
        public void Configure(EntityTypeBuilder<Fulent_Publisher> modelBuilder)
        {
            modelBuilder.Property(u => u.Name).IsRequired();
            modelBuilder.HasKey(u => u.Publisher_Id);
        }
    }
}

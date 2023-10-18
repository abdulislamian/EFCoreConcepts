using Microsoft.EntityFrameworkCore;
using EFCore_Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFCore_DataAccess.FluentConfig;
using Microsoft.Extensions.Logging;

namespace EFCore_DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Genres { get; set; }
        public DbSet<Authors> Authors { get; set; }
        public DbSet<BookAuthorMap> BookAuthorMaps { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<SubCategory> SubCategories  { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<BookDetails> BookDetails { get; set; }
        //Rename to Fluent_BookDetails
        public DbSet<Fulent_BookDetails> BookDetails_Fluent { get; set; }
        public DbSet<Fulent_Book> Fluent_Book { get; set; }
        public DbSet<Fulent_Authors> Fluent_Author{ get; set; }
        public DbSet<Fulent_Publisher> Fluent_Publisher{ get; set; }
        public DbSet<Fulent_BookAuthorMap> Fluent_BookAuthorMaps{ get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //base.OnConfiguring(optionsBuilder);
            //optionsBuilder.UseSqlServer("Server=.;Database=EFCore_Concepts;Trusted_Connection=True;TrustServerCertificate=True")
            //    .LogTo(Console.WriteLine, new[] {DbLoggerCategory.Database.Command.Name},LogLevel.Information);
        
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //modelBuilder.Entity<Fulent_BookDetails>().ToTable("Fluent_BookDetails");
            //modelBuilder.Entity<Fulent_BookDetails>().Property(x => x.NoOfChapters).HasColumnName("numberOfChapers");
            //modelBuilder.Entity<Fulent_BookDetails>().HasKey(x => x.BookDetails_Id);
            //modelBuilder.Entity<Fulent_BookDetails>().Property(x => x.NoOfChapters).IsRequired();
            //modelBuilder.Entity<Fulent_BookDetails>().HasOne(x => x.Book).WithOne(x => x.BookDetails)
            //    .HasForeignKey<Fulent_BookDetails>(x => x.Fulent_BookId);


            //modelBuilder.Entity<Fulent_Book>().Property(x => x.ISBN).HasMaxLength(50);
            //modelBuilder.Entity<Fulent_Book>().Property(x => x.ISBN).IsRequired();
            //modelBuilder.Entity<Fulent_Book>().HasKey(x => x.BookId);
            //modelBuilder.Entity<Fulent_Book>().Ignore(x => x.PriceRange);
            //modelBuilder.Entity<Fulent_Book>().HasOne(x => x.Publisher).WithMany(u => u.Books)
            //    .HasForeignKey(x=>x.Publisher_Id);


            //modelBuilder.Entity<Fulent_Authors>().HasKey(x => x.Author_Id);
            //modelBuilder.Entity<Fulent_Authors>().Property(x=>x.FirstName).HasMaxLength(50);
            //modelBuilder.Entity<Fulent_Authors>().Property(x=>x.FirstName).IsRequired();
            //modelBuilder.Entity<Fulent_Authors>().Property(x=>x.LastName).IsRequired();
            //modelBuilder.Entity<Fulent_Authors>().Ignore(x=>x.FullName);

            //modelBuilder.Entity<Fulent_Publisher>().HasKey(x => x.Publisher_Id);
            //modelBuilder.Entity<Fulent_Publisher>().Property(x=>x.Name).IsRequired();


            modelBuilder.ApplyConfiguration(new FluentAuthorConfig());
            modelBuilder.ApplyConfiguration(new FluentBookAuthorMapConfig());
            modelBuilder.ApplyConfiguration(new FluentBookConfig());
            modelBuilder.ApplyConfiguration(new FluentBookDetailConfig());
            modelBuilder.ApplyConfiguration(new FluentPublisherConfig());


            //base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Book>().Property(x => x.Price).HasPrecision(10, 5);

            modelBuilder.Entity<BookAuthorMap>().HasKey(u => new { u.AuthorId, u.BookId });


            modelBuilder.Entity<Fulent_BookAuthorMap>().HasKey(u => new { u.AuthorId, u.BookId });
            modelBuilder.Entity<Fulent_BookAuthorMap>().HasOne(u => u.Book).WithMany(u => u.BookAuthorsMap)
                .HasForeignKey(x => x.BookId);
            modelBuilder.Entity<Fulent_BookAuthorMap>().HasOne(u => u.Authors).WithMany(u => u.BookAuthorMap)
                .HasForeignKey(x => x.AuthorId);


            //modelBuilder.Entity<Book>().HasData(
            //    new Book { BookId = 1 ,Title="Introduction to EFCore", ISBN="124BM4",Price=100},
            //    new Book { BookId = 2 ,Title="Introduction to DotNet Core", ISBN="124BVT",Price=150},
            //    new Book { BookId = 3 ,Title="Introduction to SQL Server", ISBN="254BM4",Price=50}
            //    );

            modelBuilder.Entity<Category>().HasData(
                new Category { categoryId = 1, CategoryName= "Category 1"},
                new Category { categoryId = 2, CategoryName= "Category 2"});

            var booklist = new Book[]
            {
                new Book { BookId = 1 ,Title="Introduction to EFCore", ISBN="124BM4",Price=100,Publisher_Id=1},
                new Book { BookId = 2 ,Title="Introduction to DotNet Core", ISBN="124BVT",Price=150,Publisher_Id=2},
                new Book { BookId = 3 ,Title="Introduction to SQL Server", ISBN="254BM4",Price=50,Publisher_Id=1}
            };
            modelBuilder.Entity<Book>().HasData(booklist);

            var publisherlist = new Publisher[]
            {
                new Publisher { Publisher_Id = 1 ,Name="Shakeel", Location="Peshawar"},
                new Publisher { Publisher_Id = 2 ,Name="=Munib", Location="Kohat",},
                new Publisher { Publisher_Id = 3 ,Name="Tariq", Location="Mianwali"}
            };
            modelBuilder.Entity<Publisher>().HasData(publisherlist);
        }
    }
}

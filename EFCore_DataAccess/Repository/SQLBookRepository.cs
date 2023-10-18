using EFCore_DataAccess.Data;
using EFCore_Models.Models;
using EFCore_Models.Models.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace EFCore_DataAccess.Repository
{
    public class SQLBookRepository : IBookRepository
    {
        private readonly ApplicationDbContext dbContext;

        public SQLBookRepository(ApplicationDbContext _dbContext)
        {
            dbContext = _dbContext;
        }

        public async Task<Book> CreateBookAsync(Book obj)
        {
            await dbContext.Books.AddAsync(obj);
            await dbContext.SaveChangesAsync();
            return obj;
        }

        public async Task<IEnumerable<Book>> GetAllBooks()
        {
            return await dbContext.Books.ToListAsync();
        }


        public async Task<IEnumerable<Book>> GetAllBooksWithPublisher()
        {
           var books =  await dbContext.Books.Include(x => x.Publisher).Include(x => x.BookAuthorMap)
                .ThenInclude(x => x.Authors).ToListAsync();
            return books;
        }

        public async Task<Book> GetBookById(int id)
        {
            return await dbContext.Books.FirstOrDefaultAsync(u => u.BookId == id);
        }

        public async Task<IEnumerable<Publisher>> GetPublishers()
        {
            return await dbContext.Publishers.ToListAsync();
        }

        public async Task<Book> UpdateBookAsync(Book book)
        {
            var existingBook = await dbContext.Books.FirstOrDefaultAsync(x => x.BookId == book.BookId);
            if (existingBook == null)
            {
                return null;
            }

            existingBook.Title = book.Title;
            existingBook.Price = book.Price;
            existingBook.ISBN = book.ISBN;
            existingBook.Publisher_Id = book.Publisher_Id;
            await dbContext.SaveChangesAsync();

            return existingBook;
        }
    }
}

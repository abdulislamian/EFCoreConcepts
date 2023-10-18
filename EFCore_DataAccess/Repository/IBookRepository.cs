using EFCore_Models.Models;
using EFCore_Models.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore_DataAccess.Repository
{
    public interface IBookRepository
    {
        public Task<IEnumerable<Book>> GetAllBooks ();
        public Task<IEnumerable<Book>> GetAllBooksWithPublisher();
        public Task<IEnumerable<Publisher>> GetPublishers();
        public Task<Book> GetBookById (int id);
        Task<Book> CreateBookAsync(Book book);
        Task<Book> UpdateBookAsync(Book book);
    }
}

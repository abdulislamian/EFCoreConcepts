using EFCore_DataAccess.Data;
using EFCore_DataAccess.Repository;
using EFCore_Models.Models;
using EFCore_Models.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace EFCoreConcepts.Controllers
{
    public class BookController : Controller
    {
        private readonly ApplicationDbContext _db;

        public IBookRepository BookRepository { get; }

        public BookController(ApplicationDbContext db,IBookRepository bookRepository)
        {
            _db = db;
            BookRepository = bookRepository;
        }

        public  async Task<IActionResult> Index()
        {
            //Eager Loading -- Using .Include (Get The Navigation Propperty also)
            //List<Book> objList = _db.Books.Include(x=>x.Publisher).ToList();

            //Eager Loading
            var books = await BookRepository.GetAllBooksWithPublisher();
            List<Book> objList = books.ToList();


            //Lazy Loading
            //IQueryable<Book> booklist = _db.Books.Include(u => u.Publisher).Include(a => a.BookAuthorMap)
            //    .ThenInclude(x => x.Authors);

            //var temp = objList.Where(u=>u.BookId == 1).ToList();    

            //List<Book> objList = _db.Books.ToList();

            //below both in loop are less efficient as compared to above query using include
            //foreach (var item in objList)
            //{
            //    //LEss Efecient 
            //    //item.Publisher = _db.Publishers.Find(item.Publisher_Id);

            //    //More Efficient
            //    _db.Entry(item).Reference(u => u.Publisher).Load();
            //    _db.Entry(item).Collection(u => u.BookAuthorMap).Load();
            //    foreach(var bookAuth in item.BookAuthorMap)
            //    {
            //        _db.Entry(bookAuth).Reference(u => u.Authors).Load();
            //    }
            //}
            return View(objList);
        }

        public async Task<IActionResult> Upsert(int? id)
        {
            BookVM obj = new();
            var publishers = await BookRepository.GetPublishers();
            obj.PublisherList = publishers.Select(i=> new SelectListItem{
                Text =  i.Name,
                Value=  i.Publisher_Id.ToString()
            });

            if (id == null || id == 0)
            {
                //create
                return View(obj);
            }
            //edit
            
            obj.Book = await BookRepository.GetBookById((int)id); 
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(BookVM obj)
        {
                if (obj.Book.BookId == 0)
                {
                //create
                    await BookRepository.CreateBookAsync(obj.Book);
                }
                else
                {
                    //update
                    await BookRepository.UpdateBookAsync(obj.Book);
                }
                return RedirectToAction(nameof(Index));
        }




        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || id == 0)
            {
                //create
                return NotFound();
            }

            //1st Way
            BookVM obj = new();
            //edit
            //obj.Book = _db.Books.FirstOrDefault(u => u.BookId == id);
            
            var book = await BookRepository.GetAllBooks();
            obj.Book = book.FirstOrDefault(u=>u.BookId == id);
            
            obj.Book.BookDetails = _db.BookDetails.FirstOrDefault(x => x.Book.BookId == id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);

            //2nd Way
            //BookVM obj = new();
            //obj.Book = _db.Books.FirstOrDefault(u => u.BookId == id);
            //obj = _db.BookDetails.FirstOrDefault(x => x.BookId == id);
            //obj = _db.BookDetails.Include(u => u.Book).FirstOrDefault(u => u.BookId == id);
            //if (obj == null)
            //{
            //    return NotFound();
            //}
            //return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Details(BookDetails obj)
        {
            //obj.Book.BookDetails.BookId = obj.Book.BookId;
            if (obj.Book.BookId == 0)
            {
                //create
                await _db.BookDetails.AddAsync(obj.Book.BookDetails);
            }
            else
            {
                //BookDetails
                _db.BookDetails.Update(obj.Book.BookDetails);
            }
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            Book obj = new();
            obj = _db.Books.FirstOrDefault(u => u.BookId == id);
            if (obj == null)
            {
                return NotFound();
            }

            _db.Books.Remove(obj);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> ManageAuthors(int id)
        {
            BookAuthorVM bookAuthorVM = new BookAuthorVM()
            {
                BookAuthorList = _db.BookAuthorMaps.Include(u => u.Authors).Include(u => u.Book)
                           .Where(u => u.BookId == id).ToList(),
                BookAuthor = new()
                {
                    BookId = id
                },
                Book = _db.Books.FirstOrDefault(u => u.BookId == id)
            };

            List<int> templistofAssignedAuthors = bookAuthorVM.BookAuthorList.Select(u => u.AuthorId).ToList();
            var tempList = _db.Authors.Where(u => !templistofAssignedAuthors.Contains(u.Author_Id)).ToList();
            bookAuthorVM.AuthorList = tempList.Select(i => new SelectListItem
            {
                Text = i.FullName,
                Value = i.Author_Id.ToString()
            });

            return View(bookAuthorVM);
        }
        [HttpPost]
        public IActionResult ManageAuthors(BookAuthorVM bookAuthorVM)
        {
            if (bookAuthorVM.BookAuthor.BookId != 0 && bookAuthorVM.BookAuthor.AuthorId != 0)
            {
                _db.BookAuthorMaps.Add(bookAuthorVM.BookAuthor);
                _db.SaveChanges();
            }
            return RedirectToAction(nameof(ManageAuthors), new { @id = bookAuthorVM.BookAuthor.BookId });
        }
        [HttpPost]
        public IActionResult RemoveAuthors(int authorId, BookAuthorVM bookAuthorVM)
        {
            int bookId = bookAuthorVM.Book.BookId;
            BookAuthorMap bookAuthorMap = _db.BookAuthorMaps.FirstOrDefault(
                u => u.AuthorId == authorId && u.BookId == bookId);


            _db.BookAuthorMaps.Remove(bookAuthorMap);
            _db.SaveChanges();
            return RedirectToAction(nameof(ManageAuthors), new { @id = bookId });
        }

        public async Task<IActionResult> Playground()
        {
            IEnumerable<Book> BookList1 = _db.Books;
            var FilteredBook1 = BookList1.Where(b => b.Price > 50).ToList();

            IQueryable<Book> BookList2 = _db.Books;
            var fileredBook2 = BookList2.Where(b => b.Price > 50).ToList();


            //var bookTemp = _db.Books.FirstOrDefault();
            //bookTemp.Price = 100;

            //var bookCollection = _db.Books;
            //decimal totalPrice = 0;

            //foreach (var book in bookCollection)
            //{
            //    totalPrice += book.Price;
            //}

            //var bookList = _db.Books.ToList();
            //foreach (var book in bookList)
            //{
            //    totalPrice += book.Price;
            //}

            //var bookCollection2 = _db.Books;
            //var bookCount1 = bookCollection2.Count();

            //var bookCount2 = _db.Books.Count();
            return RedirectToAction(nameof(Index));
        }
    }
}

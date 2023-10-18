using EFCore_DataAccess.Data;
using EFCore_Models.Models;
using Microsoft.EntityFrameworkCore;

Console.WriteLine("Hello World");

//using (applicationdbcontext context = new())
//{
//    context.database.ensurecreated();
//    if (context.database.getpendingmigrations().count() > 0)
//    {
//        context.database.migrate();
//    }
//}



//GetAllBooks();
//AddBook();
//getbook();

//void GetAllBooks()
//{
//    using var context = new ApplicationDbContext();
//    var books = context.Books.ToList();
//    foreach (var book in books)
//    {
//        Console.WriteLine(book.Title + " - " + book.ISBN);
//    }
//}


//async void getbook()
//{
//    try
//    {
//        using var context = new ApplicationDbContext();
//        var books = await context.Books.Skip(0).Take(2).ToListAsync();
//        //console.writeline(book.title + " - " + book.isbn);
//        foreach (var book in books)
//        {
//            Console.WriteLine(book.Title + " - " + book.ISBN);
//        }

//        books = await context.Books.Skip(4).Take(1).ToListAsync();
//        foreach (var book in books)
//        {
//            Console.WriteLine(book.Title + " - " + book.ISBN);
//        }
//    }
//    catch (Exception e)
//    {

//    }
//}
//async void AddBook()
//{
//    Book book = new() { Title = "New EF Core Book", ISBN = "9999", Price = 10.93m, Publisher_Id = 1 };
//    using var context = new ApplicationDbContext();
//    var books = await context.Books.AddAsync(book);
//    await context.SaveChangesAsync();
//}
using EFCore_DataAccess.Data;
using EFCore_Models.Models;
using Microsoft.AspNetCore.Mvc;

namespace EFCoreConcepts.Controllers
{
    public class PublisherController : Controller
    {
        private readonly ApplicationDbContext _db;
        public PublisherController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            List<Publisher> objList = _db.Publishers.ToList();
            return View(objList);
        }

        public IActionResult Upsert(int? id)
        {
            Publisher obj = new();
            if (id == null || id == 0)
            {
                //create
                return View(obj);
            }
            //edit
            obj = _db.Publishers.FirstOrDefault(u => u.Publisher_Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(Publisher obj)
        {
            if (ModelState.IsValid)
            {
                if (obj.Publisher_Id == 0)
                {
                    //create
                    await _db.Publishers.AddAsync(obj);
                }
                else
                {
                    //update
                    _db.Publishers.Update(obj);
                }
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(obj);
        }

        public async Task<IActionResult> Delete(int id)
        {
            Publisher obj = new();
            obj = _db.Publishers.FirstOrDefault(u => u.Publisher_Id == id);
            if (obj == null)
            {
                return NotFound();
            }

            _db.Publishers.Remove(obj);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult CreateMultiple2()
        {
            List<Publisher> Publishers = new();
            for (int i = 1; i <= 2; i++)
            {
                Publishers.Add(new Publisher { Name = Guid.NewGuid().ToString() });
            }
            _db.Publishers.AddRange(Publishers);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult CreateMultiple5()
        {
            List<Publisher> Publishers = new();
            for (int i = 1; i <= 5; i++)
            {
                Publishers.Add(new Publisher { Name = Guid.NewGuid().ToString() });
            }
            _db.Publishers.AddRange(Publishers);
            _db.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult RemoveMultiple2()
        {
            List<Publisher> Publishers = _db.Publishers.OrderByDescending(u => u.Publisher_Id).Take(2).ToList();
            _db.Publishers.RemoveRange(Publishers);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult RemoveMultiple5()
        {
            List<Publisher> Publishers = _db.Publishers.OrderByDescending(u => u.Publisher_Id).Take(5).ToList();
            _db.Publishers.RemoveRange(Publishers);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}

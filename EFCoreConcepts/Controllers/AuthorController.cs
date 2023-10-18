using EFCore_DataAccess.Data;
using EFCore_Models.Models;
using Microsoft.AspNetCore.Mvc;

namespace EFCoreConcepts.Controllers
{
    public class AuthorController : Controller
    {
        private readonly ApplicationDbContext _db;
        public AuthorController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            List<Authors> objList = _db.Authors.ToList();
            return View(objList);
        }

        public IActionResult Upsert(int? id)
        {
            Authors obj = new();
            if (id == null || id == 0)
            {
                //create
                return View(obj);
            }
            //edit
            obj = _db.Authors.FirstOrDefault(u => u.Author_Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(Authors obj)
        {
            if (ModelState.IsValid)
            {
                if (obj.Author_Id == 0)
                {
                    //create
                    await _db.Authors.AddAsync(obj);
                }
                else
                {
                    //update
                    _db.Authors.Update(obj);
                }
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(obj);
        }

        public async Task<IActionResult> Delete(int id)
        {
            Authors obj = new();
            obj = _db.Authors.FirstOrDefault(u => u.Author_Id == id);
            if (obj == null)
            {
                return NotFound();
            }

            _db.Authors.Remove(obj);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult CreateMultiple2()
        {
            List<Authors> Authors = new();
            for (int i = 1; i <= 2; i++)
            {
                Authors.Add(new Authors { FirstName = Guid.NewGuid().ToString() });
            }
            _db.Authors.AddRange(Authors);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult CreateMultiple5()
        {
            List<Authors> Authors = new();
            for (int i = 1; i <= 5; i++)
            {
                Authors.Add(new Authors { FirstName = Guid.NewGuid().ToString() });
            }
            _db.Authors.AddRange(Authors);
            _db.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult RemoveMultiple2()
        {
            List<Authors> Authors = _db.Authors.OrderByDescending(u => u.Author_Id).Take(2).ToList();
            _db.Authors.RemoveRange(Authors);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult RemoveMultiple5()
        {
            List<Authors> Authors = _db.Authors.OrderByDescending(u => u.Author_Id).Take(5).ToList();
            _db.Authors.RemoveRange(Authors);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}

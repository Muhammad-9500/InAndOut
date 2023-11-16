using InAndOut.Data;
using InAndOut.Models;
using Microsoft.AspNetCore.Mvc;

namespace InAndOut.Controllers
{
    public class ExpenseTypeController : Controller
    {
        private readonly ApplicationDbContext _db;
        public ExpenseTypeController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<ExpenseType> types = _db.ExpenseTypes;
            return View(types);
        }

        //Get - Create
        public IActionResult Create()
        {
            return View();
        }

        //Post - Create 
        [HttpPost, ActionName("Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreatePost(ExpenseType obj)
        {
            if (ModelState.IsValid)
            {
                await _db.ExpenseTypes.AddAsync(obj);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(obj);
        }

        //Get - Update
        public async Task<IActionResult> Update(int id)
        {
            var expenseToUpdate = await _db.ExpenseTypes.FindAsync(id);
            return View(expenseToUpdate);
        }


        //Post - Update 
        [HttpPost, ActionName("Update")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdatePost(ExpenseType obj)
        {
            if (ModelState.IsValid)
            {
                _db.ExpenseTypes.Update(obj);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(obj);
        }


        //Get - Delete
        public async Task<IActionResult> Delete(int id)
        {
            if (id == 0)
                return NotFound();
            var expenseToDelete = await _db.ExpenseTypes.FindAsync(id);

            if (expenseToDelete == null)
                return NotFound();
            return View(expenseToDelete);
        }

        //Post - Delete 
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeletePost(int id)
        {
            var obj = await _db.ExpenseTypes.FindAsync(id);
            if (obj == null)
                return NotFound();

            _db.ExpenseTypes.Remove(obj);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }


    }
}

using InAndOut.Data;
using InAndOut.Models;
using InAndOut.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace InAndOut.Controllers
{
    public class ExpenseController : Controller
    {
        private readonly ApplicationDbContext _db;
        public ExpenseController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Expense> expenses = _db.Expenses.Include(e=>e.ExpenseType);
            return View(expenses);
        }

        //Get - Create
        public IActionResult Create()
        {
            ExpenseVM expenseVM = new ExpenseVM
            {
                Expense = new Expense(),
                ExpenseTypesList = _db.ExpenseTypes.Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                })
            };

            return View(expenseVM);
        }

        //Post - Create 
        [HttpPost,ActionName("Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreatePost(ExpenseVM obj)
        {
            if(!ModelState.IsValid)
            {
                await _db.Expenses.AddAsync(obj.Expense);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(obj);
        }

        //Get - Update
        public async Task<IActionResult> Update(int id)
        {
            if (id == 0)
                return NotFound();
            
            ExpenseVM expenseVM = new ExpenseVM
            {
                Expense = new Expense(),
                ExpenseTypesList = _db.ExpenseTypes.Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                })
            };
            expenseVM.Expense = await _db.Expenses.FindAsync(id);
            if (expenseVM.Expense == null)
                return NotFound();

            return View(expenseVM);
        }



        //Post - Update 
        [HttpPost, ActionName("Update")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdatePost(ExpenseVM obj)
        {
            if (!ModelState.IsValid)
            {
                _db.Expenses.Update(obj.Expense);
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

            ExpenseVM expenseVM = new ExpenseVM
            {
                Expense = new Expense(),
                ExpenseTypesList = _db.ExpenseTypes.Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                })
            };
            expenseVM.Expense = await _db.Expenses.FindAsync(id);
            if (expenseVM.Expense == null)
                return NotFound();

            return View(expenseVM);
        }

        //Post - Delete 
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeletePost(int id)
        {
            ExpenseVM expenseVM = new ExpenseVM
            {
                Expense = new Expense(),
                ExpenseTypesList = _db.ExpenseTypes.Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                })
            };
            expenseVM.Expense = await _db.Expenses.FindAsync(id);

            var obj = expenseVM.Expense;
            if(obj == null)
                return NotFound();

            _db.Expenses.Remove(obj);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
           
        }

    }
}

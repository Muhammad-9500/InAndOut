using InAndOut.Data;
using InAndOut.Models;
using Microsoft.AspNetCore.Mvc;

namespace InAndOut.Controllers
{
    public class ItemController : Controller
    {
        private readonly ApplicationDbContext _db;
        public ItemController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Item> borrowedItems = _db.Items;
            return View(borrowedItems);
        }


        //Get  - Create
        public IActionResult Create(Item item)
        {
            return View();
        }


        //Post  - Create
        [HttpPost,ActionName("Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreatePost(Item item)
        {
            if(item != null)
            {
                await _db.Items.AddAsync(item);
            }
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}

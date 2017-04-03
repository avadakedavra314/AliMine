using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AliMine.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace AliMine.Controllers
{
    public class DatabaseController : Controller
    {
        AliMineContext db;
        public DatabaseController(AliMineContext context)
        {
            db = context;
        }

        [Authorize]
        public async Task<IActionResult> Categories()
        {
            IQueryable<Category> categories = db.Categories;

            return View(await categories.AsNoTracking().ToListAsync());
        }

        [Authorize]
        public IActionResult CreateCategory()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreateCategory(Category category)
        {

            db.Categories.Add(category);
            await db.SaveChangesAsync();
            return RedirectToAction("Categories");
        }

        [Authorize]
        public async Task<IActionResult> CategoryDetails(int? id)
        {
            if (id != null)
            {
                Category category = await db.Categories.FirstOrDefaultAsync(p => p.Id == id);
                if (category != null)
                    return View(category);
            }
            return NotFound();
        }

        [Authorize]
        public async Task<IActionResult> EditCategory(int? id)
        {
            if (id != null)
            {
                Category category = await db.Categories.FirstOrDefaultAsync(p => p.Id == id);
                if (category != null)
                    return View(category);
            }
            return NotFound();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> EditCategory(Category category)
        {
            db.Categories.Update(category);
            await db.SaveChangesAsync();
            return RedirectToAction("Categories");
        }

        [Authorize]
        [HttpGet]
        [ActionName("Delete")]
        public async Task<IActionResult> ConfirmDeleteCategory(int? id)
        {
            if (id != null)
            {
                Category category = await db.Categories.FirstOrDefaultAsync(p => p.Id == id);
                if (category != null)
                    return View(category);
            }
            return NotFound();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> DeleteCategory(int? id)
        {
            if (id != null)
            {
                Category category = await db.Categories.FirstOrDefaultAsync(p => p.Id == id);
                if (category != null)
                {
                    db.Categories.Remove(category);
                    await db.SaveChangesAsync();
                    return RedirectToAction("Categories");
                }
            }
            return NotFound();
        }

    }
}

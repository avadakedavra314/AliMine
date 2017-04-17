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
        [ActionName("DeleteCategory")]
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

        // ПОСТЫ:

        [Authorize]
        public async Task<IActionResult> Posts()
        {
            IQueryable<Post> posts = db.Posts.Include(u=>u.Category);

            return View(await posts.AsNoTracking().ToListAsync());
        }


        [Authorize]
        public IActionResult CreatePost()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreatePost(Post post)
        {

            db.Posts.Add(post);
            await db.SaveChangesAsync();
            return RedirectToAction("Posts");
        }

        [Authorize]
        public async Task<IActionResult> PostDetails(int? id)
        {
            if (id != null)
            {
                Post post = await db.Posts.Include(u => u.Category).FirstOrDefaultAsync(p => p.Id == id);
                if (post != null)
                    return View(post);
            }
            return NotFound();
        }

        [Authorize]
        public async Task<IActionResult> EditPost(int? id)
        {
            if (id != null)
            {
                Post post = await db.Posts.Include(u => u.Category).FirstOrDefaultAsync(p => p.Id == id);
                if (post != null)
                    return View(post);
            }
            return NotFound();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> EditPost(Post post)
        {
            db.Posts.Update(post);
            await db.SaveChangesAsync();
            return RedirectToAction("Posts");
        }

        [Authorize]
        [HttpGet]
        [ActionName("DeletePost")]
        public async Task<IActionResult> ConfirmDeletePost(int? id)
        {
            if (id != null)
            {
                Post post= await db.Posts.Include(u => u.Category).FirstOrDefaultAsync(p => p.Id == id);
                if (post != null)
                    return View(post);
            }
            return NotFound();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> DeletePost(int? id)
        {
            if (id != null)
            {
                Post post = await db.Posts.Include(u => u.Category).FirstOrDefaultAsync(p => p.Id == id);
                if (post != null)
                {
                    db.Posts.Remove(post);
                    await db.SaveChangesAsync();
                    return RedirectToAction("Posts");
                }
            }
            return NotFound();
        }

    }
}

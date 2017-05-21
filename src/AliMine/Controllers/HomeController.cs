using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AliMine.Models;
using Microsoft.EntityFrameworkCore;

namespace AliMine.Controllers
{
    public class HomeController : Controller
    {
        AliMineContext db;
        public HomeController(AliMineContext context)
        {
            db = context;
        }
        public async Task<IActionResult> Index()
        {
            IQueryable<Post> posts = db.Posts.Include(u => u.Category);

            return View(await posts.AsNoTracking().ToListAsync());

        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FPTStore.Data;
using FPTStore.Models;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Authorization;

namespace FPTStore.Controllers
{
   
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment webHost;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context, IWebHostEnvironment webHost)
        {
            _context = context;
            this.webHost = webHost;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            return _context.Book != null ?
                      View(await _context.Book.ToListAsync()) :
                      Problem("Entity set 'ApplicationDbContext.Book'  is null.");
            
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(string txt_key)
        {
            
            var BookContext = _context.Book.Where(m => m.Title.IndexOf(txt_key) >= 0);
            ViewBag.Count = BookContext.Count();
            ViewBag.soLuongPost = BookContext.Count();
            return View(await BookContext.ToListAsync());
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(/*new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier }*/);
        }
    }
}
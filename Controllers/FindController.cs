using FindIt.Data;
using FindIt.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FindIt.Controllers
{
    public class FindController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FindController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Items()
        {
            return View(_context.Items.ToList());
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
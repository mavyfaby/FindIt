using FindIt.Data;
using FindIt.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FindIt.Controllers
{
    public class ItemController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ItemController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult New()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add([Bind("Name,Category,DateLost,Location,Description")] ItemModel item)
        {
            using var memoryStream = new MemoryStream();
            IFormFile? image = Request.Form.Files[0];
            string? category = Request.Form["category"];

            if (category == null)
            {
                TempData["SnackbarMessage"] = "Please select a category";
                TempData["SnackbarType"] = "error";
                return View("New");
            }

            if (image == null) {
                TempData["SnackbarMessage"] = "Please select an image";
                TempData["SnackbarType"] = "error";
                return View("New");
            }

            Request.Form.Files[0].CopyToAsync(memoryStream);

            if (memoryStream.Length > 1024000)
            {
                TempData["SnackbarMessage"] = "The file is too large";
                TempData["SnackbarType"] = "error";
                return View("New");
            }

            item.Status = 1; // 1 = Lost
            item.StatusUpdated = DateTime.Now; // Current date
            item.Category = int.Parse(category);
            item.Image = memoryStream.ToArray();

            _context.Items.Add(item);
            _context.SaveChanges();

            TempData["SnackbarMessage"] = "Item added successfully";
            TempData["SnackbarType"] = "success";

            return RedirectToAction("Items", "Find");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
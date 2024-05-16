using FindIt.Data;
using FindIt.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
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
            // If no session, redirect to login
            if (HttpContext.Session.GetString("UserId") == null)
            {
                TempData["SnackbarMessage"] = "Please login to continue";
                return RedirectToAction("Login", "User");
            }

            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Add([Bind("Name,Category,DateFound,Location,Description")] ItemModel item)
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

            if (HttpContext.Session.GetString("UserId") == null)
            {
                TempData["SnackbarMessage"] = "Please login to continue";
                return RedirectToAction("Login", "User");
            }

            await Request.Form.Files[0].CopyToAsync(memoryStream);

            if (memoryStream.Length > 1024000)
            {
                TempData["SnackbarMessage"] = "The file is too large";
                TempData["SnackbarType"] = "error";
                return View("New");
            }

            item.Status = 1; // 1 = Lost
            item.UserId = int.Parse(HttpContext.Session.GetString("UserId")!); // User ID
            item.StatusUpdated = DateTime.Now; // Current date
            item.Category = int.Parse(category);
            item.Image = memoryStream.ToArray();
            item.DateStamp = DateTime.Now;

            _context.Items.Add(item);
            _context.SaveChanges();

            TempData["SnackbarMessage"] = "Item added successfully";
            TempData["SnackbarType"] = "success";

            return RedirectToAction("Items", "Find");
        }

        [HttpPost]
        public ActionResult Comment() {
            int itemId;
            int userId;
            string? text;

            try {
                bool IsParsed = int.TryParse(Request.Form["ItemId"], out itemId);

                if (!IsParsed) {
                    throw new Exception("Invalid ItemID");
                }

                IsParsed = int.TryParse(Request.Form["UserId"], out userId);

                if (!IsParsed) {
                    throw new Exception("Invalid UserID");
                }

                text = Request.Form["Text"];

                if (text?.Length == 0) {
                    throw new Exception("Comment cannot be empty");
                }

                // Save comment to database
                var commentModel = new CommentModel {
                    ItemId = itemId,
                    UserId = userId,
                    Text = text ?? "",
                    DateStamp = DateTime.Now
                };

                _context.Comments.Add(commentModel);
                _context.SaveChanges();

                return RedirectToAction("Items", "Find", new { id = itemId });
            } catch (Exception e) {
                TempData["SnackbarMessage"] = e.Message;
                TempData["SnackbarType"] = "error";
                return RedirectToAction("Items", "Find", 1);
            }
        }


        [HttpPost]
        public ActionResult Delete()
        {
            int itemId;

            try {
                bool IsParsed = int.TryParse(Request.Form["Id"], out itemId);

                if (!IsParsed) {
                    throw new Exception("Invalid ItemID");
                }
                
            } catch (Exception e) {
                TempData["SnackbarMessage"] = e.Message;
                TempData["SnackbarType"] = "error";
                return RedirectToAction("Account", "User");
            }

            var item = _context.Items.FirstOrDefault(i => i.Id == itemId);

            if (item == null)
            {
                TempData["SnackbarMessage"] = "Item not found";
                TempData["SnackbarType"] = "error";
                return RedirectToAction("Items", "Find");
            }

            _context.Items.Remove(item);
            _context.SaveChanges();

            TempData["SnackbarMessage"] = "Item deleted successfully";
            TempData["SnackbarType"] = "success";

            return RedirectToAction("Account", "User");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
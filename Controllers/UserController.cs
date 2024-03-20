using FindIt.Data;
using FindIt.Models;
using Microsoft.AspNetCore.Mvc;

namespace FindIt.Controllers
{
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UserController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Signup()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register([Bind("FirstName,LastName,Email,Username,Password,ConfirmPassword")] UserModel user)
        {
            // Check if password and confirm password match
            if (user.Password != user.ConfirmPassword)
            {
                ViewBag.SnackbarMessage = "Password and Confirm Password do not match";
                ViewBag.SnackbarType = "error";
                return View("Signup");
            }

            // Check if username already exists
            var userExists = _context.Users.FirstOrDefault(u => u.Username == user.Username);

            // If username exists, return error
            if (userExists != null)
            {
                ViewBag.SnackbarMessage = "Username already exists";
                ViewBag.SnackbarType = "error";
                return View("Signup");
            }

            // Check if email already exists
            var emailExists = _context.Users.FirstOrDefault(u => u.Email == user.Email);

            // If email exists, return error
            if (emailExists != null)
            {
                ViewBag.SnackbarMessage = "Email already exists";
                ViewBag.SnackbarType = "error";
                return View("Signup");
            }

            // Set datestamp
            user.DateStamp = DateTime.Now;

            // Add user to database
            _context.Users.Add(user);
            _context.SaveChanges();

            // Add message
            ViewBag.SnackbarMessage = "User registered successfully";
            ViewBag.SnackbarType = "success";

            return View("Signup");
        }
    }
}
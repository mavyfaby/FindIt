using FindIt.Models;
using Microsoft.AspNetCore.Mvc;

namespace FindIt.Controllers
{
    public class UserController : Controller
    {
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

            return View("Signup");
        }
    }
}
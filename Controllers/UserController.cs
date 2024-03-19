using FindIt.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

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
    }
}
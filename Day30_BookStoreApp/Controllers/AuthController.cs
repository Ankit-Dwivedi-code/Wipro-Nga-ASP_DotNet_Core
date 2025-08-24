using Microsoft.AspNetCore.Mvc;

namespace BookStoreApp.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}

using Microsoft.AspNetCore.Mvc;

namespace EcommerceWeb.Controllers
{
    public class HangHoaController : Controller
    {
        public IActionResult Index(int? loai)
        {
            return View();
        }
    }
}

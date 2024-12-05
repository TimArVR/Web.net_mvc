using Microsoft.AspNetCore.Mvc;

namespace WebNETFirstProj.Controllers
{
    public class WidgetController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

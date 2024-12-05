using Microsoft.AspNetCore.Mvc;

namespace WebNETFirstProj.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

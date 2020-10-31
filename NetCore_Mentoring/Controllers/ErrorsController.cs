using Microsoft.AspNetCore.Mvc;

namespace NetCore_Mentoring.API.Controllers
{
    public class ErrorsController : Controller
    {
        public IActionResult Index()
        {
            return View("Error");
        }
    }
}

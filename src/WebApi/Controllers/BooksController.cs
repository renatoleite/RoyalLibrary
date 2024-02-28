using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/v1/books")]
    [ApiController]
    public class BooksController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

using Microsoft.AspNetCore.Mvc;

namespace StoreApi.Controllers
{
    public class HomeController : Controller
    {
        // A principal função do Controller é controlar as requisições

        [HttpGet]
        [Route("rota/01")]
        public string Get()
        {
            return "Hello, world from Banana!";
        }
    }
}
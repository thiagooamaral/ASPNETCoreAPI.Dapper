using Microsoft.AspNetCore.Mvc;

namespace BaltaStore.Api.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        [Route("")]
        public string Get()
        {
            return "Hello world";
        }

        [HttpPost]
        [Route("")]
        public string Post()
        {
            return "Hello world";
        }

        [HttpPut]
        [Route("")]
        public string Put()
        {
            return "Hello world";
        }

        [HttpDelete]
        [Route("")]
        public string Delete()
        {
            return "Hello world";
        }
    }
}
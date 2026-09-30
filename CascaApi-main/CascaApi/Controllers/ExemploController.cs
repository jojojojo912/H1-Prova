using Microsoft.AspNetCore.Mvc;

namespace CascaApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExemploController : ControllerBase
    {
        [HttpGet(Name = "GetExemplo")]
        public string Get()
        {
            return "este é um exemplo de endpoint!";
        }
    }
}

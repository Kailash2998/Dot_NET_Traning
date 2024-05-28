using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ASPCoreWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FruitsAPIController : ControllerBase
    {
        public List<string> Fruits = new List<string>()
        {
            "Apple",
            "Banana",
            "Mango",
            "Cherry",
            "Graps"
        };

        [HttpGet]
        public List<string> GetFruits()
        {
            return Fruits;
        }

        [HttpGet("{id}")]
        public string GetFruitsByIndex(int id)
        {
            return Fruits.ElementAt(id);
        }
    }
}

using JwtAuthentication.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JwtAuthentication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        [Authorize]
        [HttpGet]
        [Route("GetData")]
        public String GetData()
        {
            return "Awethenticate with jwt";
        }

        [HttpGet]
        [Route("Details")]
        public String Details()
        {
            return "Awethenticate with jwt";
        }

        [Authorize]
        [HttpPost]
        public String AddUser(Users user)
        {
            return "user added with username" +  user.Username;
        }
    }
}

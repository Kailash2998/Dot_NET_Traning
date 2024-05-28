using AssignmentNo3.NetCore.Models;
using AssignmentNo3.NetCore.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AssignmentNo3.NetCore.Controllers
{
    /// <summary>
    /// Here We are use the Dependency Injection to call those Interfaces
    /// </summary>
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly ISingleton _transient1;
        private readonly ISingleton _transient2;

        private readonly IScoped _scoped1;
        private readonly IScoped _scoped2;

        private readonly ISingleton _singelton1;
        private readonly ISingleton _singelton2;
        /// <summary>
        /// Here we are Define those Interface
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="transient1"></param>
        /// <param name="transient2"></param>
        /// <param name="scoped1"></param>
        /// <param name="scoped2"></param>
        /// <param name="singelton1"></param>
        /// <param name="singelton2"></param>
        public HomeController(
            ILogger<HomeController> logger,
            ISingleton transient1,
            ISingleton transient2,
            IScoped scoped1,
            IScoped scoped2,
            ISingleton singelton1,
            ISingleton singelton2
        )
        {
            _logger = logger;
            _transient1 = transient1;
            _transient2 = transient2;
            _scoped1 = scoped1;
            _scoped2 = scoped2;
            _singelton1 = singelton1;
            _singelton2 = singelton2;
        }
        /// <summary>
        /// Here We are declear the data 
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            ViewBag.transient1 = _transient1.getServicesId().ToString();
            ViewBag.transient2 = _scoped1.getServicesId().ToString();
            ViewBag.scoped1 = _scoped1.getServicesId().ToString();
            ViewBag.scoped2 = _scoped1.getServicesId().ToString();
            ViewBag.singelton1 = _singelton1.getServicesId().ToString();
            ViewBag.singelton2 = _singelton2.getServicesId().ToString();

            return View();
        }
        
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

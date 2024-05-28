using CrudOperation.NetCore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace CrudOperation.NetCore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ProductDbContext productDb;

        /// <summary>
        /// Constructor for the Product
        /// </summary>
        /// <param name="productDb"></param>
        public HomeController(ProductDbContext productDb)
        {
            this.productDb = productDb;
        }
        /// <summary>
        /// For show the List of the Product
        /// </summary>
        /// <returns></returns>
        public async Task <IActionResult> Index()
        {
            var dtsData = await productDb.Products.ToListAsync();
            return View(dtsData);
        }

        /// <summary>
        /// For Get the Create Form
        /// </summary>
        /// <returns></returns>
        public IActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// For create the form and post the data
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task <IActionResult> Create(Product product)
        {
            if(ModelState.IsValid)
            {
               await productDb.Products.AddAsync(product);
               await productDb.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(product);
        }

        /// <summary>
        /// For check the details of the data
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Details(int id)
        {
            if(id == null || productDb.Products == null)
            {
                return NotFound();
            }
            var dtsData = await productDb.Products.FirstOrDefaultAsync(x => x.Id == id);
            if(dtsData == null)
            {
                return NotFound();
            }
            return View(dtsData);
        }

        /// <summary>
        /// For Getting the edit foem for the Edit
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dtsData = await productDb.Products.FindAsync(id);
            if (dtsData == null)
            {
                return NotFound();
            }

            return View(dtsData);
        }

        /// <summary>
        /// For Update the data 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="product"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task <IActionResult> Edit(int? id, Product product)
        {
            if(id != product.Id)
            {
                return NotFound();
            }
            if(ModelState.IsValid)
            {
                productDb.Products.Update(product);
                await productDb.SaveChangesAsync(); 
                return RedirectToAction("Index");
            }
            return View(product);
        }

        /// <summary>
        /// Getting the data for delete
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task <IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var dtsData = await productDb.Products.FirstOrDefaultAsync(x => x.Id == id);
            if (dtsData == null)
            {
                return NotFound();
            }
            return View(dtsData);
        }

        /// <summary>
        /// For conformation of delete
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost,ActionName("Delete")]
        public async Task<IActionResult> DeleteConfrimed(int? id)
        {
            var dtsData = await productDb.Products.FindAsync(id);
            if(dtsData != null)
            {
                productDb.Products.Remove(dtsData);
            }
            await productDb.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        /// <summary>
        /// for go to o the privacy page
        /// </summary>
        /// <returns></returns>
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

using Microsoft.AspNetCore.Mvc;
using ForgenKeyRelationship.NetCore.Models;
using ForgenKeyRelationship.NetCore.Repository.Interface;
namespace ForgenKeyRelationship.NetCore.Controllers
{

    public class PublisherController : Controller
    {
        private readonly IRepository<Publisher> _publisherService;

        public PublisherController(IRepository<Publisher> publisherService)
        {
            _publisherService = publisherService;
        }

        /// <summary>
        ///  GET Publisher list
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> GetPublisherList()
        {
            try
            {
                var publishers = await _publisherService.GetAll();
                if (publishers == null)
                {
                    return View(new List<Publisher>());
                }
                return View(publishers);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while retrieving publishers: {ex.Message}");
            }
        }

        /// <summary>
        ///  GET Publisher Details using id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Details(int id)
        {
            try
            {
                var publisher = await _publisherService.GetById(id);
                if (publisher == null)
                {
                    return NotFound();
                }
                return View(publisher);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while retrieving publisher details: {ex.Message}");
            }
        }

        /// <summary>
        /// Create Publisher
        /// </summary>
        /// <returns></returns>
        public IActionResult Create()
        {
            return View();
        }

        /// <summary>
        ///  POST method for Create Publisher
        /// </summary>
        /// <param name="publisher"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Address")] Publisher publisher)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _publisherService.Create(publisher);
                    return RedirectToAction(nameof(GetPublisherList));
                }
                return View(publisher);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while creating publisher: {ex.Message}");
            }
        }

        /// <summary>
        /// Edit Publisher by using id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var publisher = await _publisherService.GetById(id);
                if (publisher == null)
                {
                    return NotFound();
                }
                return View(publisher);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while retrieving publisher for editing: {ex.Message}");
            }
        }

        /// <summary>
        /// update Publisher by id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="publisher"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, [Bind("PublisherId, Name, Address")] Publisher publisher)
        {
            Console.WriteLine("Hello from the model Controller");


            if (ModelState.IsValid)
            {
                await _publisherService.Update(publisher);
                return RedirectToAction(nameof(GetPublisherList));
            }

            return View(publisher);
        }

        /// <summary>
        /// Delete Publisher using id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var publisher = await _publisherService.GetById(id);
                if (publisher == null)
                {
                    return NotFound();
                }
                return View(publisher);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while retrieving publisher for deletion: {ex.Message}");
            }
        }

        /// <summary>
        ///  conformation for Delete Publisher
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                await _publisherService.Delete(id);
                return RedirectToAction(nameof(GetPublisherList));
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while deleting publisher: {ex.Message}");
            }
        }
    }
}

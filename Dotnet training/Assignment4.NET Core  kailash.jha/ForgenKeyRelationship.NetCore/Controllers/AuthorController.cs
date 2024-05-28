using ForgenKeyRelationship.NetCore.Models;
using ForgenKeyRelationship.NetCore.Repository.Interface;
using Microsoft.AspNetCore.Mvc;

namespace ForgenKeyRelationship.NetCore.Controllers
{
    public class AuthorController : Controller
    {
        private readonly IRepository<Author> _authorService;

        public AuthorController(IRepository<Author> authorService)
        {
            _authorService = authorService;
        }

       /// <summary>
       /// get the author list
       /// </summary>
       /// <returns></returns>
        public async Task<IActionResult> GetAllAuthor()
        {
            var authors = await _authorService.GetAll();
            return View(authors);
        }

       /// <summary>
       /// for open the create form for create the author
       /// </summary>
       /// <returns></returns>
        public IActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// post method for create the author
        /// </summary>
        /// <param name="author"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Bio")] Author author)
        {
            Console.WriteLine("Hello from the post method");
            try
            {
                if (ModelState.IsValid)
                {
                    await _authorService.Create(author);
                    return RedirectToAction(nameof(GetAllAuthor));
                }
                return View(author);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while creating publisher: {ex.Message}");
            }
        }

        /// <summary>
        /// get the edit for for the author using id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Edit(int id)
        {
            var author = await _authorService.GetById(id);
            if (author == null)
            {
                return NotFound();
            }
            return View(author);
        }

       /// <summary>
       /// updae the author using id
       /// </summary>
       /// <param name="id"></param>
       /// <param name="author"></param>
       /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, [Bind("AuthorId,Name,Bio")] Author author)
        {
            try
            {
                await Console.Out.WriteLineAsync("Hello form the post method for edit");

                if (ModelState.IsValid)
                {
                    await _authorService.Update(author);
                    return RedirectToAction(nameof(GetAllAuthor));
                }
                return View(author);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while updating author: {ex.Message}");
            }
        }

        /// <summary>
        /// for open the details form using id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Details(int id)
        {
            try
            {
                var author = await _authorService.GetById(id);
                if (author == null)
                {
                    return NotFound();
                }
                return View(author);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while retrieving publisher details: {ex.Message}");
            }
        }

        /// <summary>
        /// get the open the delete form using id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Delete(int id)
        {
            var author = await _authorService.GetById(id);
            if (author == null)
            {
                return NotFound();
            }
            return View(author);
        }

       /// <summary>
       /// confirmation of delete using id
       /// </summary>
       /// <param name="id"></param>
       /// <returns></returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                await _authorService.Delete(id);
                return RedirectToAction(nameof(GetAllAuthor));
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while deleting author: {ex.Message}");
            }
        }
    }
}

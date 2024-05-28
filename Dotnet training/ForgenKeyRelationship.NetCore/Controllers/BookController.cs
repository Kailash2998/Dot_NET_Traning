


using ForgenKeyRelationship.NetCore.Models;
using ForgenKeyRelationship.NetCore.Repository.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ForgenKeyRelationship.NetCore.Controllers
{
    public class BookController : Controller
    {
        private readonly IRepository<Book> _bookService;
        private readonly IRepository<Author> _authorService;
        private readonly IRepository<Publisher> _publisherService;

        public BookController(IRepository<Book> bookService, IRepository<Author> authorService, IRepository<Publisher> publisherService)
        {
            _bookService = bookService;
            _authorService = authorService;
            _publisherService = publisherService;
        }

        /// <summary>
        ///  List of Books
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> GetAllBooks()
        {
            var books = await _bookService.GetAllWithIncludes();

            return View(books);
        }



        /// <summary>
        /// Create Book
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Create()
        {
            var authors = await _authorService.GetAll();
            var publishers = await _publisherService.GetAll();

            ViewBag.Authors = new SelectList(authors, "AuthorId", "Name");
            ViewBag.Publishers = new SelectList(publishers, "PublisherId", "Name");

            return View();
        }

        /// <summary>
        /// Post method for crate Book
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Title,ISBN,PublicationDate,Price,Genre,AuthorId,PublisherId")] Book book)
        {
            Console.WriteLine("Hello from the Create post methods");
            try
            {
                await _bookService.Create(book);
                return RedirectToAction(nameof(GetAllBooks));

                var authors = await _authorService.GetAll();
                var publishers = await _publisherService.GetAll();

                ViewBag.Authors = new SelectList(authors, "AuthorId", "Name");
                ViewBag.Publishers = new SelectList(publishers, "PublisherId", "Name");
                return View(book);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while creating the book: {ex.Message}");
            }
        }

        /// <summary>
        /// Edit form for the Book
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Edit(int id)
        {
            var book = await _bookService.GetByIdAsync(id);
            if (book == null)
            {
                return NotFound();
            }

            var authors = await _authorService.GetAll();
            var publishers = await _publisherService.GetAll();

            ViewBag.Authors = new SelectList(authors, "AuthorId", "Name", book.AuthorId);
            ViewBag.Publishers = new SelectList(publishers, "PublisherId", "Name", book.PublisherId);

            return View(book);
        }

        /// <summary>
        /// Update the Book using id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="book"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, [Bind("BookId,Title,ISBN,PublicationDate,Price,Genre,AuthorId,PublisherId")] Book book)
        {
            Console.WriteLine("Hello from the update Book methods");
            try
            {
                await _bookService.Update(book);
                return RedirectToAction(nameof(GetAllBooks));

                var authors = await _authorService.GetAll();
                var publishers = await _publisherService.GetAll();
                ViewBag.Authors = new SelectList(authors, "AuthorId", "Name", book.AuthorId);
                ViewBag.Publishers = new SelectList(publishers, "PublisherId", "Name", book.PublisherId);
                return View(book);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while updating the book: {ex.Message}");
            }
        }

       /// <summary>
       /// Show the details of the Book
       /// </summary>
       /// <param name="id"></param>
       /// <returns></returns>
        public async Task<IActionResult> Details(int id)
        {

            var book = await _bookService.GetById(id);
            if (book == null)
            {
                return NotFound();
            }
            var authors = await _authorService.GetAll();
            var publishers = await _publisherService.GetAll();

            ViewBag.Authors = new SelectList(authors, "AuthorId", "Name", book.AuthorId);
            ViewBag.Publishers = new SelectList(publishers, "PublisherId", "Name", book.PublisherId);
            return View(book);
        }

        /// <summary>
        /// for delete the book using id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Delete(int id)
        {
            var book = await _bookService.GetById(id);
            if (book == null)
            {
                return NotFound();
            }
            var authors = await _authorService.GetAll();
            var publishers = await _publisherService.GetAll();

            ViewBag.Authors = new SelectList(authors, "AuthorId", "Name", book.AuthorId);
            ViewBag.Publishers = new SelectList(publishers, "PublisherId", "Name", book.PublisherId);
            return View(book);

            return View(book);
        }

       /// <summary>
       /// confirmation for the delete
       /// </summary>
       /// <param name="id"></param>
       /// <returns></returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                await _bookService.Delete(id);
                return RedirectToAction(nameof(GetAllBooks));
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while deleting the book: {ex.Message}");
            }
        }
    }
}

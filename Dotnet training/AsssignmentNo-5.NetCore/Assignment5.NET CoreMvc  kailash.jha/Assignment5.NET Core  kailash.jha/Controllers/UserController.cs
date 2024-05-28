using AsssignmentNo_5.NetCore.Models;
using AsssignmentNo_5.NetCore.Repository.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AsssignmentNo_5.NetCore.Controllers
{
    public class UserController : Controller
    {
        private readonly IUser userRepository;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="userRepository"></param>
        public UserController(IUser userRepository)
        {
            this.userRepository = userRepository;
        }

        /// <summary>
        /// Get All user List and display
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> GetAllUserList()
        {
            var data = await userRepository.GetUsers();
            return View(data);
        }

        /// <summary>
        /// For Open the create form or getmapping for the create form
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Create()
        {
            return View();
        }

        /// <summary>
        /// Post method for create the User
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddUser(User user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await userRepository.AddUser(user);
                    return RedirectToAction("GetAllUserList");
                }
                else
                {
                    return View(user);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "An error occurred while processing your request.");
                return View(user);
            }
        }

        /// <summary>
        /// Get details of the user
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Details(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var user = await userRepository.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

       /// <summary>
       /// get edit for the the user by user Id
       /// </summary>
       /// <param name="id"></param>
       /// <returns></returns>
        public async Task<IActionResult> Edit(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var user = await userRepository.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        /// <summary>
        /// Post method for update the user
        /// </summary>
        /// <param name="id"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, User user)
        {
            if (id != user.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await userRepository.UpdateUser(user);
                    return RedirectToAction(nameof(GetAllUserList)); 
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
            }
            return View(user);
        }

       /// <summary>
       /// get delete form for asking the conformation
       /// </summary>
       /// <param name="id"></param>
       /// <returns></returns>
        public async Task<IActionResult> Delete(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var user = await userRepository.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        /// <summary>
        /// post method for delete the user
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await userRepository.DeleteUser(id);
            return RedirectToAction(nameof(GetAllUserList));
        }
    }
}

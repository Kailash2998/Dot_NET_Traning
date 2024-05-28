using AsssignmentNo_5.NetCore.Data;
using AsssignmentNo_5.NetCore.Models;
using AsssignmentNo_5.NetCore.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace AsssignmentNo_5.NetCore.Repository.Service
{
    /// <summary>
    /// Create Services
    /// </summary>
    public class UserService : IUser
    {
        private readonly ApplicationContext context;
        public UserService(ApplicationContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// For getting the list of users
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<User>> GetUsers()
        {
            var data = await context.Users.ToListAsync();
            return data;
        }

        /// <summary>
        /// For Create the user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task<int> AddUser(User user)
        {
            await context.Users.AddAsync(user);
            await context.SaveChangesAsync();
            return user.Id;
        }

        /// <summary>
        /// For view The Edit Form of the users
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<User> GetUserById(int id)
        {
            return await context.Users.FirstOrDefaultAsync(x => x.Id == id);
        }

        /// <summary>
        /// For update the Users
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task<int> UpdateUser(User user)
        {
            context.Entry(user).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return user.Id;
        }

        /// <summary>
        /// For Show the Delete Of the user
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<int> DeleteUser(int id)
        {
            var user = await context.Users.FindAsync(id);
            if (user == null)
                return 0;

            context.Users.Remove(user);
            await context.SaveChangesAsync();
            return user.Id;
        }
    }
}

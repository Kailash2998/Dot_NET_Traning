using AsssignmentNo_5.NetCore.Models;

namespace AsssignmentNo_5.NetCore.Repository.Interface
{
    /// <summary>
    /// Create The InteFace For performing the crud
    /// </summary>
    public interface IUser
    {
        Task<IEnumerable<User>> GetUsers();

        Task<int> AddUser(User user);

        Task<User> GetUserById(int id);

        Task<int> UpdateUser(User user);

        Task<int> DeleteUser(int id);
    }
}

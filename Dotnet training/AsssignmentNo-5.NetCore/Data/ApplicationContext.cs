using AsssignmentNo_5.NetCore.Models;
using Microsoft.EntityFrameworkCore;

namespace AsssignmentNo_5.NetCore.Data
{
    public class ApplicationContext :DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext>options) :base(options)
        {

        }
        public DbSet<User> Users { get; set; }
    }
}

using Microsoft.EntityFrameworkCore;
using MVC_Week2_Project1.Models;

namespace MVC_Week2_Project1.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }


        public DbSet<Student> Students { get; set; }
    }
}

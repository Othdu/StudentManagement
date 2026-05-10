using Microsoft.EntityFrameworkCore;

namespace EFCoreDemo
{
    public class AppDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }

      
        public DbSet<Course> Courses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer("Server=OTHDU-PC;Database=EFCoreDB;Integrated Security=True;TrustServerCertificate=True;Encrypt=False;");
        }
    }
}

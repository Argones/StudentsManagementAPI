using Microsoft.EntityFrameworkCore;
using StudentsManagementAPI.Models;

namespace StudentsManagementAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) 
        {

        }

        public DbSet<Student> Students { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=studentsdb;Trusted_Connection=true;TrustServerCertificate=true");
        }
    }
}

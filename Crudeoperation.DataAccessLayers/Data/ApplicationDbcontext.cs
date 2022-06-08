using Crudeoperation.Models;
using Crudoperation.Models;
using Microsoft.EntityFrameworkCore;

namespace Crudeoperation.DataAccessLayer
{
    public class ApplicationDbcontext : DbContext
    {
        public ApplicationDbcontext(DbContextOptions<ApplicationDbcontext> options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
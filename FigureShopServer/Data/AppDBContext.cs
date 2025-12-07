using Microsoft.EntityFrameworkCore;
using FigureShopSharedLibrary.Models;

namespace FigureShopServer.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {

        }
        public DbSet<Product> Products { get; set; } = default!;

    }
}
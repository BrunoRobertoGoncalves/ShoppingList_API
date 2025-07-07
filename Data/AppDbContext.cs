using ListaDeCompras.Models;
using Microsoft.EntityFrameworkCore;


namespace ListaDeCompras.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) 
            : base(options) { }

        public DbSet<Compra> Compras { get; set; }
    }
}
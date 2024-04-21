using PrinterApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace PrinterApi.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Printer> Printers { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Printer>().ToTable("Printers");
        }
    }
}

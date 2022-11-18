using MaskDemo.Models;
using Microsoft.EntityFrameworkCore;

namespace MaskDemo.Data
{
    public class MaskContext:DbContext
    {
        public MaskContext(DbContextOptions<MaskContext> options) : base (options)
        {
        }
        public DbSet<Mask> Masks { get; set; }
        public DbSet<MaskType> MaskType { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Mask>()
                .HasOne<MaskType>(m=>m.MaskType)
                .WithMany(m=>m.Masks)
                .HasForeignKey(m=>m.MaskTypeId)
                .OnDelete(DeleteBehavior.Restrict); 
        }
    }
}

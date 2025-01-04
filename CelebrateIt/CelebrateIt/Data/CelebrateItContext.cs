
using CelebrateIt.Models;
using Microsoft.EntityFrameworkCore;

namespace CelebrateIt.Data
{
    public class CelebrateItContext:DbContext
    {

        public DbSet<Users>Users { get; set; }
    
        public DbSet<Facilities> Facilities { get; set; }

        public DbSet<Feedback> feedback { get; set; }

        public DbSet<Bookings> Bookings { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("host=localhost;database=CelebrateItDotNet;user=root;password=cdac", new MySqlServerVersion(new Version(8, 0, 31)));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure enums to store as strings
            modelBuilder.Entity<Bookings>()
                .Property(b => b.BookingStatus)
                .HasConversion<string>()
                .HasDefaultValue(BookingStatus.PENDING); // Default to Pending

            modelBuilder.Entity<Bookings>()
                .Property(b => b.PaymentStatus)
                .HasConversion<string>()
                .HasDefaultValue(PaymentStatus.PARTIAL); // Default to Unpaid

            modelBuilder.Entity<Bookings>()
                .Property(b => b.PaymentMethod)
                .HasConversion<string>();

            modelBuilder.Entity<Users>()
                 .Property(u => u.UserRole)
                 .HasConversion<string>(); 

            modelBuilder.Entity<Categories>()
                .Property(c => c.ParentCategory)
                .HasConversion<string>();

            
        }




    }
}

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SafeRent.DataAccess.Models;

namespace SafeRent.DataAccess.Data
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public virtual  DbSet<Apartment> Apartments { get; set; }
        public virtual DbSet<Notification> Notifications { get; set; }    
        
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            
            builder.Entity<ApplicationUserApartment>()
                .HasKey(au => new {au.ApartmentId, au.ApplicationUserId});
            builder.Entity<ApplicationUserApartment>()
                .HasOne(au => au.Apartment)
                .WithMany(a => a.ApplicationUserApartments)
                .HasForeignKey(ac => ac.ApartmentId);
            builder.Entity<ApplicationUserApartment>()
                .HasOne(au => au.ApplicationUser)
                .WithMany(a => a.ApplicationUserApartments)
                .HasForeignKey(ac => ac.ApplicationUserId);
        }
    }
}
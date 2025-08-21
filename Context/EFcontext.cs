using Federation_proj.Models;
using Microsoft.EntityFrameworkCore;

namespace Federation_proj.Context;

public class EFcontext  : DbContext

{
   public DbSet<Staff> Staff{ get; set; }
    public DbSet<Club> Club { get; set; }
   // public DbSet<Address> Address { get; set; }
   public DbSet<Federation> Federation { get; set; }
    
    public EFcontext(DbContextOptions<EFcontext> options) : base(options)
    {
    }
    

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // STAFF
        modelBuilder.Entity<Staff>()
            .HasKey(p => p.Id);
        modelBuilder.Entity<Staff>()
            .Property(p => p.Id)
            .ValueGeneratedOnAdd();
        modelBuilder.Entity<Staff>()
            .Property(p => p.Email)
            .IsRequired();

        modelBuilder.Entity<Federation>()
            .HasKey(p => p.FederationId);
        modelBuilder.Entity<Federation>()
            .Property(p => p.FederationId)
            .ValueGeneratedOnAdd();
 
        
        // modelBuilder.Entity<Address>(e =>
        // {
        //     e.HasKey(p => p.Id);
        //         e.Property(p => p.Id)
        //         .ValueGeneratedOnAdd();
        //     e.Property(p => p.AddressLine1)
        //         .IsRequired();
        // });
        
        // Address
        // modelBuilder.Entity<Address>()
        //     .HasKey(p => p.Id);
        // modelBuilder.Entity<Address>()
        // .Property(p => p.Id)
        // .ValueGeneratedOnAdd();
        // modelBuilder.Entity<Address>()
        //     .Property(p => p.AddressLine1)
        //     .IsRequired();
        
        // Club
        modelBuilder.Entity<Club>()
            .HasKey(p => p.Id);
        // modelBuilder.Entity<Club>()
        //     .HasMany(p => p.Staffs)
        //     .WithOne(p => p.Club)
        //     .HasForeignKey(p => p.ClubId)
        //     .OnDelete(DeleteBehavior.Cascade);
        // modelBuilder.Entity<Club>()
        //     .HasMany(p => p.Addresses)
        //     .WithOne(p => p.Club)
        //     .HasForeignKey(p => p.ClubId)
        //     .OnDelete(DeleteBehavior.Cascade);
        // modelBuilder.Entity<Club>()
        //     .HasOne(p => p.Federation)
        //     .WithMany(p => p.Clubs)
        //     .HasForeignKey(p => p.FederationId);
    }
    
    
    
}
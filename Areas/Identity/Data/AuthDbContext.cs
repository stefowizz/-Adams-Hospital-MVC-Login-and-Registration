using AuthSystem2.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using AuthSystem2.Models;

namespace AuthSystem2.Data;

public class AuthDbContext : IdentityDbContext<ApplicationUser>
{
    public AuthDbContext(DbContextOptions<AuthDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }

public DbSet<AuthSystem2.Models.Appointment> Points { get; set; } = default!;

public DbSet<AuthSystem2.Models.PatientMedHx> PatientMedHx { get; set; } = default!;

public DbSet<AuthSystem2.Models.Prescription> Prescription { get; set; } = default!;
}

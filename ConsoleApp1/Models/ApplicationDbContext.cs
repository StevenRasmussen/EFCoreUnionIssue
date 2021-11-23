using Microsoft.EntityFrameworkCore;

namespace ConsoleApp1.Models
{
    internal class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<LicenseBase> Licenses { get; set; } = null!;

        public DbSet<PurchasedLicense> PurchasedLicenses { get; set; } = null!;

        public DbSet<FreeLicense> FreeLicenses { get; set; } = null!;

        public DbSet<TrialLicense> TrialLicenses { get; private set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var licenseBase = modelBuilder.Entity<LicenseBase>();
            licenseBase.ToTable("LicenseBase");
            licenseBase.HasMany(x => x.Registrations).WithOne(x => x.License);
        }
    }
}

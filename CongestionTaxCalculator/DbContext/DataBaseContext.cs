using CongestionTaxCalculator.Models.MaxTax;
using CongestionTaxCalculator.Models.TaxFee;
using CongestionTaxCalculator.Models.TaxFreeRules;
using Microsoft.EntityFrameworkCore;

namespace CongestionTaxCalculator.DbContext
{
    public class DataBaseContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public DbSet<TaxFee> TaxFees { get; set; }
        public DbSet<TaxFreeDate> TaxFreeDates { get; set; }
        public DbSet<TaxFreeDayOfWeek> TaxFreeDayOfWeeks { get; set; }
        public DbSet<TaxFreeMonth> TaxFreeMonths { get; set; }
        public DbSet<TaxFreeRule> TaxFreeRules { get; set; }
        public DbSet<TaxFreeVehicle> TaxFreeVehicles { get; set; }
        public DbSet<MaxTax> MaxTaxes { get; set; }
        public DataBaseContext()
        {
        }
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assembly = GetType().Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
#if DEBUG

            optionsBuilder
                .UseSqlServer("Server=localhost\\SQLEXPRESS01;Initial Catalog=TaxDB;Persist Security Info=True;MultipleActiveResultSets=true;User ID=sa;Password=123;TrustServerCertificate=Yes");

#endif
            base.OnConfiguring(optionsBuilder);
        }
    }
}

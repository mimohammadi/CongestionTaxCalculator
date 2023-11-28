using CongestionTaxCalculator.Models.TaxFreeRules;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using CongestionTaxCalculator.Models.MaxTax;

namespace CongestionTaxCalculator.DbContext.Configuration
{
    public class MaxTaxEfConfig : IEntityTypeConfiguration<MaxTax>
    {
        public void Configure(EntityTypeBuilder<MaxTax> builder)
        {
            builder.HasQueryFilter(a => a.IsDeleted == false);
        }
    }
}

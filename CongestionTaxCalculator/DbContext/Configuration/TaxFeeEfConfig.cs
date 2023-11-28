using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using CongestionTaxCalculator.Models.TaxFee;

namespace CongestionTaxCalculator.DbContext.Configuration
{
    public class TaxFeeEfConfig : IEntityTypeConfiguration<TaxFee>
    {
        public void Configure(EntityTypeBuilder<TaxFee> builder)
        {
            builder.HasQueryFilter(a => a.IsDeleted == false);
        }
    }
}

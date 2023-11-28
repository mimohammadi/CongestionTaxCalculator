using CongestionTaxCalculator.Models.TaxFee;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using CongestionTaxCalculator.Models.TaxFreeRules;

namespace CongestionTaxCalculator.DbContext.Configuration
{
    public class TaxFreeRuleEfConfig : IEntityTypeConfiguration<TaxFreeRule>
    {
        public void Configure(EntityTypeBuilder<TaxFreeRule> builder)
        {
            builder.HasQueryFilter(a => a.IsDeleted == false);
        }
    }
   
}

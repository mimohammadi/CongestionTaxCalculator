using CongestionTaxCalculator.Enums;

namespace CongestionTaxCalculator.Models.TaxFreeRules
{
    public class TaxFreeVehicle:TaxFreeRule
    {
        public Vehicles Vehicle { get; private set; }
        protected TaxFreeVehicle()
        {
            
        }

        public TaxFreeVehicle(Vehicles vehicle)
        {
            Category = RuleCategory.Vehicle;
            Vehicle = vehicle;
        }

        public void Update(Vehicles vehicle)
        {
            Vehicle = vehicle;
        }
    }
}

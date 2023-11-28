namespace CongestionTaxCalculator.Dto
{
    public class MaxTaxDto
    {
        public int Id { get; set; }
        public int MaxAmount { get; set; }
    }

    public class MaxTaxCreateDto
    {
        public int MaxAmount { get; set; }
    }
}

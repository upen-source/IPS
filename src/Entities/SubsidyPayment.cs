namespace Entities
{
    public class SubsidyPayment : ModeratorFeePayment
    {
        private const double Discount = 0.5;

        public override double ComputeFee() => ServicePrice * Discount;

        public override string GetMembership() => "subsidiado";

        protected override double GetMaximum() => 200_000;
    }
}

namespace Entities
{
    public class ContributoryPayment : ModeratorFeePayment
    {
        public override double ComputeFee()
        {
            double[] feeDiscounts = { 0.15, 0.2, 0.25 };
            return Patient.Earnings * feeDiscounts[(int)Patient.Category];
        }

        public override string GetMembership() => "contributivo";

        protected override double GetMaximum()
        {
            int[] maximumPayments = { 250_000, 900_000, 1_500_00 };
            return maximumPayments[(int)Patient.Category];
        }
    }
}

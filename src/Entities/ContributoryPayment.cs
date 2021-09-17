using System;

namespace Entities
{
    public class ContributoryPayment : ModeratorFeePayment
    {
        private readonly int[]    _maximumPayments = { 250_000, 900_000, 1_500_000 };
        private readonly double[] _feeDiscounts    = { 0.15, 0.2, 0.25 };


        public ContributoryPayment(string id, DateTime date, double servicePrice,
            Patient patient) : base(id, date, servicePrice, patient)
        {
        }

        public ContributoryPayment()
        {
        }

        public override double ComputeFee() =>
            Patient.Earnings * _feeDiscounts[(int)Patient.Category];

        public override string GetMembership() => "contributivo";

        protected override double GetMaximum() => _maximumPayments[(int)Patient.Category];
    }
}

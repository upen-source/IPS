using System;

namespace Entities
{
    public abstract class ModeratorFeePayment
    {
        public string   Id              { get; init; }
        public DateTime Date            { get; init; }
        public double   ServicePrice    { get; init; }
        public Patient  Patient         { get; init; }
        public bool     WasMaxApplied   { get; private set; }
        public double   OriginalPayment { get; protected set; }

        public abstract double ComputeFee();
        public abstract string GetMembership();

        protected abstract double GetMaximum();

        protected double ApplyMaximum(double payment)
        {
            double maximumPayment = GetMaximum();
            if (payment <= maximumPayment) return payment;

            OriginalPayment = payment;
            WasMaxApplied   = true;
            return maximumPayment;
        }

        public double ComputePayment() => ApplyMaximum(ServicePrice * ComputeFee());
    }
}

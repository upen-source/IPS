using System;
using Newtonsoft.Json;

namespace Entities
{
    public abstract class ModeratorFeePayment
    {
        public string   Id           { get; init; }
        public DateTime Date         { get; init; }
        public double   ServicePrice { get; init; }
        public Patient  Patient      { get; init; }

        public bool WasMaxApplied { get; private set; }

        [JsonIgnore]
        public double OriginalPayment { get; private set; }

        protected ModeratorFeePayment(string id, DateTime date, double servicePrice,
            Patient patient)
        {
            Id            = id;
            Date          = date;
            ServicePrice  = servicePrice;
            Patient       = patient;
            WasMaxApplied = false;
        }

        protected ModeratorFeePayment()
        {
        }

        public abstract double ComputeFee();
        public abstract string GetMembership();
        protected abstract double GetMaximum();

        private double ApplyMaximum(double payment)
        {
            double maximumPayment = GetMaximum();
            if (payment <= maximumPayment) return payment;

            OriginalPayment = payment;
            WasMaxApplied   = true;
            return maximumPayment;
        }

        public double ComputePayment() => ApplyMaximum(ServicePrice * ComputeFee());

        public override string ToString()
        {
            return $"{{ Id: {Id}, Fecha: {Date}, Precio: {ServicePrice}, Paciente: {Patient} }}";
        }
    }
}

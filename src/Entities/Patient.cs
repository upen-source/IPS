namespace Entities
{
    public class Patient
    {
        public string Id       { get; }
        public double Earnings { get; }

        private const double MinimumEarning = 908_526;

        public Patient(string id, double earnings)
        {
            Id       = id;
            Earnings = earnings;
        }

        public PatientCategory Category => Earnings switch
        {
            < 2 * MinimumEarning => PatientCategory.First,
            < 5 * MinimumEarning => PatientCategory.Second,
            _ => PatientCategory.Third
        };
    }
}

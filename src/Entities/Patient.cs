using Newtonsoft.Json;

namespace Entities
{
    public class Patient
    {
        public string Id       { get; init; }
        public double Earnings { get; init; }

        [JsonIgnore]
        private const double MinimumEarning = 908_526;

        [JsonIgnore]
        public PatientCategory Category => Earnings switch
        {
            < 2 * MinimumEarning => PatientCategory.First,
            <= 5 * MinimumEarning => PatientCategory.Second,
            _ => PatientCategory.Third
        };

        [JsonConstructor]
        public Patient(string id, double earnings)
        {
            Id       = id;
            Earnings = earnings;
        }
    }
}

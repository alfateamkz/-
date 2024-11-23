namespace Alfateam.Services.CurrencyRates.API.Models
{
    public class FixerAPIRatesResponse
    {
        public bool Success { get; set; }
        public int Timestamp { get; set; }


        public string Base { get; set; }
        public DateTime Date { get; set; }

        public Dictionary<string, double> Rates { get; set; } = new Dictionary<string, double>();

    }

    //public class FixerAPIRate
    //{
    //    public string 
    //}
}

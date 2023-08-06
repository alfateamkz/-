using Alfateam2._0.Models.ContentItems;
using Alfateam2._0.Models.General;

namespace Alfateam.Website.API.Abstractions
{
    /// <summary>
    /// Клиентская модель (которая отдается по API)
    /// </summary>
    public abstract class ClientModel
    {
        public int Id { get; set; }



        protected static List<Cost> GetLocalCosts(PricingMatrix matrix,int? countryId)
        {
            //TODO: надо инклюдить валюту

            PricingMatrixItem found = null;

            if (countryId != null)
            {
                found = matrix.Costs.FirstOrDefault(o => o.CountryId == countryId);
                if(found != null) return found.Costs;
            }

            found = matrix.Costs.FirstOrDefault(o => o.CountryId == null);
            if (found != null) return found.Costs;

            found = matrix.Costs.FirstOrDefault(o => o.Costs.Any(o => o.Currency.Code == "USD"));
            if (found != null) return found.Costs;

            found = matrix.Costs.FirstOrDefault(o => o.Costs.Any(o => o.Currency.Code == "EUR"));
            if (found != null) return found.Costs;

            found = matrix.Costs.FirstOrDefault();
            return found.Costs;

        }


        protected static string GetActualValue(string oldStr, string newStr)
        {
            if (string.IsNullOrEmpty(newStr))
                return oldStr;
            return newStr;
        }
        protected static Content GetActualValue(Content oldValue, Content newValue)
        {
            if (newValue == null || newValue.Items.Count == 0)
            {
                return oldValue;
            }
            return newValue;
        }
        protected static object GetActualValue(object oldValue, object newValue)
        {
            if (newValue == null)
            {
                return oldValue;
            }
            return newValue;
        }
    }
}

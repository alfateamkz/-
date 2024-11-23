using Alfateam.Sales.Models.General;

namespace Alfateam.Sales.API.Models.Analytics.Leads.CommonAnalysis
{
    public class LeadsCommonAnalysisManager
    {
        public User Manager { get; set; }
        public int ActiveLeadsCount { get; set; }
        public int ConvertedLeadsCount { get; set; }
        public int RejectedLeadsCount { get; set; }


        public double LostPercent { get; set; }
        public double ConversionRate { get; set; }
    }
}

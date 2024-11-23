using Alfateam.Sales.Models.Leads.Kanban;

namespace Alfateam.Sales.API.Models.Analytics.Leads.CommonAnalysis
{
    public class LeadsCommonAnalysisStageItem
    {
        public LeadsKanbanStage Stage { get; set; }
        public int Count { get; set; }
        public double Sum { get; set; }
        public TimeSpan Duration { get; set; }
    }
}

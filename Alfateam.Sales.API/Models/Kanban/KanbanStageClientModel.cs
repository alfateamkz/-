namespace Alfateam.Sales.API.Models.Kanban
{
    public class KanbanStageClientModel<T> where T : class
    {
        public int StageId { get; set; }
        public IEnumerable<T> Items { get; set; } = new List<T>();
    }
}

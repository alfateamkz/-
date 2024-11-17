namespace Alfateam.Sales.API.Models.Kanban
{
    public class KanbanClientModel<T> where T: class
    {
        public List<KanbanStageClientModel<T>> Stages { get; set; } = new List<KanbanStageClientModel<T>>();
    }
}

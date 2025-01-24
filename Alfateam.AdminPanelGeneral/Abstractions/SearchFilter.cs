namespace Alfateam.AdminPanelGeneral.API.Abstractions
{
    public class SearchFilter
    {
        public int Offset { get; set; } = 0;
        public int Count { get; set; } = 20;

        public string Query { get; set; }
    }
}

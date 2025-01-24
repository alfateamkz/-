using Alfateam.Administration.Models.Abstractions;
using Alfateam.Core;


namespace Alfateam.Administration.Models.StaticTextsConstructor
{
    public class StaticTextsModel : AbsModel
    {
        public string ClassName { get; set; }
        public string LangCode { get; set; }
        public string Title { get; set; }

        public TextCategory Category { get; set; }
        public int CategoryId { get; set; }

        public List<AbsField> Fields { get; set; } = new List<AbsField>();
    }
}

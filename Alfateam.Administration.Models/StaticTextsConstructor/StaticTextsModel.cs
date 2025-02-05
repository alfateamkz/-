using Alfateam.Administration.Models.Abstractions;
using Alfateam.Core;


namespace Alfateam.Administration.Models.StaticTextsConstructor
{
    public class StaticTextsModel : AbsModel
    {
        public string ClassName { get; set; }
        public string Title { get; set; }

        public List<AbsField> Fields { get; set; } = new List<AbsField>();




        public List<StaticTextsModel> SubTexts { get; set; } = new List<StaticTextsModel>();


        /// <summary>
        /// Автоматическое поле. Не равно null, если сущность дочерная по отношения к другой сущности StaticTextsModel
        /// </summary>
        public int? StaticTextsModelId { get; set; }

        /// <summary>
        /// Автоматическое поле. Не равно null, если коренной уровень вложенности
        /// </summary>
        public int? TextsSetLanguageZoneId { get; set; }
    }
}

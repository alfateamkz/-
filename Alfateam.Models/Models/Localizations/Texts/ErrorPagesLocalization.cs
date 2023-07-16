using Alfateam.Database.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Triggero.Models.Attributes;

namespace Alfateam.Database.Models.Localizations.Texts
{

    [GeneratorMetadata("Страницы ошибок и пасхал очка=)")]
    public class ErrorPagesLocalization : LocalizationModel
    {
        [GeneratorField("Доступ запрещен :(")]
        public string Text403 { get; set; } = "Доступ запрещен :(";
        [GeneratorField("Страница не найдена")]
        public string Text404 { get; set; } = "Страница не найдена";




        [GeneratorField("ЗДЕСЬ НИХУЯ НЕТ")]
        public string NuhuyaTitle { get; set; } = "ЗДЕСЬ НИХУЯ НЕТ";
        [GeneratorField("Если ты что-то искал, то здесь такого нет :(")]
        public string NuhuyaDescription { get; set; } = "Если ты что-то искал, то здесь такого нет :(";
    }
}

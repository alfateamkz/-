using Alfateam.Database.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Triggero.Models.Attributes;

namespace Alfateam.Database.Models.Localizations.Texts.OtherPages
{
    [GeneratorMetadata("Страница новостей")]
    public class NewsPageLocalization : LocalizationModel
    {
        [GeneratorField("НОВОСТИ")]
        public string Header { get; set; } = "НОВОСТИ";

    }
}

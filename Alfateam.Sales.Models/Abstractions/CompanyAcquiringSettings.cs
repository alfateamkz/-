using Alfateam.Core;
using Alfateam.Sales.Models.General.AcquiringSettings.Countries.Kazakhstan;
using Alfateam.Sales.Models.General.AcquiringSettings.Countries.Mongolia;
using Alfateam.Sales.Models.General.AcquiringSettings.Countries.Russia;
using Alfateam.Sales.Models.General.AcquiringSettings.Crypto;
using Alfateam.Sales.Models.Invoices.PaidInfo;
using JsonKnownTypes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Sales.Models.Abstractions
{

    [JsonConverter(typeof(JsonKnownTypesConverter<CompanyAcquiringSettings>))]
    [JsonDiscriminator(Name = "discriminator")]
    [JsonKnownType(typeof(KaspiAcquiringSettings), "KaspiAcquiringSettings")]
    [JsonKnownType(typeof(Kassa24AcquiringSettings), "Kassa24AcquiringSettings")]

    [JsonKnownType(typeof(KhaanBankAcquiringSettings), "KhaanBankAcquiringSettings")]
    [JsonKnownType(typeof(QPayAcquiringSettings), "QPayAcquiringSettings")]

    [JsonKnownType(typeof(SberbankAcquiringSettings), "SberbankAcquiringSettings")]
    [JsonKnownType(typeof(TBankAcquiringSettings), "TBankAcquiringSettings")]
    [JsonKnownType(typeof(YookassaAcquiringSettings), "YookassaAcquiringSettings")]

    [JsonKnownType(typeof(PassimPayAcquiringSettings), "PassimPayAcquiringSettings")]
    public class CompanyAcquiringSettings : AbsModel
    {
        [JsonProperty("discriminator")]
        public string Discriminator { get; set; }


        public string Title { get; set; }
        public bool IsEnabled { get; set; }


    }
}

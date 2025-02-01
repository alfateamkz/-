using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.EDM.Models.Enums
{
    public enum DocumentTypePurpose
    {
        ForDocumentWithFile = 1,
        ForPriceListDocument = 2,
        ForWithPositionItemsDocument = 3,

        ForDocumentParcel = 999,
    }
}

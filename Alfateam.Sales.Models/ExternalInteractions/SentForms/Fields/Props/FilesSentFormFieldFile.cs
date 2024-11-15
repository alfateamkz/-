using Alfateam.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Sales.Models.ExternalInteractions.SentForms.Fields.Props
{
    public class FilesSentFormFieldFile : AbsModel
    {
        public string Filepath { get; set; }
        public string Filename { get; set; }
        public long BytesSize { get; set; }
    }
}

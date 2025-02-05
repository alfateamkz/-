using Alfateam.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.SharedModels
{
    public class UploadedFile : AbsModelGuid
    {
        public string? Server { get; set; }
        public string RelativePath { get; set; }
        

        public bool IsUsed { get; set; }
    }
}

using Alfateam.Messenger.Lib.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Messenger.Lib.Models.Images
{
    public class Base64ImageFile : AbsImageFile
    {
        public Base64ImageFile(string base64)
        {
            Base64 = base64;
        }
        public string Base64 { get; set; }
    }
}

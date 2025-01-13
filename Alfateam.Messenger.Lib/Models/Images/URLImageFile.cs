using Alfateam.Messenger.Lib.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Messenger.Lib.Models.Images
{
    public class URLImageFile : AbsImageFile
    {
        public URLImageFile(string url)
        {
            URL = url;
        }
        public string URL { get; set; }
    }
}

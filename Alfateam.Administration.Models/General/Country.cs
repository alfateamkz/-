using Alfateam.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Administration.Models.General
{
    public class Country : AbsModel
    {
        public string Title { get; set; }
        public string Code { get; set; }
        public string FlagImgPath { get; set; }
    }
}

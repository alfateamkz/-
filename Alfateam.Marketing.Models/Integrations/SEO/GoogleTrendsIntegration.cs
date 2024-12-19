﻿using Alfateam.Core;
using Alfateam.Marketing.Models.Abstractions.Integrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.Models.Integrations.SEO
{
    public class GoogleTrendsIntegration : WebsiteIntegration
    {
        public override string ToString()
        {
            return "Google Trends";
        }
    }
}

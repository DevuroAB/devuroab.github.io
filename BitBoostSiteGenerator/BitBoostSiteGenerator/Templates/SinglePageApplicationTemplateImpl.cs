using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BitBoostSiteGenerator.Localization;

namespace BitBoostSiteGenerator.Templates
{
    partial class SinglePageApplicationTemplate
    {
        public SinglePageApplicationTemplate(Localizer localizer)
        {
            Localizer = localizer;
        }

        public Localizer Localizer { get; }

        public string CompanyName => "BitBoost AB";
        public string CompanyMail => "hi@bitboost.se";
    }
}

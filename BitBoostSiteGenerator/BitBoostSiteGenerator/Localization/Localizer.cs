using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;

namespace BitBoostSiteGenerator.Localization
{
    public class Localizer
    {
        public interface ITextLocalizer
        {
            string this[int id] { get; }
        }

        private class TextLocalizerImpl : ITextLocalizer
        {
            public string this[int id] => Translations.ResourceManager.GetString($"Text_{id}");
        }

        public Localizer()
        {
            Text = new TextLocalizerImpl();
        }

        public IEnumerable<String> Cultures => new[] { "sv-SE", "en-US" }; //, "de-DE", "es-ES", "fi-FI", "fr-FR", "it-IT", "nb-NO", "nl-NL", "pl-PL", "ru-RU", "zh-CHS" };

        public void SetCulture(string cultureName)
        {
            var targetCulture = CultureInfo.CreateSpecificCulture(cultureName);
            Thread.CurrentThread.CurrentCulture = targetCulture;
            Thread.CurrentThread.CurrentUICulture = targetCulture;
        }

        public ITextLocalizer Text { get; }
    }
}

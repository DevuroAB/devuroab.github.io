using System;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Reflection;
using BitBoostSiteGenerator.Localization;

namespace BitBoostSiteGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            var localizer = new Localizer();

            GenerateSite(x => $"index.html", "en-US", localizer);
            foreach (var currentCultureName in localizer.Cultures)           
            {
                GenerateSite(x => $"index.{x}.html", currentCultureName, localizer);                
            }
        }

        private static void GenerateSite(Func<string, string> filenameFunc, string cultureName, Localizer localizer)
        {
            localizer.SetCulture(cultureName);

            var template = new Templates.SinglePageApplicationTemplate(localizer);
            var result = template.TransformText();
                
            var assemblyFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var targetFolder = Path.Combine(assemblyFolder ?? throw new ArgumentNullException(), "output");
            Directory.CreateDirectory(targetFolder);

            var targetFilename = Path.Combine(targetFolder, filenameFunc(cultureName));

            File.WriteAllText(targetFilename, result);            
        }
    }
}

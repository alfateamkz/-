using Alfateam.CRM2_0.Models.Gamification.General;
using Alfateam.Models;
using Alfateam.SitemapXMLGenerator;
using Alfateam.Website.API.Models.Navigation;
using Alfateam2._0.Models.Localization.Texts.Grouping;
using Microsoft.AspNetCore.Hosting.Server;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace Alfateam.Website.API.Helpers
{
    public static class StaticFilesHelper
    {
        private static string WWWRootPath = "uploads/wwwroot";
        private static string SitemapXMLPath = "uploads/wwwroot/sitemap.xml";
        private static string LocalizationsFolderPath = "uploads/wwwroot/localizations";

        public static void CreateStaticLocalizationsFile(WebsiteLocalizationTexts websiteTexts)
        {
            if (!Directory.Exists(LocalizationsFolderPath))
            {
                Directory.CreateDirectory(LocalizationsFolderPath);
            }

            var filepath = Path.Combine(LocalizationsFolderPath, $"localization_{websiteTexts.LanguageEntity.Code}.json");

            if (File.Exists(filepath))
            {
                File.Delete(filepath);           
            }

            var staticFileModel = new StaticFileModel<WebsiteLocalizationTexts>()
            {
                Value = websiteTexts,
            };
            var jsonStr = JsonConvert.SerializeObject(staticFileModel);
            File.WriteAllText(filepath, jsonStr);
        }

        public static void CreateSitemapXML(Sitemap sitemap)
        {
            if (!Directory.Exists(WWWRootPath))
            {
                Directory.CreateDirectory(WWWRootPath);
            }

            SitemapGenerator generator = new SitemapGenerator();

            foreach (var item in sitemap.Items)
            {
                AddSitemapXMLItemsRecursively(generator, item);
            }

            generator.WriteSitemapToFile(SitemapXMLPath);
        }

        private static void AddSitemapXMLItemsRecursively(SitemapGenerator generator, SitemapItem item)
        {
            generator.Add(new SitemapLocation
            {
                ChangeFrequency = SitemapLocation.eChangeFrequency.hourly,
                Url = "https://alfateam.co/" + item.URL,
                LastModified = item.LastModified,
                Priority = item.Priority
            });

            foreach (var subItem in item.Sublelements)
            {
                AddSitemapXMLItemsRecursively(generator, subItem);
            }
        }
    }
}

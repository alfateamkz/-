﻿using System.Collections;
using System.Xml.Serialization;

namespace Alfateam.SitemapXMLGenerator
{
    [XmlRoot("urlset", Namespace = "http://www.sitemaps.org/schemas/sitemap/0.9")]
    public class SitemapGenerator
    {
        private ArrayList map;

        public SitemapGenerator()
        {
            map = new ArrayList();
        }

        [XmlElement("url")]
        public SitemapLocation[] Locations
        {
            get
            {
                SitemapLocation[] items = new SitemapLocation[map.Count];
                map.CopyTo(items);
                return items;
            }
            set
            {
                if (value == null)
                    return;
                SitemapLocation[] items = (SitemapLocation[])value;
                map.Clear();
                foreach (SitemapLocation item in items)
                    map.Add(item);
            }
        }

        public string GetSitemapXml()
        {
            return string.Empty;
        }

        public int Add(SitemapLocation item)
        {
            return map.Add(item);
        }

        public void AddRange(IEnumerable<SitemapLocation> locs)
        {
            foreach (var i in locs)
            {
                map.Add(i);
            }
        }

        public void WriteSitemapToFile(string path)
        {

            using (FileStream fs = new FileStream(path, FileMode.Create))
            {

                XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
                ns.Add("image", "http://www.google.com/schemas/sitemap-image/1.1");

                XmlSerializer xs = new XmlSerializer(typeof(SitemapGenerator));
                xs.Serialize(fs, this, ns);
            }
        }

        public string WriteSitemapToString()
        {
            using (StringWriter sw = new StringWriter())
            {
                XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
                ns.Add("image", "http://www.google.com/schemas/sitemap-image/1.1");

                XmlSerializer xs = new XmlSerializer(typeof(SitemapGenerator));
                xs.Serialize(sw, this, ns);
                return sw.GetStringBuilder().ToString();
            }
        }
    }
}

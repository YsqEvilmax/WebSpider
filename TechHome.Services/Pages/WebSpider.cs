using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using TechHome.Services.Targets;

namespace TechHome.Services.Pages
{
    public class WebSpider
    {
        public List<Page> Pages { get; private set; }

        public WebSpider()
        {
            Pages = new List<Page>();
        }

        public void FetchData(Link link)
        {
            using (var client = new WebClient())
            {
                client.Credentials = CredentialCache.DefaultCredentials;
                try
                {
                    byte[] pageData = client.DownloadData(link.Uri());
                    var content = ConvertEncoding(pageData);
                    if (link is Page && !string.IsNullOrEmpty(content))
                    {
                        Pages.Add(link as Page);
                    }
                    Analyze(content, link.Elements);
                }
                catch (WebException) { }
            }
        }

        private void Analyze(string content, IList<Element> collection)
        {
            foreach (Element t in collection)
            {
                if(Regex.IsMatch(content, t.Pattern))
                {
                    t.Value = Regex.Match(content, t.Pattern).Value;
                    if (t is Link)
                    {
                        FetchData(t as Link);
                    }
                    else
                    {
                        Pages.Find(x => x.Equals(t.Source))?.Results.Add(t);
                    }
                }
            }
        }

        private string ConvertEncoding(byte[] data)
        {
            var content = Encoding.Default.GetString(data);
            var charset = Regex.Match(content, "(?<=charset=)(\\w|-)+(?=\">)").Value;
            if (!string.IsNullOrEmpty(charset))
            {
                return Encoding.GetEncoding(charset.ToUpper()).GetString(data);
            }
            return content;
        }
    }
}

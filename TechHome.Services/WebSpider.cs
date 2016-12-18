using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using TechHome.Services.Targets;

namespace TechHome.Services
{
    class WebSpider
    {
        public IDictionary<string, Page> Pages { get; private set; }

        public WebSpider()
        {
            Pages = new Dictionary<string, Page>();
        }

        public void FetchData(Link link)
        {
            WebClient client = new WebClient();
            client.Credentials = CredentialCache.DefaultCredentials;
            client.Encoding = System.Text.Encoding.GetEncoding("GB2312");
            try
            {
                Byte[] pageData = client.DownloadData(link.Uri());
                var content = Encoding.GetEncoding("GB2312").GetString(pageData);
                if (link is Page)
                {
                    Pages.Add(new KeyValuePair<string, Page>(link.Uri().ToString(), link as Page));
                }             
                Analyze(content, link.Elements);
            }
            catch (WebException) { }
        }

        private void Analyze(string content, IList<Element> collection)
        {
            foreach (Element t in collection)
            {
                if(Regex.IsMatch(content, t.Pattern))
                {
                    t.Value = Regex.Match(content, t.Pattern).Value;
                    if (t.GetType() == typeof(Link))
                    {
                        FetchData(t as Link);
                    }
                    else
                    {
                        Pages[t.OriginSource].Results.Add(t);
                    }
                }
            }
        }
    }
}

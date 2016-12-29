using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TechHome.Services.Targets;
using TechHome.Services.Pages;
using TechHome.Webs.Areas.WebSpider.Models;
using TechHome.Services.Tasks;
using TechHome.Services.Adapters;

namespace TechHome.Webs.Areas.WebSpider.Controllers
{
    public class WebTasksController : ApiController
    {
        private Services.Pages.WebSpider _spider = new Services.Pages.WebSpider();

        // POST: api/WebTasks
        public IEnumerable<ITask> Fetch([FromBody]IEnumerable<WebTask> value)
        {
            var pages = value.Select(
                x => {
                    var page = Page.GetFromFile(x.Template);
                    page.Value = x.Url;
                    return page;
                }).ToList();
            foreach (var page in pages)
            {
                _spider.FetchData(page);
            }
            return new PageCLTaskAdapter().Adapt(_spider.Pages);
        }
    }
}

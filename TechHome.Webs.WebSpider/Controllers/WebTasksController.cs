using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using TechHome.Services.Tasks;
using TechHome.Services.Adapters;
using System.Web.Http;
using TechHome.Webs.WebSpider.Models;

namespace TechHome.Webs.WebSpider.Controllers
{
    public class WebTasksController : ApiController
    {
        private Services.Pages.WebSpider _spider = new Services.Pages.WebSpider();
        public HttpResponseMessage Options()
        {
            return new HttpResponseMessage { StatusCode = HttpStatusCode.OK };
        }
        // POST: api/WebTasks
        public IEnumerable<ITask> Fetch([FromBody]IEnumerable<WebTask> value)
        {
            var pages = value.Select(
                x => {
                    var page = Services.Targets.Page.GetFromFile(x.Template);
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

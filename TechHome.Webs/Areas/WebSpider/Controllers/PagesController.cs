using System.Collections.Generic;
using System.Web.Http;
using TechHome.Services.Targets;
using TechHome.Services.Pages;

namespace TechHome.Webs.Areas.WebSpider.Controllers
{
    public class PagesController : ApiController
    {
        private static readonly Services.Pages.WebSpider Spider = new Services.Pages.WebSpider();
        // GET: api/Pages
        public IEnumerable<Page> Get()
        {
            return Spider.Pages;
        }

        // GET: api/Pages/5
        public Page Get(int id)
        {
            return Spider.Pages[id];
        }

        // POST: api/Pages
        public void Post([FromBody]Page page)
        {
            if (page?.Uri() != null)
            {
                Spider.FetchData(page);
            }         
        }

        // PUT: api/Pages/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Pages/5
        public void Delete(int id)
        {
            Spider.Pages.RemoveAt(id);
        }

        // DELETE: api/Pages
        public void Clear()
        {
            Spider.Pages.Clear();
        }
    }
}

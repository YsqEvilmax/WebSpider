using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TechHome.Services.Targets;
using TechHome.Services.Tasks;

namespace TechHome.Services.Adapters
{
    public class PageCLTaskAdapter
        : IAdapter<Page, ITask>
    {
        public ITask Adapt(Page page)
        {
            if (page?.Results.Count > 1)
            {
                Element movie = page.Results.First(x => x.Name.Equals("movie"));
                Element title = page.Results.First(x => x.Name.Equals("title"));
                string extension = Regex.Match(movie.Value, @"(?<=http://(\w|\.|\/)+)\.(mp4|avi)").Value;
                return new CLTask() {Uri = movie.Value, FileName = title.Value + extension};
            }
            return null;
        }

        public List<ITask> Adapt(List<Page> pages)
        {
            return pages.Select(x => Adapt(x)).Where(x => x != null).ToList();
        }
    }
}

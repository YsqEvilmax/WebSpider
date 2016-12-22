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
    class CLPageTaskAdapter
        : IAdapter<Page, ITask>
    {
        public ITask Adapt(Page page)
        {
            if (page?.Results.Count > 1)
            {
                Element movie = page.Results.First(x => x.Name.Equals("moive"));
                Element title = page.Results.First(x => x.Name.Equals("title"));
                string extension = Regex.Match(movie.Value, @"(?<=http://(\w|\.|\/)+)\.(mp4|avi)").Value;
                return new CLTask() {Uri = new Uri(movie.Value), FileName = title.Value + extension};
            }
            return null;
        }
    }
}

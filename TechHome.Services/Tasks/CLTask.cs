using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using TechHome.Services.Targets;

namespace TechHome.Services.Tasks
{
    public class CLTask
        : ITask
    {
        public Uri Uri { get; set; }
        public string FileName { get; set; }
        public string FolderPath { get { return Properties.Settings.Default["DownloadsFolder"] as string; } }
        public string Comment { get { return "Aoto - download"; } }
        public State State { get; set; }
    }

    public class CLTaskManager
    {
        public List<ITask> Tasks { get; set; }
        public CLTaskManager()
        {
            Tasks = new List<ITask>();
        }

        public List<ITask> Manipulate(IList<Page> pages)
        {
            foreach(var page in pages.Where(x => x.Results.Count >= 2))
            {
                Element movie = page.Results.First(x => x.Name.Equals("moive"));
                Element title = page.Results.First(x => x.Name.Equals("title"));
                string extension = Regex.Match(movie.Value, @"(?<=http://(\w|\.|\/)+)\.(mp4|avi)").Value;
                Tasks.Add(new CLTask() {
                    Uri = new Uri(movie.Value),
                    FileName = title.Value + extension
                });
            }
            return Tasks;
        }
    }
}

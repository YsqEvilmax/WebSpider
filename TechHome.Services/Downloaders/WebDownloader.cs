using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using TechHome.Services.Tasks;

namespace TechHome.Services.Downloaders
{
    public class WebDownloader
        : IDownloader
    {
        public readonly int MaxRunningTask = 5;
        public List<ITask> TaskList { get; private set; }
        public WebDownloader()
        {
            TaskList = new List<ITask>();
        }
        public void AddTask(ITask task)
        {
            WebClient client = new WebClient();
            client.DownloadProgressChanged += new DownloadProgressChangedEventHandler((sender, e) => {
                task.State = State.Downloading;
                System.Console.WriteLine("{0} is downloading: {1}!", task.FileName, e.ProgressPercentage);
            });
            client.DownloadFileCompleted += new AsyncCompletedEventHandler((sender, e) => {
                System.Console.WriteLine("Download complete: {0}", task.FileName);
                task.State = State.Completed;              
                string completed = Path.Combine(task.FolderPath, "Completed");
                if (!Directory.Exists(completed))
                {
                    Directory.CreateDirectory(completed);
                }
                File.Move(Path.Combine(task.FolderPath, task.FileName),
                    Path.Combine(completed, task.FileName));
                RoundUp();
            });
            client.DownloadFileAsync(new Uri(task.Uri), Path.Combine(task.FolderPath, task.FileName));         
        }

        public void AddTasks(List<ITask> tasks)
        {
            tasks.ForEach(x => x.State = State.Ready);
            TaskList = new List<ITask>(TaskList.Concat(tasks));
            RoundUp();
        }

        private void RoundUp()
        {
            int running = TaskList.Where(x => x.State == State.Downloading).Count();
            for (int i = 0; i < MaxRunningTask - running; i++)
            {
                ITask task = TaskList.FirstOrDefault(x => x.State == State.Ready);
                if (task != null) { AddTask(task); }
            }
        }
    }
}

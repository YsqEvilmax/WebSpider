using System.Collections.Generic;
using ThunderAgentLib;
using TechHome.Services.Tasks;

namespace TechHome.Services.Downloaders
{
    public class TDownloader
        : IDownloader
    {
        public Agent Agent { get; private set; }

        public List<ITask> TaskList { get; private set; }

        public TDownloader()
        {
            Agent = new Agent();
        }

        public void AddTask(ITask task)
        {
            Agent.AddTask(task.Uri.ToString(), task.FileName, task.FolderPath, task.Comment,"",1,0,5);
            TaskList.Add(task);    
        }

        public void AddTasks(List<ITask> tasks)
        {
            foreach(var task in tasks)
            {
                this.AddTask(task);
            }
            Agent.CommitTasks();
        }
    }
}

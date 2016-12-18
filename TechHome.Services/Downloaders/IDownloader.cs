using System.Collections.Generic;
using TechHome.Services.Tasks;

namespace TechHome.Services.Downloaders
{
    public interface IDownloader
    {
        List<ITask> TaskList { get; }
        void AddTask(ITask task);
        void AddTasks(List<ITask> tasks);
    }
}

using System;

namespace TechHome.Services.Tasks
{
    public interface ITask
    {
        Uri Uri { get; set; }
        string FileName { get; set; }
        string FolderPath { get; }
        string Comment { get; }
        State State { get; set; }
    }

    public enum State
    {
        Ready,
        Downloading,
        Completed
    };
}

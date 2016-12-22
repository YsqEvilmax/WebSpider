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
        public State State
        {
            get
            {
                lock (_stateLocker)
                {
                    return _state;
                }
            }
            set
            {
                lock (_stateLocker)
                {
                    _state = value;
                }
            }
        }

        private State _state;
        private readonly object _stateLocker = new object();
    }
}

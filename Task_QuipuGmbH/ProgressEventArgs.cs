using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_QuipuGmbH
{
    public class ProgressEventArgs : EventArgs
    {
        public ProgressEventArgs(int progress)
        {
            Progress = progress;
        }
        public int Progress { get; protected set; }
    }
}

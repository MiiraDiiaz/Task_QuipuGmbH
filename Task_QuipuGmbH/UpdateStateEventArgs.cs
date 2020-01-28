using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_QuipuGmbH
{
    public class UpdateStateEventArgs : EventArgs
    {
        public UpdateStateEventArgs(UpdateState newState, UpdateState oldState)
        {
            NewState = newState;
            OldState = oldState;
        }
        public UpdateState NewState { get; protected set; }
        public UpdateState OldState { get; protected set; }
    }
}

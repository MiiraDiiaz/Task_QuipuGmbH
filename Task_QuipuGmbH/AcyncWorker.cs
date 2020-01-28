using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Task_QuipuGmbH
{
    public class AsyncWorker
    {
        private readonly SynchronizationContext _syncContext;
        private UpdateState _currentState;

        public AsyncWorker()
        {
            _syncContext = SynchronizationContext.Current ?? new SynchronizationContext();
        }

        public void DoWork()
        {
            if (_currentState == UpdateState.Started)
            {
                return;
            }

            Task.Factory.StartNew(() =>
            {
                OnUpdateStateChanged(UpdateState.Started);
                for (int i = 1; i < 101; i++)
                {
                    Thread.Sleep(25);
                    OnUpdateProgressChanged(i);
                }
                OnUpdateStateChanged(UpdateState.Completed);
            });
        }
        public event EventHandler<UpdateStateEventArgs> UpdateStateChanged;

        public event EventHandler<ProgressEventArgs> UpdateProgressChanged;

        protected void OnUpdateStateChanged(UpdateState newState)
        {
            UpdateState oldState = _currentState;
            _currentState = newState;
            var handler = UpdateStateChanged;
            if (handler != null)
            {
                _syncContext.Post((unused) =>
                {
                    handler(this, new UpdateStateEventArgs(newState, oldState));
                }, null);
            }
        }

        protected void OnUpdateProgressChanged(int percentage)
        {
            var handler = UpdateProgressChanged;
            if (handler != null)
            {
                _syncContext.Post((unused) =>
                {
                    handler(this, new ProgressEventArgs(percentage));
                }, null);
            }
        }
    }
}

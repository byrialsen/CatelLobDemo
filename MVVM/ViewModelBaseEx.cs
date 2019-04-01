using Catel.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CatelLobDemo.MVVM
{
    public class ViewModelBaseEx : Catel.MVVM.ViewModelBase
    {
        protected CancellationTokenSource _cts = new CancellationTokenSource();
        public bool IsBusy { get; set; }
        public string BusyText { get; set; }
        private DateTimeOffset? _busyEnteredTimestamp;

        public void EnterBusy(string text = "Loading...")
        {
            IsBusy = true;
            BusyText = text;
            _busyEnteredTimestamp = DateTimeOffset.Now;
        }

        public async Task LeaveBusyAsync(int minimumVisible = 1200)
        {
            if (IsBusy && _busyEnteredTimestamp != null)
            {
                int duration = (int)DateTimeOffset.Now.Subtract(_busyEnteredTimestamp.Value).TotalMilliseconds;
                if (duration < minimumVisible)
                {
                    // ensure that we remain in busy state until minimumVisible time
                    await Task.Delay(minimumVisible - duration);
                }
            }

            // reset is busy
            IsBusy = false;
            BusyText = null;
            _busyEnteredTimestamp = null;
        }

        protected string FormatLogText(string text)
        {
            return $"(ID: {UniqueIdentifier} -> {text}";
        }
    }
}

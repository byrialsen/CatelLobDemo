using Catel.Logging;
using CatelLobDemo.MVVM;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace CatelLobDemo.ViewModels
{
    public class TwoViewModel : ViewModelBaseEx
    {
        protected static readonly ILog log = LogManager.GetCurrentClassLogger();

        public TwoViewModel()
        {
            Title = "Page 2" + UniqueIdentifier;
        }

        protected override async Task InitializeAsync()
        {
            var sw = Stopwatch.StartNew();

            EnterBusy("Simulation long process...");
            try
            {
                log.Debug(FormatLogText("Initialize start"));
                await Task.Delay(10000, _cts.Token);
                log.Debug(FormatLogText("Initialize finished"));
            }
            catch (OperationCanceledException ex)
            {
                log.Debug(FormatLogText("Initialize exception"));
            }
            catch (Exception)
            {
                log.Debug(FormatLogText("Initialize exception"));
            }
            finally
            {
                await LeaveBusyAsync();
                log.Debug(FormatLogText($"Initialize time: {sw.ElapsedMilliseconds}ms"));
            }
        }

        protected override Task CloseAsync()
        {
            log.Debug(FormatLogText($"CloseAsync"));

            _cts.Cancel();

            return base.CloseAsync();
        }

        protected override Task OnClosedAsync(bool? result)
        {
            log.Debug(FormatLogText($"OnClosedAsync"));

            return base.OnClosedAsync(result);
        }
    }
}

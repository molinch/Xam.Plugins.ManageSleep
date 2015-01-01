using System;
using System.Threading.Tasks;

namespace Xam.Plugins.ManageSleep.Common
{
    public abstract class SleepModeBase: ISleepMode
    {
        public abstract void ActivateAutoSleepMode(bool activateAutoSleepMode);

        public void DoWithoutSleep(Action action)
        {
            try
            {
                ActivateAutoSleepMode(false);
                action();
            }
            finally
            {
                ActivateAutoSleepMode(true);
            }
        }

        public async Task DoWithoutSleepAsync(Task task)
        {
            try
            {
                ActivateAutoSleepMode(false);
                await task.ConfigureAwait(false);
            }
            finally
            {
                ActivateAutoSleepMode(true);
            }
        }
    }
}
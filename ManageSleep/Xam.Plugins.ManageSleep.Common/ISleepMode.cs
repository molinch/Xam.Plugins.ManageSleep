using System;
using System.Threading.Tasks;

namespace Xam.Plugins.ManageSleep.Abstractions
{
    public interface ISleepMode
    {
        void ActivateAutoSleepMode(bool activateAutoSleepMode);

        void DoWithoutSleep(Action action);

        Task DoWithoutSleepAsync(Task action);
    }
}
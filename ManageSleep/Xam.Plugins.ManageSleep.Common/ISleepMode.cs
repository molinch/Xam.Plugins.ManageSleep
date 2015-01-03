using System;
using System.Threading.Tasks;

namespace Xam.Plugins.ManageSleep
{
    /// <summary>
    /// Manage auto-sleep / auto-lock. This is useful when dealing with long running processes.
    /// </summary>
    public interface ISleepMode
    {
        /// <summary>
        /// Executes the given action without having the device going to sleep.
        /// </summary>
        /// <param name="action">Action to execute.</param>
        void DoWithoutSleep(Action action);

        /// <summary>
        /// Awaits the given task without having the device going to sleep.
        /// </summary>
        /// <returns>A task to await.</returns>
        /// <param name="action">Task to run.</param>
        Task DoWithoutSleepAsync(Task action);

        /// <summary>
        /// Activates or desactivates the auto sleep mode. True to activate it (default), False to deactivate it.
        /// Use with caution: if you deactivated auto sleep you will need to reactivate it.
        /// DoWithoutSleep and DoWithoutSleepAsync methods are preferred since they automatically resume auto sleep.
        /// </summary>
        /// <param name="activateAutoSleepMode">If set to <c>true</c> activates auto sleep mode.</param>
        void ActivateAutoSleepMode(bool activateAutoSleepMode);
    }
}
using System;
using System.Threading.Tasks;

namespace Xam.Plugins.ManageSleep
{
    /// <summary>
    /// Manage auto-sleep / auto-lock
    /// </summary>
    public interface ISleepMode
    {
        /// <summary>
        /// Activates or desactivates the auto sleep mode. True to activate it (default), False to deactivate it.
        /// </summary>
        /// <param name="activateAutoSleepMode">If set to <c>true</c> activates auto sleep mode.</param>
        void ActivateAutoSleepMode(bool activateAutoSleepMode);

        /// <summary>
        /// Executes the given action without sleep.
        /// </summary>
        /// <param name="action">Action to execute.</param>
        void DoWithoutSleep(Action action);

        /// <summary>
        /// Executes the task asynchronously.
        /// </summary>
        /// <returns>A task to await.</returns>
        /// <param name="action">Task to run.</param>
        Task DoWithoutSleepAsync(Task action);
    }
}
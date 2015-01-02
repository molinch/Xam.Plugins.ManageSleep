using System;
using System.Threading.Tasks;

namespace Xam.Plugins.ManageSleep
{
    /// <summary>
    /// Sleep mode base.
    /// </summary>
    public abstract class SleepModeBase: ISleepMode
    {
        /// <summary>
        /// Activates or desactivates the auto sleep mode. True to activate it (default), False to deactivate it.
        /// </summary>
        /// <param name="activateAutoSleepMode">If set to <c>true</c> activates auto sleep mode.</param>
        public abstract void ActivateAutoSleepMode(bool activateAutoSleepMode);

        /// <summary>
        /// Executes the given action without sleep.
        /// </summary>
        /// <param name="action">Action to execute.</param>
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

        /// <summary>
        /// Executes the task asynchronously.
        /// </summary>
        /// <returns>A task to await.</returns>
        /// <param name="action">Task to run.</param>
        /// <param name="task">Task.</param>
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
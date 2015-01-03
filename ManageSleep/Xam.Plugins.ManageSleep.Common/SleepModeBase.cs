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
        /// Use with caution: if you deactivated auto sleep you will need to reactivate it.
        /// DoWithoutSleep and DoWithoutSleepAsync methods are preferred since they automatically resume auto sleep.
        /// </summary>
        /// <param name="activateAutoSleepMode">If set to <c>true</c> activate auto sleep mode.</param>
        public abstract void ActivateAutoSleepMode(bool activateAutoSleepMode);

        /// <summary>
        /// Executes the given action without having the device going to sleep.
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
        /// Awaits the given task without having the device going to sleep.
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
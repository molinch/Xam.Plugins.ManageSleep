using System;
using Android.Content;
using Xam.Plugins.ManageSleep;

namespace Xam.Plugins.ManageSleep
{
    public class SleepMode: SleepModeBase
    {
        private Android.OS.PowerManager.WakeLock _wakeLock;

        /// <summary>
        /// Activates or desactivates the auto sleep mode. True to activate it (default), False to deactivate it.
        /// Use with caution: if you deactivated auto sleep you will need to reactivate it.
        /// DoWithoutSleep and DoWithoutSleepAsync methods are preferred since they automatically resume auto sleep.
        /// </summary>
        /// <param name="activateAutoSleepMode">If set to <c>true</c> activate auto sleep mode.</param>
        public override void ActivateAutoSleepMode(bool activateAutoSleepMode)
        {
            var powerMgr = (Android.OS.PowerManager) Android.App.Application.Context.GetSystemService(Context.PowerService);

            if (_wakeLock == null)
            {
                _wakeLock = powerMgr.NewWakeLock(Android.OS.WakeLockFlags.Partial, typeof(SleepMode).FullName);
            }

            if (activateAutoSleepMode)
            {
                _wakeLock.Release();
            }
            else
            {
                _wakeLock.Acquire();
            }
        }
    }
}
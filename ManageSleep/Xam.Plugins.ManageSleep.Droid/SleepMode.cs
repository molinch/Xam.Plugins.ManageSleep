using System;
using Android.Content;
using Xam.Plugins.ManageSleep;

namespace Xam.Plugins.ManageSleep
{
    public class SleepMode: SleepModeBase, IDisposable
    {
        private readonly Context _context;
        private Android.OS.PowerManager.WakeLock _wakeLock;

        /// <summary>
        /// Activates or desactivates the auto sleep mode. True to activate it (default), False to deactivate it.
        /// </summary>
        /// <param name="activateAutoSleepMode">If set to <c>true</c> activates auto sleep mode.</param>
        public override void ActivateAutoSleepMode(bool activateAutoSleepMode)
        {
            var powerMgr = (Android.OS.PowerManager) Android.App.Application.Context.GetSystemService(Context.PowerService);

            if (_wakeLock == null)
            {
                _wakeLock = powerMgr.NewWakeLock(Android.OS.WakeLockFlags.Partial, "MobileFrameworkWL");
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

        #region IDisposable implementation

        public void Dispose()
        {
            if (_wakeLock != null)
            {
                _wakeLock.Release();
                _wakeLock = null;
            }
        }

        #endregion
    }
}
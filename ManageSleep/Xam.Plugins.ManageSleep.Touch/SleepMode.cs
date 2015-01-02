using System;
using Xam.Plugins.ManageSleep;

#if __UNIFIED__
using UIKit;
#else
using MonoTouch.UIKit;
#endif

namespace Xam.Plugins.ManageSleep
{
    public class SleepMode: SleepModeBase
    {
        /// <summary>
        /// Activates or desactivates the auto sleep mode. True to activate it (default), False to deactivate it.
        /// </summary>
        /// <param name="activateAutoSleepMode">If set to <c>true</c> activates auto sleep mode.</param>
        public override void ActivateAutoSleepMode(bool activateAutoSleepMode)
        {
            UIApplication.SharedApplication.InvokeOnMainThread(() =>
                {
                    UIApplication.SharedApplication.IdleTimerDisabled = activateAutoSleepMode; // hack to force it see our update...
                    UIApplication.SharedApplication.IdleTimerDisabled = !activateAutoSleepMode;
                });
        }
    }
}


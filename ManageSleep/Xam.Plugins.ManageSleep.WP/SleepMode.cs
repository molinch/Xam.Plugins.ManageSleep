using System;
using Microsoft.Phone.Shell;
using Xam.Plugins.ManageSleep.Common;

namespace Xam.Plugins.ManageSleep.Touch
{
    public class SleepMode: SleepModeBase
    {
        /// <summary>
        /// Activates or desactivates the auto sleep mode. True to activate it (default), False to deactivate it.
        /// </summary>
        /// <param name="activateAutoSleepMode">If set to <c>true</c> activates auto sleep mode.</param>
        public override bool ActivateAutoSleepMode(bool activateAutoSleepMode)
        {
            //FMT: to implement
            //Microsoft.Phone.Shell.PhoneApplicationService.Current.UserIdleDetectionMode = ;
        }
    }
}
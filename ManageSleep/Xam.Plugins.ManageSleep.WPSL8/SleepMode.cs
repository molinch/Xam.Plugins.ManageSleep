using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Phone.Shell;

namespace Xam.Plugins.ManageSleep
{
    public class SleepMode : SleepModeBase
    {
        /// <summary>
        /// Activates or desactivates the auto sleep mode. True to activate it (default), False to deactivate it.
        /// Use with caution: if you deactivated auto sleep you will need to reactivate it.
        /// DoWithoutSleep and DoWithoutSleepAsync methods are preferred since they automatically resume auto sleep.
        /// </summary>
        /// <param name="activateAutoSleepMode">If set to <c>true</c> activates auto sleep mode.</param>
        public override void ActivateAutoSleepMode(bool activateAutoSleepMode)
        {
            Microsoft.Phone.Shell.PhoneApplicationService.Current.ApplicationIdleDetectionMode = activateAutoSleepMode ? IdleDetectionMode.Enabled : IdleDetectionMode.Disabled;
            Microsoft.Phone.Shell.PhoneApplicationService.Current.UserIdleDetectionMode = Microsoft.Phone.Shell.PhoneApplicationService.Current.ApplicationIdleDetectionMode;
        }
    }
}
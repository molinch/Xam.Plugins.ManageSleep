using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Core;
using Windows.System.Display;

namespace Xam.Plugins.ManageSleep
{
    public class SleepMode : SleepModeBase
    {
        private Windows.System.Display.DisplayRequest _displayRequest;

        /// <summary>
        /// Activates or desactivates the auto sleep mode. True to activate it (default), False to deactivate it.
        /// Use with caution: if you deactivated auto sleep you will need to reactivate it.
        /// DoWithoutSleep and DoWithoutSleepAsync methods are preferred since they automatically resume auto sleep.
        /// </summary>
        /// <param name="activateAutoSleepMode">If set to <c>true</c> activates auto sleep mode.</param>
        public override void ActivateAutoSleepMode(bool activateAutoSleepMode)
        {
            if (_displayRequest == null)
            {
                _displayRequest = new Windows.System.Display.DisplayRequest();
            }

            if (activateAutoSleepMode)
            {
                _displayRequest.RequestRelease();
            }
            else
            {
                _displayRequest.RequestActive();
            }
        }
    }
}
using System;

namespace Xam.Plugins.ManageSleep
{
    /// <summary>
    /// Manage auto-sleep / auto-lock. This is useful when dealing with long running processes.
    /// </summary>
    public class SleepMode: SleepModeBase
    {
        /// <summary>
        /// Activates or desactivates the auto sleep mode. True to activate it (default), False to deactivate it.
        /// Use with caution: if you deactivated auto sleep you will need to reactivate it.
        /// DoWithoutSleep and DoWithoutSleepAsync methods are preferred since they automatically resume auto sleep.
        /// </summary>
        /// <param name="activateAutoSleepMode">If set to <c>true</c> activate auto sleep mode.</param>
        public override void ActivateAutoSleepMode(bool activateAutoSleepMode)
        {
            NotImplementedInReferenceAssembly();
        }

        internal static Exception NotImplementedInReferenceAssembly()
        {
            return new NotImplementedException("This functionality is not implemented in the portable version of this assembly.  You should reference the Xam.Plugins.TextToSpeech NuGet package from your main application project in order to reference the platform-specific implementation.");
        }
    }
}


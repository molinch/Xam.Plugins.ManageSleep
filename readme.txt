==========================================
Xam.Plugins.ManageSleep plugin for Xamarin
==========================================

Source is hosted on github at:
https://github.com/molinch/Xam.Plugins.ManageSleep

A more up to date readme or discussions of issues may be available!

NuGet package is available here: https://www.nuget.org/packages/Xam.Plugins.ManageSleep/

-----

Manage auto sleep / auto lock in all platforms. This is useful when dealing with long running processes.

=====
Usage
=====

**Android requires WAKE_LOCK permission, see below.**

This should fit most scenarios. Instanciate SleepMode and use one of its method:

C#:
-----------------------------------------------------------------------

/// <summary>
/// Executes the given action without having the device going to sleep.
/// </summary>
/// <param name="action">Action to execute.</param>
void DoWithoutSleep(Action action);

/// <summary>
/// Awaits the given task without having the device going to sleep.
/// </summary>
/// <returns>A task to await.</returns>
/// <param name="action">Task to run.</param>
Task DoWithoutSleepAsync(Task action);

-----------------------------------------------------------------------

Example:
-----------------------------------------------------------------------

var sleepMode = new SleepMode();
sleepMode.DoWithoutSleep(() => {
  //long running operation...
});

-----------------------------------------------------------------------

===================
Android permissions
===================

Android requires that the app manifest includes the WAKE_LOCK permission.

https://developer.android.com/reference/android/Manifest.permission.html#WAKE_LOCK

Include this permission via your IDE or including this XML:
-----------------------------------------------------------------------

<uses-permission android:name="android.permission.WAKE_LOCK" />

-----------------------------------------------------------------------

==============
Advanced usage
==============

If you need a fine-grained control of the auto sleep. Then you can use the following method:
C#:
-----------------------------------------------------------------------

/// <summary>
/// Activates or desactivates the auto sleep mode. True to activate it (default), False to deactivate it.
/// Use with caution: if you deactivated auto sleep you will need to reactivate it.
/// DoWithoutSleep and DoWithoutSleepAsync methods are preferred since they automatically resume auto sleep.
/// </summary>
/// <param name="activateAutoSleepMode">If set to <c>true</c> activates auto sleep mode.</param>
void ActivateAutoSleepMode(bool activateAutoSleepMode);

-----------------------------------------------------------------------

Therefore be careful when using it: if you deactivated auto sleep then you should reactivate it. Furthermore it has to be done using the same instance of SleepMode.

If you use a framework like MvvmCross then it is easier: you will typically have one instance of SleepMode registered as a singleton for the ISleepMode interface.

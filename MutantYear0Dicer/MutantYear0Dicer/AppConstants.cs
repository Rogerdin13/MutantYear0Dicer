using MutantYear0Dicer.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;

namespace MutantYear0Dicer
{
    public static class AppConstants
    {
        public static int TimerInterval = Preferences.Get(PrefKeys.TimerIntervalValueKey, 13); // in milliseconds
        public static int TimerRuntime = Preferences.Get(PrefKeys.TimerRuntimeValueKey, 500); // in milliseconds
    }
}

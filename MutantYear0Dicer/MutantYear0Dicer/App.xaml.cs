using MutantYear0Dicer.Helpers;
using MutantYear0Dicer.ViewModels;
using MutantYear0Dicer.Views;
using Prism;
using Prism.Ioc;
using Xamarin.Essentials;
using Xamarin.Essentials.Implementation;
using Xamarin.Essentials.Interfaces;
using Xamarin.Forms;

namespace MutantYear0Dicer
{
    public partial class App
    {
        public App(IPlatformInitializer initializer) : base(initializer) {}

        protected override async void OnInitialized()
        {
            if (!Preferences.ContainsKey(PrefKeys.TimerIntervalValueKey))
            {
                Preferences.Set(PrefKeys.TimerIntervalValueKey, 13);
            }

            if (!Preferences.ContainsKey(PrefKeys.TimerRuntimeValueKey))
            {
                Preferences.Set(PrefKeys.TimerRuntimeValueKey, 500);
            }

            InitializeComponent();

            await NavigationService.NavigateAsync("MenuPage/NavigationPage/DicerPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            // services
            containerRegistry.RegisterSingleton<IAppInfo, AppInfoImplementation>();

            // pages
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MenuPage, MenuPageViewModel>();
            containerRegistry.RegisterForNavigation<DicerPage, DicerPageViewModel>();
            containerRegistry.RegisterForNavigation<SettingsPage, SettingsPageViewModel>();
        }
    }
}

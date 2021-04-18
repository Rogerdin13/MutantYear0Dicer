using MutantYear0Dicer.Helpers;
using Prism.Navigation;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace MutantYear0Dicer.ViewModels
{
    public class SettingsPageViewModel : ViewModelBase
    {
        public ICommand SetDefaultValuesCommand => new Command(()=> 
        {
            Preferences.Set(PrefKeys.TimerRuntimeValueKey, 500);
            DurationValue = 500;
            Preferences.Set(PrefKeys.TimerIntervalValueKey, 13);
            FrequenzyValue = 13;
        });

        public SettingsPageViewModel(INavigationService navService) : base (navService) {}

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            DurationValue = Preferences.Get(PrefKeys.TimerRuntimeValueKey, 500);
            FrequenzyValue = Preferences.Get(PrefKeys.TimerIntervalValueKey, 13);
            HeaderLogo = ImageSource.FromResource("MutantYear0Dicer.Assets.Images.mutant_logo.png");

            base.OnNavigatedTo(parameters);
        }

        #region public methods

        public void EntryUnfocused(object sender, FocusEventArgs e)
        {
            var entryObject = (Entry)sender;
            if (int.TryParse(entryObject.Text, out int entryValue) && entryValue > 0)
            {
                switch (entryObject.AutomationId)
                {
                    case "duration":
                        Preferences.Set(PrefKeys.TimerRuntimeValueKey, entryValue);
                        DurationValue = entryValue;
                        break;
                    case "frequenzy":
                        Preferences.Set(PrefKeys.TimerIntervalValueKey, entryValue);
                        FrequenzyValue = entryValue;
                        break;
                }
            }

            entryObject.Text = "";
        }

        #endregion

        #region binding props

        private ImageSource headerLogo;
        public ImageSource HeaderLogo
        {
            get => headerLogo;
            set => SetProperty(ref headerLogo, value);
        }

        private int durationValue;
        public int DurationValue
        {
            get => durationValue;
            set => SetProperty(ref durationValue, value);
        }

        private int frequenzyValue;
        public int FrequenzyValue
        {
            get => frequenzyValue;
            set => SetProperty(ref frequenzyValue, value);
        }

        #endregion
    }
}

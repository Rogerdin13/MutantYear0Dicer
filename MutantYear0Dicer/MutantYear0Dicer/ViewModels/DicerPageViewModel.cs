using Prism.Navigation;
using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace MutantYear0Dicer.ViewModels
{
    public class DicerPageViewModel : ViewModelBase
    {
        private int TimerInterval; // in milliseconds
        private int TimerRuntime; // in milliseconds
        private DateTime TimerStartRadio  = default;
        private DateTime TimerStartBio = default;
        private DateTime TimerStartExpl = default;

        public ICommand RollDiceCommand => new Command<string>((type) => 
        {
            switch (type)
            {
                case "radioactive":
                    // dont start a new timer while old one is running
                    if (TimerStartRadio != default) return;

                    TimerStartRadio = DateTime.Now;

                    // timer for UI (rolling numbers)
                    Device.StartTimer(TimeSpan.FromMilliseconds(TimerInterval), () =>
                    {
                        RadioDiceValue = new Random().Next(1, 7);

                        // stop timer 'hook'
                        if (DateTime.Now - TimerStartRadio > TimeSpan.FromMilliseconds(TimerRuntime))
                        {
                            // reset timer
                            TimerStartRadio = default;
                            // stop device-timer
                            return false;
                        }
                        return true;
                    });
                    break;

                case "biohazard":
                    // dont start a new timer while old one is running
                    if (TimerStartBio != default) return;

                    TimerStartBio = DateTime.Now;

                    // timer for UI (rolling numbers)
                    Device.StartTimer(TimeSpan.FromMilliseconds(TimerInterval), () =>
                    {
                        BioDiceValue = new Random().Next(1, 7);

                        // stop timer 'hook'
                        if (DateTime.Now - TimerStartBio > TimeSpan.FromMilliseconds(TimerRuntime))
                        {
                            // reset timer
                            TimerStartBio = default;
                            // stop device-timer
                            return false;
                        }
                        return true;
                    });
                    break;

                case "explosion":
                    // dont start a new timer while old one is running
                    if (TimerStartExpl != default) return;

                    TimerStartExpl = DateTime.Now;

                    // timer for UI (rolling numbers)
                    Device.StartTimer(TimeSpan.FromMilliseconds(TimerInterval), () =>
                    {
                        ExplosionDiceValue = new Random().Next(1, 7);

                        // stop timer 'hook'
                        if (DateTime.Now - TimerStartExpl > TimeSpan.FromMilliseconds(TimerRuntime))
                        {
                            // reset timer
                            TimerStartExpl = default;
                            // stop device-timer
                            return false;
                        }
                        return true;
                    });
                    break;
            }
        });

        public DicerPageViewModel(INavigationService navService) : base(navService) {}

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            RadioDiceValue = 0;
            BioDiceValue = 0;
            ExplosionDiceValue = 0;

            RadioactiveImageSource = ImageSource.FromResource("MutantYear0Dicer.Assets.Images.radioactive.png");
            BiohazardImageSource = ImageSource.FromResource("MutantYear0Dicer.Assets.Images.biohazard.png");
            ExplosionImageSource = ImageSource.FromResource("MutantYear0Dicer.Assets.Images.explosion.png");
            HeaderLogo = ImageSource.FromResource("MutantYear0Dicer.Assets.Images.mutant_logo.png");

            TimerInterval = AppConstants.TimerInterval;
            TimerRuntime = AppConstants.TimerRuntime;

            base.OnNavigatedTo(parameters);
        }

        #region binding props

        private ImageSource headerLogo;
        public ImageSource HeaderLogo
        {
            get => headerLogo;
            set => SetProperty(ref headerLogo, value);
        }

        private ImageSource radioactiveImageSource;
        public ImageSource RadioactiveImageSource
        {
            get => radioactiveImageSource;
            set => SetProperty(ref radioactiveImageSource, value);
        }

        private ImageSource biohazardImageSource;
        public ImageSource BiohazardImageSource
        {
            get => biohazardImageSource;
            set => SetProperty(ref biohazardImageSource, value);
        }

        private ImageSource explosionImageSource;
        public ImageSource ExplosionImageSource
        {
            get => explosionImageSource;
            set => SetProperty(ref explosionImageSource, value);
        }

        private int radioDiceValue;
        public int RadioDiceValue
        {
            get => radioDiceValue;
            set => SetProperty(ref radioDiceValue, value);
        }

        private int bioDiceValue;
        public int BioDiceValue
        {
            get => bioDiceValue;
            set => SetProperty(ref bioDiceValue, value);
        }

        private int explosionDiceValue;
        public int ExplosionDiceValue
        {
            get => explosionDiceValue;
            set => SetProperty(ref explosionDiceValue, value);
        }

        #endregion
    }
}

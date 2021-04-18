using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System.Windows.Input;
using Xamarin.Forms;

namespace MutantYear0Dicer.ViewModels
{
    public class MenuPageViewModel : ViewModelBase
    {
        public ICommand NavigateCommand => new Command<string>(async (pName) => { await NavigationService.NavigateAsync($"MenuPage/NavigationPage/{pName}"); });

        public MenuPageViewModel(INavigationService navService) : base (navService) 
        {
            mutantLogo = ImageSource.FromResource("MutantYear0Dicer.Assets.Images.mutant_logo.png");
        }

        #region binding props

        private ImageSource mutantLogo;
        public ImageSource MutantLogo
        {
            get => mutantLogo;
            set => SetProperty(ref mutantLogo, value);
        }

        #endregion
    }
}

using MutantYear0Dicer.ViewModels;
using System;
using Xamarin.Forms;

namespace MutantYear0Dicer.Views
{
    public partial class SettingsPage : ContentPage
    {
        public SettingsPage()
        {
            InitializeComponent();
        }

        private void Entry_Unfocused(object sender, FocusEventArgs e)
        {
            var vm = BindingContext as SettingsPageViewModel;
            vm.EntryUnfocused(sender, e);
        }
    }
}

using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System;
using Windows.System;

namespace WinUIPortfolio.Pages
{
    public sealed partial class HomePage : Page
    {
        public HomePage()
        {
            this.InitializeComponent();
        }

        private async void EmailButton_Click(object sender, RoutedEventArgs e)
        {
            var emailUri = new Uri("mailto:saurabh@example.com");
            await Launcher.LaunchUriAsync(emailUri);
        }
    }
}

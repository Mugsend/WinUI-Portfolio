using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using WinUIPortfolio.Pages;
// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.


namespace WinUIPortfolio
{
    public sealed partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();
            
            ContentFrame.Navigate(typeof(HomePage));
        }
        private void NavView_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {
            if (args.SelectedItem is NavigationViewItem selectedItem)
            {
                switch (selectedItem.Tag)
                {
                    case "HomePage":
                        ContentFrame.Navigate(typeof(HomePage));
                        break;
                    case "ProjectsPage":
                        ContentFrame.Navigate(typeof(ProjectsPage));
                        break;
                    case "AboutPage":
                        ContentFrame.Navigate(typeof(AboutPage));
                        break;
                    case "WebPage":
                        ContentFrame.Navigate(typeof(WebPage));
                        break;
                }
            }
        }
    }
    
}


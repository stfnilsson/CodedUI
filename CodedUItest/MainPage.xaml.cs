using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace CodedUItest
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
            DataContext = new MainViewModel();

            
        }

        public MainViewModel ViewModel => DataContext as MainViewModel;

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            await ViewModel.LoadAsync();

            base.OnNavigatedTo(e);
        }


        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button == null)
            {
                return;
            }
            button.Background = new SolidColorBrush(Colors.Chartreuse);
        }
    }
}
using DemoApp.Views;

namespace DemoApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new Dashboard();
        }
    }
}

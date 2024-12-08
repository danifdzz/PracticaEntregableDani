using PracticaEntregable.MVVM.Views;

namespace PracticaEntregable
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new DataView());
        }
    }

}

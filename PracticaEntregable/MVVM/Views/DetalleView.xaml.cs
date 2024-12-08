using PracticaEntregable.MVVM.Models;
using PracticaEntregable.MVVM.ViewModels;

namespace PracticaEntregable.MVVM.Views
{
    public partial class DetalleView : ContentPage
    {
        private DetalleViewModel _viewModel;

        public DetalleView(Tarea tarea, INavigation navigation)
        {
            InitializeComponent();
            _viewModel = new DetalleViewModel(tarea, navigation);
            BindingContext = _viewModel;
        }
    }

}

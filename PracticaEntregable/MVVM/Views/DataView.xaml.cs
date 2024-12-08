using PracticaEntregable.MVVM.Models;
using PracticaEntregable.MVVM.ViewModels;

namespace PracticaEntregable.MVVM.Views;

public partial class DataView : ContentPage
{
    public DataView()
    {
        InitializeComponent();
        BindingContext = new DataViewModel();

    }
    private async System.Threading.Tasks.Task VerDetalleTarea(Tarea tarea)
    {
        var detalleTareaPage = new DetalleView(tarea, Application.Current.MainPage.Navigation);
        await Application.Current.MainPage.Navigation.PushAsync(detalleTareaPage);
    }




}

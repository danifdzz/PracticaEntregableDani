using PracticaEntregable.MVVM.Models;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Microsoft.Maui.Controls;

namespace PracticaEntregable.MVVM.ViewModels
{
    public class DetalleViewModel : INotifyPropertyChanged
    {
        private Tarea _tarea;
        private INavigation _navigation;
        public ICommand CambiarImportanciaCommand { get; }
        public ICommand EliminarTareaCommand { get; }

        public event PropertyChangedEventHandler PropertyChanged;

        public DetalleViewModel(Tarea tarea, INavigation navigation)
        {
            _tarea = tarea;
            _navigation = navigation;
            GuardarCommand = new Command(Guardar);
            CambiarImportanciaCommand = new Command<string>(CambiarImportancia);
            EliminarTareaCommand = new Command(EliminarTarea);
        }



        public Tarea Tarea
        {
            get => _tarea;
            set
            {
                if (_tarea != value)
                {
                    _tarea = value;
                    OnPropertyChanged();
                }
            }
        }

        public ICommand GuardarCommand { get; }

        private async void Guardar()
        {
            await _navigation.PopAsync(); 
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private void CambiarImportancia(string nuevaImportancia)
        {
            Tarea.importancia = nuevaImportancia;
            OnPropertyChanged(nameof(Tarea));
            MessagingCenter.Send(this, "ActualizarTarea", Tarea);
        }
        private async void EliminarTarea()
        {
            bool confirm = await Application.Current.MainPage.DisplayAlert(
                "Confirmación",
                "¿Estás seguro de que deseas eliminar esta tarea?",
                "Sí",
                "No");

            if (confirm)
            {
                MessagingCenter.Send(this, "EliminarTarea", Tarea);
                await _navigation.PopAsync();
            }
        }
    }
}
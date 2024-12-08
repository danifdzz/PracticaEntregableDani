using System;
using System.Windows.Input;
using Microsoft.Maui.Controls;
using PracticaEntregable.MVVM.Models;

namespace PracticaEntregable.MVVM.ViewModels
{
    public class AgregarTareaViewModel : BindableObject
    {
        private string _titulo;
        private string _importancia;
        private DateTime _fechaLimite;

        public string Titulo
        {
            get => _titulo;
            set
            {
                if (_titulo != value)
                {
                    _titulo = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Importancia
        {
            get => _importancia;
            set
            {
                if (_importancia != value)
                {
                    _importancia = value;
                    OnPropertyChanged();
                }
            }
        }

        public DateTime FechaLimite
        {
            get => _fechaLimite;
            set
            {
                if (_fechaLimite != value)
                {
                    _fechaLimite = value;
                    OnPropertyChanged();
                }
            }
        }

        public ICommand GuardarCommand { get; }

        private Action<Tarea> _guardarTareaCallback;

        public AgregarTareaViewModel(Action<Tarea> guardarTareaCallback)
        {
            _guardarTareaCallback = guardarTareaCallback;
            GuardarCommand = new Command(Guardar);
        }

        private async void Guardar()
        {
            var tarea = new Tarea
            {
                titulo = Titulo,
                importancia = Importancia,
                fechaLimite = FechaLimite,
            };
            _guardarTareaCallback(tarea);
            await Application.Current.MainPage.Navigation.PopAsync();
        }
    }
}

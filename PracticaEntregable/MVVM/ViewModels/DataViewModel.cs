using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Microsoft.Maui.Controls;
using PracticaEntregable.MVVM.Models;
using PracticaEntregable.MVVM.Views;

namespace PracticaEntregable.MVVM.ViewModels
{
    public class DataViewModel : BindableObject
    {
        public ObservableCollection<Tarea> Tareas { get; set; }
        public ICommand AgregarTareaCommand { get; }
        public ICommand DetailCommand { get; }

        public event Action<Tarea> TareaEliminada; 
        public event Action<Tarea> TareaActualizada;

        public DataViewModel()
        {
            Tareas = new ObservableCollection<Tarea>
            {
                new Tarea {titulo = "Tarea 1", importancia = "baja",  fechaLimite = new DateTime(2025, 1, 12), hecha=false},
                new Tarea {titulo = "Tarea 2", importancia = "media",  fechaLimite = new DateTime(2025, 3, 3), hecha=true},
                new Tarea {titulo = "Tarea 3", importancia = "alta",  fechaLimite = new DateTime(2025, 4, 1), hecha=false}
            };

            AgregarTareaCommand = new Command(async () => await AgregarTarea());
            DetailCommand = new Command<Tarea>(async tarea => await VerDetalleTarea(tarea));
            MessagingCenter.Subscribe<DetalleViewModel, Tarea>(this, "ActualizarTarea", (sender, tareaActualizada) =>
            {
                ActualizarTarea(tareaActualizada);
            });
            MessagingCenter.Subscribe<DetalleViewModel, Tarea>(this, "EliminarTarea", (sender, tarea) =>
            {
                Tareas.Remove(tarea);
            });
        }

        private async System.Threading.Tasks.Task VerDetalleTarea(Tarea tarea)
        {
            if (tarea == null) return;

            var detalleTareaPage = new DetalleView(tarea, Application.Current.MainPage.Navigation);
            await Application.Current.MainPage.Navigation.PushAsync(detalleTareaPage);
        }


        private async System.Threading.Tasks.Task AgregarTarea()
        {
            var agregarTareaViewModel = new AgregarTareaViewModel(AgregarTareaAColeccion);

            var agregarTareaPage = new AgregarTareaView
            {
                BindingContext = agregarTareaViewModel
            };

            await Application.Current.MainPage.Navigation.PushAsync(agregarTareaPage);
        }

        private void AgregarTareaAColeccion(Tarea tarea)
        {
            Tareas.Add(tarea);
        }
        private void ActualizarTarea(Tarea tarea)
        {
            if (Tareas.Contains(tarea))
            {
                var index = Tareas.IndexOf(tarea);
                Tareas.RemoveAt(index);
                Tareas.Insert(index, tarea);
            }

        }
      
    }
}

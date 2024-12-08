
using System.ComponentModel;

namespace PracticaEntregable.MVVM.Models
{
    public class Tarea : INotifyPropertyChanged
    {
        private string _titulo;
        private string _importancia;
        private DateTime _fechaLimite;
        private bool _hecha;

        public event PropertyChangedEventHandler PropertyChanged;

        public string titulo
        {
            get => _titulo;
            set
            {
                if (_titulo != value)
                {
                    _titulo = value;
                    OnPropertyChanged(nameof(titulo));  
                }
            }
        }



        public string importancia
        {
            get => _importancia;
            set
            {
                if (_importancia != value)
                {
                    _importancia = value;
                    OnPropertyChanged(nameof(importancia));  
                }
            }
        }

        public DateTime fechaLimite
        {
            get => _fechaLimite;
            set
            {
                if (_fechaLimite != value)
                {
                    _fechaLimite = value;
                    OnPropertyChanged(nameof(fechaLimite));  
                }
            }
        }
        public bool hecha
        {
            get => _hecha;
            set
            {
                if (_hecha != value)
                {
                    _hecha = value;
                    OnPropertyChanged(nameof(_hecha));
                }
            }
        }
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

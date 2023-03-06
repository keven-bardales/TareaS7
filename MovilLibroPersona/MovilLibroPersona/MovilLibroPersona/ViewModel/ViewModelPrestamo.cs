using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using MovilLibroPersona.Models;
using Xamarin.Forms;

namespace MovilLibroPersona.ViewModel
{
    public class ViewModelPrestamo : INotifyPropertyChanged
    {

        private Persona personaSeleccionada;
        private ObservableCollection<Libro> librosSeleccionados = new ObservableCollection<Libro>();

        private DateTime fechaPrestamo { get; set; }
        private DateTime fechaDevolucion { get; set; }

        string mensajePrestamo { set; get; }

        public ObservableCollection<Persona> ListaPersonas { get; set; } = new ObservableCollection<Persona>();
        public ObservableCollection<Libro> ListaLibros { get; set; } = new ObservableCollection<Libro>();

        private ICommand crearPrestamoCommand;

        public ICommand CrearPrestamoCommand => crearPrestamoCommand ?? (crearPrestamoCommand = new Command(crearPrestamo));

        public ViewModelPrestamo()
        {
            try
            {
                ListaLibros = App.Current.Properties["ListaLibros"] as ObservableCollection<Libro>;
                ListaPersonas = App.Current.Properties["ListaPersonas"] as ObservableCollection<Persona>;
            }
            catch (Exception ex) { }
            
        }

        public Persona PersonaSeleccionada
        {
            get => personaSeleccionada;
            set
            {
                if (personaSeleccionada != value)
                {
                    personaSeleccionada = value;
                    OnPropertyChanged(nameof(PersonaSeleccionada));
                }
            }
        }

        public ObservableCollection<Libro> LibrosSeleccionados
        {
            get => librosSeleccionados;
            set
            {
                if (librosSeleccionados != value)
                {
                    librosSeleccionados = value;
                    OnPropertyChanged(nameof(LibrosSeleccionados));
                }
            }
        }

        public DateTime FechaPrestamo
        {
            get => fechaPrestamo;
            set
            {
                fechaDevolucion= value;
                if(fechaPrestamo!= value)
                {
                    fechaPrestamo = value;
                    OnPropertyChanged(nameof(FechaPrestamo));
                }
            }
        }

        public DateTime FechaDevolucion
        {
            get => fechaDevolucion;
            set
            {
                fechaDevolucion = value;
                if(fechaDevolucion != value)
                {
                    fechaDevolucion = value;
                    OnPropertyChanged(nameof(FechaDevolucion));
                }
            }
        }

        public string MensajePrestamo
        {
            get => mensajePrestamo;

            set
            {
                mensajePrestamo = value;
                if(mensajePrestamo != value)
                {
                    mensajePrestamo = value;
                    OnPropertyChanged(nameof(MensajePrestamo));
                }
            }

        }


        private void crearPrestamo()
        {
         Prestamo prestamo = new Prestamo()
         {
             personaLibro = this.personaSeleccionada,
             listaLibros = this.librosSeleccionados,
             fechaPrestamo = this.fechaPrestamo,
             fechaDevolucion = this.fechaDevolucion


         };
            mensajePrestamo = prestamo.ToString();

        }


        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

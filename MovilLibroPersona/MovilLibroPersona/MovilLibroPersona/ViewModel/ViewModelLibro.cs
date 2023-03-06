using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Windows.Input;
using MovilLibroPersona.Models;
using Xamarin.Forms;

namespace MovilLibroPersona.ViewModel
{
    public class ViewModelLibro : INotifyPropertyChanged
    {
        private string nombreLibro { get; set; }

        private string autor { get; set; }
        private DateTime fechaImpresion { get; set; }

        private  string labelMensaje { get; set; }


        private ICommand crearLibroCommand;

        public ICommand CrearLibroCommand => crearLibroCommand ?? (crearLibroCommand = new Command(crearLibro));

        private ObservableCollection<Libro> listaLibros = new ObservableCollection<Libro>();

        public ViewModelLibro()
        {
            AbrirListaLibros();
        }

        public ObservableCollection<Libro> ListaLibros
        {
            get { return listaLibros; }
            set
            {
                listaLibros = value;
                OnPropertyChanged(nameof(ListaLibros));
            }
        }



        private void crearLibro()
        {
            Libro libro = new Libro()
            {
                nombre = this.nombreLibro,
                autor = this.autor,
                fechaImpresion = this.fechaImpresion
            };

            LabelMensaje = libro.ToString();

            ListaLibros.Add(libro);

            App.Current.Properties["ListaLibros"] = ListaLibros;

            nombreLibro = string.Empty;
            autor= string.Empty;

            BinaryFormatter formatter = new BinaryFormatter();
            string ruta = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "libros.aut");

            Stream archivo = new FileStream(ruta, FileMode.Create, FileAccess.Write, FileShare.None);
            formatter.Serialize(archivo, ListaLibros);
            archivo.Close();

            /*Fin de Rutina de Serializacion*/

           

        }



        private void AbrirListaLibros()
        {
            try
            {

                /*Proceso de Deserializacion (Ingeniera Inversa de Serializar, leer archivos) */
                BinaryFormatter formatter = new BinaryFormatter();
                string ruta = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "libros.aut");
                Stream archivo = new FileStream(ruta, FileMode.Open, FileAccess.Read, FileShare.None);

                ListaLibros = (ObservableCollection<Libro>)formatter.Deserialize(archivo);

                archivo.Close();

                App.Current.Properties["ListaLibros"] = ListaLibros;

            }
            catch (Exception ex)
            {
                ListaLibros = new ObservableCollection<Libro>();
            }

        }



        public string LabelMensaje
        {
            get => labelMensaje;
            set
            {
                if(labelMensaje != value)
                {
                    labelMensaje = value;   
                    OnPropertyChanged(nameof(LabelMensaje));
                }
            }
        }
        public string NombreLibro
        {
            get => nombreLibro;
            set
            {
                if (nombreLibro != value)
                {

                    nombreLibro = value;
                    OnPropertyChanged(nameof(NombreLibro));
                }
            }
        }

        public string Autor
        {
            get => autor;
            set
            {
                if (autor != value)
                {

                    autor = value;
                    OnPropertyChanged(nameof(Autor));
                }
            }

        }

        public DateTime FechaImpresion
        {
            get => fechaImpresion;
            set
            {
                if (fechaImpresion != value)
                {
                    fechaImpresion = value;
                    OnPropertyChanged(nameof(FechaImpresion));
                }
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}

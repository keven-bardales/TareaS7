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
    public class ViewModelPersona : INotifyPropertyChanged
    {

        private string nombrePersona { get; set; }
        private int numCuenta { get; set; }
        private string mensaje { get; set; }
        public ObservableCollection<Persona> ListaPersonas { get; set; } = new ObservableCollection<Persona>();


        private ICommand crearPersonaCommand;
        public ICommand CrearPersonaCommand => crearPersonaCommand ?? (crearPersonaCommand = new Command(crearPersona));



        public ViewModelPersona()
        {
            AbrirListaPersonas();
        }


        public string NombrePersona
        {
            get => nombrePersona;
            set
            {
                if (nombrePersona != value)
                {

                    nombrePersona = value;
                    OnPropertyChanged(nameof(NombrePersona));
                }
            }
        }

        public string Mensaje
        {
            get { return mensaje; }
            set
            {
                if (mensaje != value)
                {
                    mensaje = value;
                    OnPropertyChanged(nameof(Mensaje));
                }
            }
        }



        public int NumCuenta
        {
            get => numCuenta;
            set
            {
                if (numCuenta != value)
                {

                    numCuenta = value;
                    OnPropertyChanged(nameof(NumCuenta));
                }
            }
        }

        private void crearPersona()
        {
            Persona persona = new Persona()
            {

                nombre = this.nombrePersona,
                numCuenta = numCuenta
            };



            Mensaje = persona.ToString();

            ListaPersonas.Add(persona);

            App.Current.Properties["ListaPersonas"] = ListaPersonas;

            NombrePersona = string.Empty;
            NumCuenta = 0;

            BinaryFormatter formatter = new BinaryFormatter();
            string ruta = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "personas.aut");

            Stream archivo = new FileStream(ruta, FileMode.Create, FileAccess.Write, FileShare.None);
            formatter.Serialize(archivo, ListaPersonas);
            archivo.Close();

            /*Fin de Rutina de Serializacion*/

          


        }


        private void AbrirListaPersonas()
        {
            try
            {

                /*Proceso de Deserializacion (Ingeniera Inversa de Serializar, leer archivos) */
                BinaryFormatter formatter = new BinaryFormatter();
                string ruta = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "personas.aut");
                Stream archivo = new FileStream(ruta, FileMode.Open, FileAccess.Read, FileShare.None);

                ListaPersonas = (ObservableCollection<Persona>)formatter.Deserialize(archivo);

                archivo.Close();

                App.Current.Properties["ListaPersonas"] = ListaPersonas;

            }
            catch (Exception ex)
            {
                ListaPersonas = new ObservableCollection<Persona>();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}

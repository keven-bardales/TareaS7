using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace MovilLibroPersona.Models
{
    [Serializable]
    public class Prestamo
    {

        public Persona personaLibro { get; set; }

        public ObservableCollection<Libro> listaLibros { get; set; }

        public DateTime fechaPrestamo { get; set; }
        public DateTime fechaDevolucion { get; set; }

        public override string ToString()
        {
            return $"Persona asignada al prestamo: {personaLibro.nombre} Fecha del Prestamo: {fechaPrestamo.ToString("dd/MM/yy")} Fecha de Devolucion: " +
                $"{fechaDevolucion.ToString("dd/MM/yy")} Dueño del prestamo: {personaLibro.nombre}";
        }

    }
}

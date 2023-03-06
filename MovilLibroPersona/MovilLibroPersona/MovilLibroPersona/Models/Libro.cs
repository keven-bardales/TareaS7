using System;
using System.Collections.Generic;
using System.Text;

namespace MovilLibroPersona.Models
{
    [Serializable]
    public class Libro
    {

        public string nombre { get; set; }

        public string autor { get; set; }

        public DateTime fechaImpresion { get; set; }


        public string fechaImpresionString
        {
            get
            {
                return fechaImpresion.ToString("dd/MM/yy");
            }




        }


        public override string ToString()
        {
            return $"Nombre libro: {nombre} Autor Libro: {autor} Fecha de impresion: {fechaImpresion.ToString("dd/MM/yy")}";
        }

    }
}

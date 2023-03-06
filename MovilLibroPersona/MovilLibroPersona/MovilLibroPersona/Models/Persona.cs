using System;
using System.Collections.Generic;
using System.Text;

namespace MovilLibroPersona.Models
{
    [Serializable]
    public class Persona
    {

        public string nombre { get; set; }
        public int numCuenta { get; set; }

        public override string ToString()
        {
            return $"Mi nombre es: {nombre} y mi numero de cuenta es: {numCuenta}";
        }

    }
}

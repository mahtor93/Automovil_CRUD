using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auto_Movil
{
    public class Auto
    {
        public string Patente { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Tipo { get; set; }
        public int Precio { get; set; }
        public int Year { get; set; }

        public static string[] Tipo_Auto = { "Auto", "Camioneta", "SUV", "Furgón" };

        public bool Validar()
        {
            string strError = "";
            if (Patente == "") strError = "\n>El campo para Patente no puede quedar vacío";
            if (Patente.Length > 6) strError += "\n >La patente no debe contener más de 6 caracteres";
            if (Marca == "") strError += "\n> El campo para Marca no puede quedar vacío";
            if (Modelo == "") strError += "\n> El campo para Modelo no puede quedar vacío";
            if (Precio < 0) strError += "\n> El precio debe ser mayor que cero";
            if (Precio.ToString().Length == 0) strError += "\n> El campo de precio no puede quedar vacío";
            if (Year < 1900) strError += "\n> El año del automovil no puede ser anterior a 1900";
            if (Year > 2023) strError += "\n>El año del automovil no puede ser posterior al 2023, el viaje en el tiempo no existe, aún";

            if (strError != "")
            {
                throw new Exception(strError);
            }
            else
            {
                return true;
            }
        }


    }
}

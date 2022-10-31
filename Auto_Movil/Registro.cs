using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auto_Movil
{
    public class Registro
    {
        private static List<Auto> autoRegistro = new List<Auto>();

        public static bool Create(Auto auto)
        {
            if (Read(auto.Patente) == null)
            {
                autoRegistro.Add(auto);
                return true;
            }
            else
            {
                return false;
            }
        }

        public static Auto Read(string searchPatente)
        {
            for (int i = 0; i < autoRegistro.Count; i++)
            {
                if (autoRegistro[i].Patente == searchPatente)
                {
                    return autoRegistro[i];
                }
            }
            return null;
        }

        public static bool Delete(string patente)
        {
            if (Read(patente) != null)
            {
                autoRegistro.Remove(Read(patente));
                return true;
            }
            else
            { 
                return false; 
            }
        }

        public static List<Auto> ReadAll()
        {
            List<Auto> lista = new List<Auto>();
            for(int i = 0; i < autoRegistro.Count; i++)
            {
                lista.Add(autoRegistro[i]);
            }
            return autoRegistro;
        }

    }
}

using Data;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class BUbicacion
    {
        public List<Ubicacion> GetUbicaciones()
        {
            List<Ubicacion> ubicaciones = new List<Ubicacion>();
            ubicaciones = DUbicacion.Get();
            return ubicaciones;
        }
    }
}

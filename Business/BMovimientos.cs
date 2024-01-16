using Data;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class BMovimientos
    {
        public List<Movimiento> GetMovimientos()
        {
            List<Movimiento> movimientos = new List<Movimiento>();
            movimientos = DMovimiento.Get();
            return movimientos;
        }
    }
}

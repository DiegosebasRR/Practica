using Business;
using Entity;
using Microsoft.AspNetCore.Mvc;
using Practica.Models;

namespace Practica.Controllers
{
    public class MovimientoController : Controller
    {
        public ActionResult Index(string tipoMovimiento,string numeroDocumento, string fechainicio, string fechafin)
        {
            ViewBag.tipoMovimiento = tipoMovimiento;


            BMovimientos bMovimientos = new BMovimientos();

            List<Movimiento> movimientos = bMovimientos.GetMovimientos();

            if (!string.IsNullOrEmpty(tipoMovimiento))
            {
                movimientos = movimientos.Where(x => x.TIPO_MOVIMIENTO.Contains(tipoMovimiento)).ToList();
            }
            if (!string.IsNullOrEmpty(numeroDocumento))
            {
                movimientos = movimientos.Where(x => x.NRO_DOCUMENTO.Contains(numeroDocumento)).ToList();
            }

            if (DateTime.TryParse(fechainicio, out DateTime fechaInicio) && DateTime.TryParse(fechafin, out DateTime fechaFin))
            {
                movimientos = movimientos.Where(x => x.FECHA_TRANSACCION >= fechaInicio && x.FECHA_TRANSACCION <= fechaFin).ToList();
            }
            List<MovimientoModel> models  = movimientos.Select(x=> new MovimientoModel
            {
                ALMACEN_VENTA = x.ALMACEN_VENTA,
                COD_CIA = x.COD_CIA,
                COD_ITEM_2 = x.COD_ITEM_2,
                COMPANIA_VENTA_3 = x.COMPANIA_VENTA_3,
                NRO_DOCUMENTO = x.NRO_DOCUMENTO,
                TIPO_DOCUMENTO = x.TIPO_DOCUMENTO,
                TIPO_MOVIMIENTO = x.TIPO_MOVIMIENTO,
                UM_ITEM_3 = x.UM_ITEM_3,
                FECHA_TRANSACCION = x.FECHA_TRANSACCION,
                

            }).ToList();

            BUbicacion bUbicacions = new BUbicacion();

            List<Ubicacion> ubicaciones = bUbicacions.GetUbicaciones();

            if (!string.IsNullOrEmpty(tipoMovimiento))
            {
                ubicaciones = ubicaciones.Where(x => x.TIPO_MOVIMIENTO.Contains(tipoMovimiento)).ToList();
            }
            if (!string.IsNullOrEmpty(numeroDocumento))
            {
                ubicaciones = ubicaciones.Where(x => x.NRO_DOCUMENTO.Contains(numeroDocumento)).ToList();
            }

            List<UbicacionModel> models2 = ubicaciones.Select(x => new UbicacionModel
            {
                ALMACEN_VENTA = x.ALMACEN_VENTA,
                COD_CIA = x.COD_CIA,
                COD_ITEM_2 = x.COD_ITEM_2,
                COMPANIA_VENTA_3 = x.COMPANIA_VENTA_3,
                NRO_DOCUMENTO = x.NRO_DOCUMENTO,
                TIPO_DOCUMENTO = x.TIPO_DOCUMENTO,
                TIPO_MOVIMIENTO = x.TIPO_MOVIMIENTO,
                //CANTIDAD = x.CANTIDAD,
                CASILLERO = x.CASILLERO,
                COD_ESTADO = x.COD_ESTADO,
                //COD_LOTE = x.COD_LOTE,
                NIVEL = x.NIVEL,
                RACK = x.RACK,
                UM_MOV = x.UM_MOV,
                ZONA = x.ZONA,

            }).ToList();


            IndexViewModel viewModel = new IndexViewModel
            {
                Movimientos = models,
                Ubicaciones = models2
            };

            return View(viewModel);
        }
    }
}

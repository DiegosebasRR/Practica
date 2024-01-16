using Entity;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class DMovimiento
    {
        public static string connectionstring = "Data source=DESKTOP-0OKTP7C\\MSSQLSERVERRR;Initial Catalog =prueba; User ID = diego; Password=diego;TrustServerCertificate=true";

        public static List<Movimiento> Get()
        {
            List<Movimiento> movimientos = new List<Movimiento>();

            using(SqlConnection connection = new SqlConnection(connectionstring))
            {
                connection.Open();
                string query = "select * from MOV_INVENTARIOS";

                using(SqlCommand command = new SqlCommand("obtenerInventario", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                movimientos.Add(new Movimiento()
                                {
                                    COD_CIA = reader["COD_CIA"].ToString(),
                                    COMPANIA_VENTA_3 = reader["COMPANIA_VENTA_3"].ToString(),
                                    ALMACEN_VENTA = reader["ALMACEN_VENTA"].ToString(),
                                    TIPO_DOCUMENTO = reader["TIPO_DOCUMENTO"].ToString(),
                                    TIPO_MOVIMIENTO = reader["TIPO_MOVIMIENTO"].ToString(),
                                    FECHA_TRANSACCION = (DateTime)reader["FECHA_TRANSACCION"],
                                    NRO_DOCUMENTO = reader["NRO_DOCUMENTO"].ToString(),
                                    COD_ITEM_2 = reader["COD_ITEM_2"].ToString(),
                                    UM_ITEM_3 = reader["UM_ITEM_3"].ToString(),
                                    //CANTIDAD = (decimal)reader["UM_ITEM_3"],
                                });
                            }
                        }
                    }
                }
                connection.Close();
            }

            return movimientos;
        }
    }
}

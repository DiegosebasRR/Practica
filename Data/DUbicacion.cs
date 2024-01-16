using Entity;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class DUbicacion
    {
        public static string connectionstring = "Data source=DESKTOP-0OKTP7C\\MSSQLSERVERRR;Initial Catalog =prueba; User ID = diego; Password=diego;TrustServerCertificate=true";

        public static List<Ubicacion> Get()
        {
            List<Ubicacion> ubicaciones = new List<Ubicacion>();

            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                connection.Open();
                string query = "select * from MOV_INVENTARIOS_UBICACION";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                ubicaciones.Add(new Ubicacion()
                                {
                                    COD_CIA = reader["COD_CIA"].ToString(),
                                    COMPANIA_VENTA_3 = reader["COMPANIA_VENTA_3"].ToString(),
                                    ALMACEN_VENTA = reader["ALMACEN_VENTA"].ToString(),
                                    TIPO_DOCUMENTO = reader["TIPO_DOCUMENTO"].ToString(),
                                    TIPO_MOVIMIENTO = reader["TIPO_MOVIMIENTO"].ToString(),
                                    NRO_DOCUMENTO = reader["NRO_DOCUMENTO"].ToString(),
                                    COD_ITEM_2 = reader["COD_ITEM_2"].ToString(),
                                    ZONA = reader["COD_ITEM_2"].ToString(),
                                    RACK = reader["COD_ITEM_2"].ToString(),
                                    NIVEL = reader["COD_ITEM_2"].ToString(),
                                    CASILLERO = reader["COD_ITEM_2"].ToString(),
                                    COD_ESTADO = reader["COD_ITEM_2"].ToString(),
                                    UM_MOV = reader["COD_ITEM_2"].ToString(),
                                });
                            }
                        }
                    }
                }
                connection.Close();
            }

            return ubicaciones;
        }
    }
}


using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaModelo
{
    public class Sentencias
    {
        Conexion cn = new Conexion();
        OdbcCommand Comm;
        private DataTable tabla;

        public OdbcDataReader funcConsulta(string Consulta)
        {
            try
            {
                Comm = new OdbcCommand(Consulta, cn.conexion());
                OdbcDataReader reader = Comm.ExecuteReader();
                return reader;
            }
            catch (Exception Error)
            {
                Console.WriteLine("Error en modelo " + Error);
                return null;
            }

        }

        public DataTable funcObtenerCamposCombobox(string Comando)
        {
            try
            {
                OdbcDataAdapter datos = new OdbcDataAdapter(Comando, cn.conexion());
                tabla = new DataTable();
                datos.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public OdbcDataReader funcInsertar(String Consulta)
        {
            try
            {
                Comm = new OdbcCommand(Consulta, cn.conexion());
                OdbcDataReader mostrar = Comm.ExecuteReader();
                return mostrar;
            }
            catch (Exception err)
            {
                Console.WriteLine("Ocurrio un error al registrar modelo" + err);
                return null;
            }
        }

        public OdbcDataReader funcModificar(string Consulta)
        {
            try
            {
                Comm = new OdbcCommand(Consulta, cn.conexion());
                OdbcDataReader mostrar = Comm.ExecuteReader();
                return mostrar;
            }
            catch (Exception Error)

            {
                Console.WriteLine("Error en modelo-modificar ", Error);
                return null;
            }
        }

        public OdbcDataAdapter llenarTblProveedores(string tabla)
        {
            string sql = "call consultaProveedores();";
            OdbcDataAdapter dataTable = new OdbcDataAdapter(sql, cn.conexion());
            return dataTable;
        }

        public OdbcDataAdapter llenarTblCompras(string tabla)
        {
            string sql = "call consultaCompras();";
            OdbcDataAdapter dataTable = new OdbcDataAdapter(sql, cn.conexion());
            return dataTable;
        }

        public bool ingresoProveedores(string codigo_proveedor, string nombre_proveedor, string direccion_proveedor, string telefono_proveedor, string nit_proveedor, string estatus_proveedor)
        {
            int i = 0;
            try
            {
                string cadena = "call ingresoProveedores('" + codigo_proveedor + "','" + nombre_proveedor + "','" + direccion_proveedor + "','" + telefono_proveedor + "','" + nit_proveedor + "','" + estatus_proveedor + "'); ";
                OdbcCommand ingreso = new OdbcCommand(cadena, cn.conexion());
                ingreso.ExecuteNonQuery();
                i = 1;
            }
            catch (OdbcException Error)
            {
                Console.WriteLine("Error al ingresar " + Error);

            }
            if (i == 1)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool ingresoCompras(string documento_compraenca, string codigo_proveedor, string fecha_compraenca, string total_compraenca)
            {
                int i = 0;
                try
                {
                    string cadena = "call ingresoCompras('" + documento_compraenca + "','" + codigo_proveedor + "','" + fecha_compraenca + "','" + total_compraenca + "'); ";
                    OdbcCommand ingreso = new OdbcCommand(cadena, cn.conexion());
                    ingreso.ExecuteNonQuery();
                    i = 1;
                }
                catch (OdbcException Error)
                {
                    Console.WriteLine("Error al ingresar " + Error);

                }
                if (i == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
        }
  
  }

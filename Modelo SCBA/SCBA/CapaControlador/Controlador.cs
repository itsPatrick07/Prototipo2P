using CapaModelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaControlador
{
    public class Controlador
    {
        Sentencias Modelo = new Sentencias();
        public DataTable funcObtenerCamposCombobox(string Campo1, string Campo2, string Tabla, string Estado)
        {
            string Comando = string.Format("SELECT " + Campo1 + " ," + Campo2 + " FROM " + Tabla + " WHERE " + Estado + "= 1;");
            return Modelo.funcObtenerCamposCombobox(Comando);
        }
        public OdbcDataReader funcConsultaCombo(string Campo1, string Campo2, string Tabla, string Estado, string Codigo)
        {
            string Comando = string.Format("SELECT " + Campo1 + " FROM " + Tabla + " WHERE " + Estado + "= 1 AND " + Campo2 + " = " + Codigo + ";");
            return Modelo.funcConsulta(Comando);

        }
        public OdbcDataReader funcEliminar_perfil(string Codigo)
        {
            string Consulta = "UPDATE  control_producto SET resultado_control_producto = 'Finalizado', estado_control_producto = 0 where pk_id_control_producto = " + Codigo + ";";
            return Modelo.funcModificar(Consulta);
        }
        public OdbcDataReader funcConsultaDetallesCUI(string Tabla, string CodPedido)
        {
            string Consulta = "SELECT * FROM " + Tabla + " Where pk_id_usuario_pasaporte = " + CodPedido + ";";
            return Modelo.funcConsulta(Consulta);
        }

        public OdbcDataReader funcConsultaBanco(string Tabla, string CodPedido)
        {
            string Consulta = "SELECT estado_boleta FROM " + Tabla + " Where pk_numero_boleta = " + CodPedido + ";";
            return Modelo.funcConsulta(Consulta);
        }

        public DataTable llenarTblProveedores(string tabla)        {            OdbcDataAdapter dt = Modelo.llenarTblProveedores(tabla);            DataTable table = new DataTable();            dt.Fill(table);            return table;        }

        public DataTable llenarTblCompras(string tabla)        {            OdbcDataAdapter dt = Modelo.llenarTblCompras(tabla);            DataTable table = new DataTable();            dt.Fill(table);            return table;        }

        public bool ingresoProveedores(string codigo_proveedor, string nombre_proveedor, string direccion_proveedor, string telefono_proveedor, string nit_proveedor, string estatus_proveedor)
        {
            return Modelo.ingresoProveedores(codigo_proveedor, nombre_proveedor, direccion_proveedor, telefono_proveedor, nit_proveedor, estatus_proveedor);
        }

        public bool ingresoCompras(string documento_compraenca, string codigo_proveedor, string fecha_compraenca, string total_compraenca)
        {
            return Modelo.ingresoCompras(documento_compraenca, codigo_proveedor, fecha_compraenca, total_compraenca);
        }

    }
}

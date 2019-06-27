using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace Marcos_Ponce.App_Code
{
  
    public class MCC_Consulta
    {
        MCC_Conexion cn = new MCC_Conexion();
        public DataTable extraedatos(string nombre_sp, int valor_a_consultar, string nombre_param)
        {
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter(); DataTable dt = new DataTable(); cmd.Connection = cn.sqlcad;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = nombre_sp;
            cmd.Parameters.Add(nombre_param, SqlDbType.Int).Value = valor_a_consultar;
            cmd.Connection.Open(); da.SelectCommand = cmd; cmd.Connection.Close(); da.Fill(dt);
            return dt;
        }

        public DataTable extraedatos(string nomsp, string nomparam, string valorparam)
        {
            SqlCommand sql = new SqlCommand();
            DataTable data = new DataTable();
            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            sql.Connection = cn.sqlcad;
            sql.CommandType = CommandType.StoredProcedure;
            sql.CommandText = nomsp;
            sql.Parameters.Add(nomparam, SqlDbType.VarChar).Value = valorparam;
            cn.conectar();
            dataAdapter.SelectCommand = sql;
            dataAdapter.Fill(data);
            cn.desconectar();
            return data;
        }
        public DataTable extraedatos(string nomsp, string nomparam, int valorparam)
        {
            SqlCommand sql = new SqlCommand();
            DataTable data = new DataTable();
            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            sql.Connection = cn.sqlcad;
            sql.CommandType = CommandType.StoredProcedure;
            sql.CommandText = nomsp;
            sql.Parameters.Add(nomparam, SqlDbType.Int).Value = valorparam;
            /**Activamos la conexion de la base de datos**/
            cn.conectar();
            dataAdapter.SelectCommand = sql;
            dataAdapter.Fill(data);
            cn.desconectar();
            return data;

        }
        public DataTable extraedatos(string nomsp)
        {
            SqlCommand sql = new SqlCommand();
            DataTable data = new DataTable();
            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            sql.Connection = cn.sqlcad;
            sql.CommandType = CommandType.StoredProcedure;
            sql.CommandText = nomsp;
            cn.conectar();
            dataAdapter.SelectCommand = sql;
            dataAdapter.Fill(data);
            cn.desconectar();
            return data;

        }

        public void rellenacombo(DropDownList cmb, String campover, string campovalor, string nombresp)
        {
            cmb.DataSource = extraedatos(nombresp);
            cmb.DataValueField = campovalor;
            cmb.DataTextField = campover;
            cmb.DataBind();
        }


        public string getValor(string nomsp, string nomparam, string valorparam)
        {
            DataTable data = new DataTable();
            data = extraedatos(nomsp, nomparam, valorparam);
            int nrows = data.Rows.Count;
            string respuesta = "?";
            if (nrows >= 1)
            {
                respuesta = data.Rows[0][0].ToString();
            }
            return respuesta;
        }

        public void insertar(string nomsp, string nomparam, string valorparam)
        {
            SqlCommand cmd = new SqlCommand();
            DataTable data = new DataTable();
            cmd.Connection = cn.sqlcad;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = nomsp;
            cmd.Parameters.Add(nomparam, SqlDbType.VarChar).Value = valorparam;
            cn.conectar();
            cmd.ExecuteNonQuery();
            cn.desconectar();
        }
        public void insertar(string nomsp, string nomparam1, string nomparam2, string valorparam1, string valorparam2)
        {
            SqlCommand cmd = new SqlCommand();
            DataTable data = new DataTable();
            cmd.Connection = cn.sqlcad;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = nomsp;
            cmd.Parameters.Add(nomparam1, SqlDbType.VarChar).Value = valorparam1;
            cmd.Parameters.Add(nomparam2, SqlDbType.VarChar).Value = valorparam2;
            cn.conectar();
            cmd.ExecuteNonQuery();//para que no sea ejecutado como una consulta
            cn.desconectar();
        }
        public void insertar_Productos(string nomsp, string nombreProd, int idProveedor, int idCategoria,
            string cantPorUnidad, double precioUnidad, int unidadExistencia, int unidadPedido, int nivelPedido,
            string imagen)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn.sqlcad;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "insproducto";
            cmd.Parameters.Add("@NombreProducto", SqlDbType.VarChar).Value = nombreProd;
            cmd.Parameters.Add("@idProveedor", SqlDbType.Int).Value = idProveedor;
            cmd.Parameters.Add("@idCategoria", SqlDbType.Int).Value = idCategoria;
            cmd.Parameters.Add("@CantidadPorUnidad", SqlDbType.VarChar).Value = cantPorUnidad;
            cmd.Parameters.Add("@PrecioUnidad", SqlDbType.Decimal).Value = precioUnidad;
            cmd.Parameters.Add("@UnidadesEnExistencia", SqlDbType.SmallInt).Value = unidadExistencia;
            cmd.Parameters.Add("@UnidadesEnPedido", SqlDbType.SmallInt).Value = unidadPedido;
            cmd.Parameters.Add("@NivelNuevoPedido", SqlDbType.SmallInt).Value = nivelPedido;
            cmd.Parameters.Add("@Suspendido", SqlDbType.Bit).Value = "false";
            cmd.Parameters.Add("@imagen", SqlDbType.VarChar).Value = imagen;
            cn.conectar();
            cmd.ExecuteNonQuery();
            cn.desconectar();
        }
    }
}
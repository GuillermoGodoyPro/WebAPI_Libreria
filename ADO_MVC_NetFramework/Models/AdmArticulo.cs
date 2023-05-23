using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ADO_MVC_NetFramework.Models
{
    public class AdmArticulo
    {
        private SqlConnection conexion;

        private void Conectar()
        {
            string stringConexion = ConfigurationManager.ConnectionStrings["Conexion"].ToString();

            conexion = new SqlConnection(stringConexion);
            
        }

        public int Alta(Articulo pArticulo)
        {
            Conectar();
            SqlCommand sentencia = new SqlCommand("insert into Articulos (codigo, descripcion, precio) values (@codigo, @descripcion, @precio)", conexion);

            sentencia.Parameters.Add("@codigo", System.Data.SqlDbType.Int);
            sentencia.Parameters.Add("@descripcion", System.Data.SqlDbType.VarChar);
            sentencia.Parameters.Add("@precio", System.Data.SqlDbType.Float);

            sentencia.Parameters["@codigo"].Value = pArticulo.Codigo;
            sentencia.Parameters["@descripcion"].Value = pArticulo.Descripcion;
            sentencia.Parameters["@precio"].Value = pArticulo.Precio;

            conexion.Open();

            int i = sentencia.ExecuteNonQuery();

            conexion.Close();

            return i;
        }

        public List<Articulo> TraerTodos()
        {
            Conectar();
            SqlCommand sentencia = new SqlCommand("select codigo, descripcion, precio from articulos", conexion);

            List<Articulo> articulos = new List<Articulo>();

            conexion.Open();

            //Si el resultado de lo que voy a devolver, va a tener filas y columnas
            SqlDataReader registros = sentencia.ExecuteReader();

            //READ() lee los items hasta que no haya mas, ahi da falso y sale del bucle
            while (registros.Read() )
            {
                Articulo articulo = new Articulo
                {
                    Codigo = int.Parse(registros["codigo"].ToString()),
                    Descripcion = registros["descripcion"].ToString(),
                    Precio = float.Parse(registros["precio"].ToString())
                };
                articulos.Add(articulo);
            }

            conexion.Close();

            return articulos;
        }

        public Articulo TraerArticulo(int pCodigo)
        {
            Conectar();
            SqlCommand sentencia = new SqlCommand("select codigo, descripcion, precio from articulos where codigo = @codigo", conexion);

            sentencia.Parameters.Add("@Codigo", SqlDbType.Int);
            sentencia.Parameters["@codigo"].Value = pCodigo;

            List<Articulo> articulos = new List<Articulo>();

            conexion.Open();

            Articulo a = new Articulo();

            //Si el resultado de lo que voy a devolver, va a tener filas y columnas
            SqlDataReader registros = sentencia.ExecuteReader();

            if (registros.Read())
            {
                a.Codigo = int.Parse(registros["codigo"].ToString());
                a.Descripcion = registros["descripcion"].ToString();
                a.Precio = float.Parse(registros["precio"].ToString());
            }          

            conexion.Close();

            return a;
        }

        public int ModificarArticulo(Articulo pArticulo)
        {
            Conectar();
            SqlCommand sentencia = new SqlCommand("update articulos set descripcion = @descripcion, precio = @precio where codigo = @codigo", conexion);

            sentencia.Parameters.Add("@Codigo", SqlDbType.Int);
            sentencia.Parameters["@codigo"].Value = pArticulo.Codigo;
            sentencia.Parameters.Add("@descripcion", SqlDbType.VarChar);
            sentencia.Parameters["@descripcion"].Value = pArticulo.Descripcion;
            sentencia.Parameters.Add("@precio", SqlDbType.Float);
            sentencia.Parameters["@precio"].Value = pArticulo.Precio;


            List<Articulo> articulos = new List<Articulo>();

            conexion.Open();

            int i = sentencia.ExecuteNonQuery();
                        
            conexion.Close();

            return i;
        }

        public int Borrar(int pCodigo)
        {
            Conectar();
            SqlCommand sentencia = new SqlCommand("delete from articulos where codigo = @codigo", conexion);

            sentencia.Parameters.Add("@Codigo", SqlDbType.Int);
            sentencia.Parameters["@codigo"].Value = pCodigo;

            List<Articulo> articulos = new List<Articulo>();

            conexion.Open();

            int i = sentencia.ExecuteNonQuery();

            conexion.Close();

            return i;
        }



    }
}
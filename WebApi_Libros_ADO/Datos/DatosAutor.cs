using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using WebApi_Libros_ADO.Entidades;

namespace WebApi_Libros_ADO.Datos
{
    public static class DatosAutor
    {
        //Cadenas de conexion, metodos de acceso a datos

        public static string StringConexion = "Data Source=.;Initial Catalog=LibreriaDB;Trusted_Connection=True";

        public static SqlConnection Conexion = null;
       /* public static List<Autor> Get
        {
            List<Autor> listaAutores = new List<Autor>();
            return listaAutores;
        }*/


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace classLibrary_CRUD_Logic
{
    //Nombre: Carlos Eduardo Báez Méndez
    //Matricula: 202010160
    public class CapaDatos
    {
        private SqlConnection conexion = new SqlConnection("Server=DESKTOP-AQN8L58\\SQLEXPRESS; database=Mi_Primera_Vez; integrated security= true");

        SqlDataReader leer;
        DataTable tabla = new DataTable();
        SqlCommand comando = new SqlCommand();

        //Procedimiento para abrir la conexion
        public SqlConnection OpenDB()
        {
            if (conexion.State == ConnectionState.Closed)
            {
                conexion.Open();
                Console.WriteLine("Se ha conectado");
            }
            return conexion;
        }

        //Procedimiento para cerrar la conexion
        public SqlConnection CloseDB()
        {
            if (conexion.State == ConnectionState.Open)
            {
                conexion.Close();
                Console.WriteLine("Se ha desconectado");
            }
            return conexion;
        }

        //Procediiemiento para leer la tabla de la base de datos
        public DataTable Show()
        {
            comando.Connection = OpenDB();
            comando.CommandText = "select * from Mercancias";
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            CloseDB();
            return tabla;
        }

        //Procedimiento para insertar datos
        public void Insert(string descr, double exist, string comentario, string estado, byte noEliminable)
        {
            comando.Connection = OpenDB();
            comando.CommandText = "insert into Mercancias values('" + descr + "','" + exist + "','" + comentario + "','" + estado + "','" + noEliminable + "')";
            comando.ExecuteNonQuery();
            CloseDB();
        }

        //Procedimiento para modificar datos
        public void Update(string descr, double exist, string comentario, string estado, byte noEliminable, int id)
        {
            comando.Connection = OpenDB();
            comando.CommandText = "update Mercancias set descripcion = '" + descr + "', existencia = '" + exist + "', comentario = '" + comentario + "', estado = '" + estado + "', noEliminable = '" + noEliminable + "' where id = '" + id + "'";
            comando.ExecuteNonQuery();
            CloseDB();
        }

        //Procedimiento para eliminar datos
        public void Delete(int id)
        {
            comando.Connection = OpenDB();
            comando.CommandText = "delete from Mercancias where id = '" + id + "'";
            comando.ExecuteNonQuery();
            CloseDB();
        }

        //Procedimiento para buscar un registro
        public DataTable Search(int id)
        {
            comando.Connection = OpenDB();
            comando.CommandText = "select * from Mercancias where id = '" + id + "'";
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            CloseDB();
            return tabla;
        }
    }
}


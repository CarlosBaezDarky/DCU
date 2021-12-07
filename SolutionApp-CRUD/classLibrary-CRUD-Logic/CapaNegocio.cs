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
    public class CapaNegocio
    {
        CapaDatos objetoCD = new CapaDatos();
        private static bool inserccionExitosa = false;
        public static bool getInserccionExitosa() {
            return inserccionExitosa;
        }

        //Procediento para mostrar la tabla
        public DataTable ShowTable() {
            DataTable tabla = new DataTable();
            tabla = objetoCD.Show();
            return tabla;
        }

        //Procedimiento para insertar en la tabla
        public void InsertMerca(string descr, string exist, string comentario, string estado, string noEliminable) {
            if (Convert.ToByte(noEliminable) == 1 || Convert.ToByte(noEliminable) == 0)
            {
                objetoCD.Insert(descr, Convert.ToDouble(exist), comentario, estado, Convert.ToByte(noEliminable));
                inserccionExitosa = true;
            }
            else { inserccionExitosa = false; }
        }

        //Procedimiento para modificar los datos de la tabla
        public void UpdateMerca(string descr, string exist, string comentario, string estado, string noEliminable, string id) {
            if (Convert.ToByte(noEliminable) == 1 || Convert.ToByte(noEliminable) == 0)
            {
                objetoCD.Update(descr, Convert.ToDouble(exist), comentario, estado, Convert.ToByte(noEliminable), Convert.ToInt32(id));
                inserccionExitosa = true;
            }
            else { inserccionExitosa = false; }
        }

        //Procedimiento para elminar una fila de la tabla
        public void DeleteMerca(string id) {
            objetoCD.Delete(Convert.ToInt32(id));
        }

        //Procedimiento para buscar un registro 
        public DataTable SearchRegister(string id)
        {
            DataTable tabla = new DataTable();
            tabla = objetoCD.Search(Convert.ToInt32(id));
            return tabla;
        }
    }
}

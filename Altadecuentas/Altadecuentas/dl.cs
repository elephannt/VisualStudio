using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Librerias;

namespace Altadecuentas
{
    public static class dl
    {
        private static string Conexiones = "Data Source=SRVRERPLOG\\SQLSERVERERP;Initial Catalog=ReplicacionSmartlist;Persist Security Info=True;";
        public static DataTable GetInfoProveedoresByEstatus(int Estatus)
        {
            DataTable dt;
            string Query = "dbo.ECO_GetInfoProveedoresByEstatus";
            SqlParameter[] Par = new SqlParameter[1];
            Par[0] = new SqlParameter("@Estatus", SqlDbType.Int);
            Par[0].Value = Estatus;      
            dt = SqlHelper.ExecuteDataset(Conexiones, CommandType.StoredProcedure, Query, Par).Tables[0];
            return dt;

        }

        public static void UpdateEstatusProveedores(int Estatus, int NewEstatus, string VendorId)
        {
           
            string Query = "dbo.ECO_UpdateEstatusProveedores";
            SqlParameter[] Par = new SqlParameter[3];
            Par[0] = new SqlParameter("@Estatus", SqlDbType.Int);
            Par[0].Value = Estatus;
            Par[1] = new SqlParameter("@NewEstatus", SqlDbType.Int);
            Par[1].Value = NewEstatus;
            Par[2] = new SqlParameter("@VendorId", SqlDbType.Char);
            Par[2].Value = VendorId;
            SqlHelper.ExecuteNonQuery(Conexiones, CommandType.StoredProcedure, Query, Par);
        }


        public static DataTable GetModificacionesAlProveedor()
        {
            DataTable dt;
            string Query = "dbo.ECO_GetModificacionesAlProveedor";         
            dt = SqlHelper.ExecuteDataset(Conexiones, CommandType.StoredProcedure, Query).Tables[0];
            return dt;

        }

    }
}

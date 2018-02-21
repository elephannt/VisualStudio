using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data;
using Altadecuentas;
using Altadecuentas.Clases;

namespace ConsoleApp1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            DataTable dt = new DataTable();
            dt = dl.GetInfoProveedoresByEstatus(1);
            DataTable dt1 = new DataTable();
            dt1 = dl.GetInfoProveedoresByEstatus(2);

            AltaProveedores AP = new AltaProveedores();
            Console.WriteLine(AP.FechaUpdate);
            for (int i = 0; i < dt.Rows.Count;  i++)
            {
                AP = new AltaProveedores();
                //se mapean los datos de cuenta.
                AP.vendorid = dt.Rows[i]["VENDORID"].ToString();
                AP.vendname = dt.Rows[i]["VENDNAME"].ToString();
                AP.vendcntct = dt.Rows[i]["VNDCNTCT"].ToString();
                AP.phnumber1 = dt.Rows[i]["PHNUMBR1"].ToString();
                AP.phnumber2 = dt.Rows[i]["PHNUMBR2"].ToString();
                AP.phnumber3 = dt.Rows[i]["PHONE3"].ToString();
                AP.upszone = dt.Rows[i]["UPSZONE"].ToString();
                AP.acnmvndr = dt.Rows[i]["ACNMVNDR"].ToString();
                AP.curncyid = dt.Rows[i]["CURNCYID"].ToString();
                AP.txrgnnum = dt.Rows[i]["TXRGNNUM"].ToString();
                AP.estatus = dt.Rows[i]["Estatus"].ToString();
                AP.email = dt.Rows[i]["Email"].ToString();
                AP.FechaUpdate = dt.Rows[i]["FechaUpdate"].ToString();
                //se mapean los datos de ALTA.
                AP.ALTAvendorid = dt.Rows[i]["VENDORID"].ToString();
                AP.ALTAvendname = dt.Rows[i]["VENDNAME"].ToString();
                AP.ALTAvendcntct = dt.Rows[i]["VNDCNTCT"].ToString();
                AP.ALTAphnumber1 = dt.Rows[i]["PHNUMBR1"].ToString();
                AP.ALTAphnumber2 = dt.Rows[i]["PHNUMBR2"].ToString();
                AP.ALTAphnumber3 = dt.Rows[i]["PHONE3"].ToString();
                AP.ALTAupszone = dt.Rows[i]["UPSZONE"].ToString();
                AP.ALTAacnmvndr = dt.Rows[i]["ACNMVNDR"].ToString();
                AP.ALTAcurncyid = dt.Rows[i]["CURNCYID"].ToString();
                AP.ALTAtxrgnnum = dt.Rows[i]["TXRGNNUM"].ToString();
                AP.ALTAestatus = dt.Rows[i]["Estatus"].ToString();
                AP.ALTAemail = dt.Rows[i]["Email"].ToString();
                App_Code apz = new App_Code();
                apz.CreaArchivo(AP);
            }
            if (DateTime.Now.Hour == 10)
            {
                for (int i = 0; i < dt1.Rows.Count; i++)
                {
                    AP = new AltaProveedores();
                    AP.vendorid = dt1.Rows[i]["VENDORID"].ToString();
                    AP.vendname = dt1.Rows[i]["VENDNAME"].ToString();
                    AP.vendcntct = dt1.Rows[i]["VNDCNTCT"].ToString();
                    AP.phnumber1 = dt1.Rows[i]["PHNUMBR1"].ToString();
                    AP.phnumber2 = dt1.Rows[i]["PHNUMBR2"].ToString();
                    AP.phnumber3 = dt1.Rows[i]["PHONE3"].ToString();
                    AP.upszone = dt1.Rows[i]["UPSZONE"].ToString();
                    AP.acnmvndr = dt1.Rows[i]["ACNMVNDR"].ToString();
                    AP.curncyid = dt1.Rows[i]["CURNCYID"].ToString();
                    AP.txrgnnum = dt1.Rows[i]["TXRGNNUM"].ToString();
                    AP.estatus = dt1.Rows[i]["Estatus"].ToString();
                    AP.email = dt1.Rows[i]["Email"].ToString();
                    AP.FechaUpdate = dt1.Rows[i]["FechaUpdate"].ToString();

                    App_Code apz = new App_Code();
                    apz.CreaArchivo(AP); 
                }
            } else
            {
                Console.WriteLine("Fuera de tiempo");
            }
        }
    } 
}

using Altadecuentas.Clases;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altadecuentas
{
    public class App_Code
    {
        public void CreaArchivo(AltaProveedores AP)
        {
            Directory.CreateDirectory(AP.pathString2);
            Directory.CreateDirectory(AP.pathString3);
            string temporal = null;
            string fileName = "";
            string fileNameALTA = "";
            switch (AP.estatus)
            {
                case "1":
                        fileName = "RP342051CUENTA" + AP.FechaUpdate + ".txt";
                        fileNameALTA = "RP342051ALTA" + AP.FechaUpdate + ".txt";
                        AP.pathString2 = Path.Combine(AP.pathString2, fileName);
                        AP.pathString3 = Path.Combine(AP.pathString3,fileNameALTA);
                        //Se escribe en el documento la informacion de las tablas (UNICODE es para evitar caracteres no UTF8.)
                        //CUANDO es operacion = AR
                          File.WriteAllText(AP.pathString3,
                          LimitLength(AP.ALTAvendorid,12)
                        + LimitLength(AP.ALTAoperacion,2)
                        + LimitLength(AP.ALTAvendname,60)
                        + LimitLength(AP.ALTAtxrgnnum,13)
                        + LimitLength(AP.ALTAphnumber1, 15)
                        + LimitLength(AP.ALTAvendcntct, 20)
                        + LimitLength(AP.ALTAemail, 39)
                        + LimitLength(AP.ALTAtipodecuentaar, 3)
                        + LimitLength(AP.ALTAtipomonedaar, 7)
                        + LimitLength(AP.ALTAbancoar, 4)
                        + LimitLength(AP.ALTAentidadar,2)
                        + LimitLength(AP.ALTAplazaar,3)
                        + LimitLength(AP.ALTAcuentaar,20)
                        + LimitLength(AP.ALTAabonoaterceros,1)
                        + LimitLength(AP.ALTAabonoSPEIS,1)
                        + LimitLength(AP.ALTAabonoTEFs,1)
                        + LimitLength(AP.ALTAotroservicio1,1)
                        + LimitLength(AP.ALTAotroservicio2,1)
                        + LimitLength(AP.ALTAotroservicio3,1)
                        + LimitLength(AP.ALTAotroservicio4,1)
                        + LimitLength(AP.ALTAotroservicio5,1)
                        + LimitLength(AP.ALTAotroservicio6,1)
                        + Environment.NewLine, Encoding.Unicode);
                    Console.WriteLine("Estatus uno alta de proveedor: "+ AP.ALTAvendorid + "\n");
                    Console.ReadKey();
                    if (AP.upszone == "072")
                    {
                        //tipo de cuenta
                        temporal = "001";
                        //Se escribe en el documento la informacion de las tablas (UNICODE es para evitar caracteres no UTF8.)
                        //CUANDO es operacion = AC
                          File.WriteAllText(AP.pathString2,
                          LimitLength(AP.vendorid, 12)
                        + LimitLength(AP.operacion, 2)
                        + LimitLength(AP.vendname, 60)
                        + LimitLength(AP.txrgnnum, 13)
                        + LimitLength(AP.phnumber1, 15)
                        + LimitLength(AP.vendcntct, 20)
                        + LimitLength(AP.email, 39)
                        + LimitLength(temporal, 3)
                        + LimitLength(AP.curncyid, 7)
                        + AP.upszone.PadLeft(4, '0')
                        + LimitLength(AP.entidad, 2)
                        + LimitLength(AP.plaza, 3)
                        + AP.acnmvndr.PadLeft(20, '0')
                        + LimitLength(AP.abonoaterceros, 1)
                        + LimitLength(AP.abonoSPEIS, 1)
                        + LimitLength(AP.abonoTEFs, 1)
                        + LimitLength(AP.otroservicio1, 1)
                        + LimitLength(AP.otroservicio2, 1)
                        + LimitLength(AP.otroservicio3, 1)
                        + LimitLength(AP.otroservicio4, 1)
                        + LimitLength(AP.otroservicio5, 1)
                        + LimitLength(AP.otroservicio6, 1)
                        + Environment.NewLine, Encoding.Unicode);
                          dl.UpdateEstatusProveedores(1, 2, AP.vendorid);
                        Console.WriteLine("Estatus uno alta de cuenta con:" + AP.upszone + "\n");
                        Console.ReadKey();
                    }
                    else if (AP.upszone != "072")
                    {
                        //tipo de cuenta
                         temporal = "040";
                         File.WriteAllText(AP.pathString2,
                         LimitLength(AP.vendorid, 12)
                       + LimitLength(AP.operacion, 2)
                       + LimitLength(AP.vendname, 60)
                       + LimitLength(AP.txrgnnum, 13)
                       + LimitLength(AP.phnumber1, 15)
                       + LimitLength(AP.vendcntct, 20)
                       + LimitLength(AP.email, 39)
                       + LimitLength(temporal, 3)
                       + LimitLength(AP.curncyid, 7)
                       + AP.upszone.PadLeft(4, '0')
                       + LimitLength(AP.entidad, 2)
                       + LimitLength(AP.plaza, 3)
                       + AP.acnmvndr.PadLeft(20, '0')
                       + LimitLength(AP.abonoaterceros, 1)
                       + LimitLength(AP.abonoSPEIS, 1)
                       + LimitLength(AP.abonoTEFs, 1)
                       + LimitLength(AP.otroservicio1, 1)
                       + LimitLength(AP.otroservicio2, 1)
                       + LimitLength(AP.otroservicio3, 1)
                       + LimitLength(AP.otroservicio4, 1)
                       + LimitLength(AP.otroservicio5, 1)
                       + LimitLength(AP.otroservicio6, 1)
                       + Environment.NewLine, Encoding.Unicode);
                         dl.UpdateEstatusProveedores(1, 2, AP.vendorid);
                         Console.WriteLine("Estatus uno alta de cuenta con: " + AP.upszone + "\n");
                         Console.ReadKey();
                    }
                    break;
                case "2":            
                    fileName = "RP342051MOD" + AP.FechaUpdate + ".txt";
                    //Abrimos SP que ejecuta un select de la tabla con las modificaciones
                    DataTable dt = new DataTable();
                    dt = dl.GetModificacionesAlProveedor();
                    AP.pathString2 = Path.Combine(AP.pathString2, fileName);
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {

                        if (AP.estatus == "2")
                        {
                            AP.MODvendorid = dt.Rows[i]["VENDORID"].ToString();
                            AP.MODvendname = dt.Rows[i]["VENDNAME"].ToString();
                            AP.MODvendcntct = dt.Rows[i]["VNDCNTCT"].ToString();
                            AP.MODphnumber1 = dt.Rows[i]["PHNUMBR1"].ToString();
                            AP.MODphnumber2 = dt.Rows[i]["PHNUMBR2"].ToString();
                            AP.MODphnumber3 = dt.Rows[i]["PHONE3"].ToString();
                            AP.MODupszone = dt.Rows[i]["UPSZONE"].ToString();
                            AP.MODacnmvndr = dt.Rows[i]["ACNMVNDR"].ToString();
                            AP.MODcurncyid = dt.Rows[i]["CURNCYID"].ToString();
                            AP.MODtxrgnnum = dt.Rows[i]["TXRGNNUM"].ToString();
                            AP.MODestatus = dt.Rows[i]["Estatus"].ToString();
                            AP.MODemail = dt.Rows[i]["Email"].ToString();
                            //Se crea el documento de texto.
                            File.WriteAllText(AP.pathString2,
                                 LimitLength(AP.MODvendorid, 12)
                               + LimitLength(AP.MODoperacion, 2)
                               + LimitLength(AP.MODvendname, 60)
                               + LimitLength(AP.MODtxrgnnum, 13)
                               + LimitLength(AP.MODphnumber1, 15)
                               + LimitLength(AP.MODvendcntct, 20)
                               + LimitLength(AP.MODemail, 39)
                               + LimitLength(AP.MODtipodecuentaar, 3)
                               + LimitLength(AP.MODtipomonedaar, 7)
                               + LimitLength(AP.MODbancoar, 4)
                               + LimitLength(AP.MODentidadar, 2)
                               + LimitLength(AP.MODplazaar, 3)
                               + LimitLength(AP.MODcuentaar, 20)
                               + LimitLength(AP.MODabonoaterceros, 1)
                               + LimitLength(AP.MODabonoSPEIS, 1)
                               + LimitLength(AP.MODabonoTEFs, 1)
                               + LimitLength(AP.MODotroservicio1, 1)
                               + LimitLength(AP.MODotroservicio2, 1)
                               + LimitLength(AP.MODotroservicio3, 1)
                               + LimitLength(AP.MODotroservicio4, 1)
                               + LimitLength(AP.MODotroservicio5, 1)
                               + LimitLength(AP.MODotroservicio6, 1)
                               + Environment.NewLine, Encoding.Unicode);
                            Console.WriteLine("Estatus dos con modificacion a proveedor: " + AP.MODvendorid + "\n");
                            dl.UpdateEstatusProveedores(2, 3, AP.MODvendorid);
                        }
                    }
                    break;
            }
        }
        public string LimitLength(string source, int maxLength)
        {
            string result = "";
            result = source.PadRight(maxLength, ' ');     
            return result;
        }
    }
}

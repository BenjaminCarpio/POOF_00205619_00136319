using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using SourceCode.Modelo;

namespace SourceCode.Controlador
{
    public class RegistryDAO
    {
        public static List<Registry> getPersonalHistory(string userID)
        
        {
            //Entradas, salidas acompañado de su respectiva fecha/hora y temperaturas
            string sql = $"SELECT * FROM REGISTRO WHERE idUsuario = '{userID}'";

            DataTable dt = ConnectionDB.ExecuteQuery(sql);
            List<Registry> list = new List<Registry>();
            foreach (DataRow Row in dt.Rows)
            {
                Registry reg = new Registry();
                reg.idRegistry = Convert.ToInt32(Row[0]);
                reg.idUser = Row[1].ToString();
                reg.entrance = Convert.ToBoolean(Row[2]);
                reg.date_time = Convert.ToString(Row[3]);
                reg.temperature = Convert.ToDouble(Row[4]);
                list.Add(reg);
            }
            return list;
        }

        public static void AddRegistry(string idUser, bool entrance, string fechahora, double temp)
        {
            string sql = "INSERT INTO REGISTRO (idUsuario, entrada, fechahora, temperatura) " +
                         $"VALUES ('{idUser}', {entrance}, '{fechahora}', {temp})";
            ConnectionDB.ExecuteNonQuery(sql);
            MessageBox.Show("Agregado correctamente");
        }
        
        public static List<Registry> GeneralHistory()
        {
            //Entradas, salidas acompañado de su respectiva fecha/hora y temperaturas
            string sql = $"SELECT * FROM REGISTRO";

            DataTable dt = ConnectionDB.ExecuteQuery(sql);
            List<Registry> list = new List<Registry>();
            foreach (DataRow Row in dt.Rows)
            {
                Registry reg = new Registry();
                reg.idRegistry = Convert.ToInt32(Row[0]);
                reg.idUser = Row[1].ToString();
                reg.entrance = Convert.ToBoolean(Row[2]);
                reg.date_time = Convert.ToString(Row[3]);
                reg.temperature = Convert.ToDouble(Row[4]);
                list.Add(reg);
            }
            return list;
        }

        public static List<Registry> TodayInWork()
        {
            var fecha = DateTime.Now.ToShortDateString();
            string sqn = $"SELECT sc.idUsuario, sc.entradas " +
                         $"FROM ( " +  
                         $"SELECT u.idUsuario, count(r.idUsuario) as entradas " + 
                         $"FROM REGISTRO r, USUARIO u " +
                         $"WHERE r.idUsuario = u.idUsuario " +
                         $"GROUP BY u.idUsuario " +
                         $") AS sc " +
                         $"WHERE sc.entradas % 2 != 0;";
            string sql = $"SELECT idUsuario, fechahora, temperatura FROM REGISTRO WHERE entrada = true and fechaHora = '{fecha}'";
                

            DataTable dt = ConnectionDB.ExecuteQuery(sql);
            List<Registry> list = new List<Registry>();
            foreach (DataRow Row in dt.Rows)
            {
                Registry reg = new Registry();
                reg.idUser = Row[0].ToString();
                reg.date_time = Convert.ToString(Row[1]);
                reg.temperature = Convert.ToDouble(Row[2]);
                list.Add(reg);
            }
            return list;
        }
    }
}
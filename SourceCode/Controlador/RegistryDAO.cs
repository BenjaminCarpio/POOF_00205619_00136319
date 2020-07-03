using System;
using System.Collections.Generic;
using System.Data;
using SourceCode.Modelo;

namespace SourceCode.Controlador
{
    public class RegistryDAO
    {
        public static List<Registry> getPersonalHistory()
        
        {
            //Entradas, salidas acompañado de su respectiva fecha/hora y temperaturas
            string sql = $"SELECT * FROM REGISTRO WHERE idUsuario = idUser";

            DataTable dt = ConnectionDB.ExecuteQuery(sql);
            List<Registry> list = new List<Registry>();
            foreach (DataRow Row in dt.Rows)
            {
                Registry reg = new Registry();
                reg.idRegistry = Convert.ToInt32(Row[0]);
                reg.idUser = Row[1].ToString();
                reg.entrance = Convert.ToBoolean(Row[2]);
                reg.date_time = Convert.ToDateTime(Row[3]);
                reg.temperature = Convert.ToDouble(Row[4]);
            }
            return list;
        }

        public static void AddRegistry()
        {
            string sql = $"INSERT INTO REGISTRO (idUsuario, entrada, fechahora, temperatura) " +
                         $"VALUES ()";
            ConnectionDB.ExecuteNonQuery(sql);
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
                reg.date_time = Convert.ToDateTime(Row[3]);
                reg.temperature = Convert.ToDouble(Row[4]);
            }
            return list;
        }

        public static List<Registry> TodayInWork()
        {
            var fecha = DateTime.Now.ToShortDateString();
            string sql = $"SELECT idUsuario, fechahora, temperatura FROM REGISTRO WHERE entrada = true and fechaHora = {fecha}";
            
            DataTable dt = ConnectionDB.ExecuteQuery(sql);
            List<Registry> list = new List<Registry>();
            foreach (DataRow Row in dt.Rows)
            {
                Registry reg = new Registry();
                reg.idUser = Row[0].ToString();
                reg.date_time = Convert.ToDateTime(Row[1]);
                reg.temperature = Convert.ToDouble(Row[2]);
            }
            return list;
        }
    }
}
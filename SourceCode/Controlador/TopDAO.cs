using System;
using System.Collections.Generic;
using System.Data;
using SourceCode.Modelo;

namespace SourceCode.Controlador
{
    public class TopDAO
    {
        public static List<Top> Top5Temperatures()
        {
            string sql = $"SELECT r.idUsuario, u.nombre, u.apellido, r.temperatura "+
                         $"FROM REGISTRO r, USUARIO u " +
                         $"WHERE r.idUsuario = u.idUsuario " +
                         $"ORDER BY r.temperatura DESC LIMIT 5;";
            DataTable dt = ConnectionDB.ExecuteQuery(sql);
            List<Top> list = new List<Top>();
            foreach (DataRow Row in dt.Rows)
            {
                Top topFive = new Top();
                topFive.iduser = Row[0].ToString();
                topFive.name = Row[1].ToString();
                topFive.lastname = Row[2].ToString();
                topFive.temperature = Convert.ToDouble(Row[3]);
                list.Add(topFive);
            }
            return list;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Data;

namespace SourceCode.Controlador
{
    public class DepartmentDAO
    {
        public static List<string> MostPeople()
        {
            string DepartmentCongestioned = " ";
            
            var fecha = DateTime.Now.ToShortDateString();
            string sql = "SELECT d.nombre, count(u.idDepartamento) as frecuencia" +
            "FROM REGISTRO r, DEPARTAMENTO d, USUARIO u" +
            "WHERE r.idUsuario = u.idUsuario AND d.idDepartamento = u.idDepartamento" +
            "GROUP BY d.idDepartamento" +
                "ORDER BY frecuencia DESC LIMIT 1;";

            DataTable dt = ConnectionDB.ExecuteQuery(sql);
            List<string> list = new List<string>();
            DepartmentCongestioned = dt.Rows[0].ToString();
            list.Add(DepartmentCongestioned);
            return list;
        }
    }
}
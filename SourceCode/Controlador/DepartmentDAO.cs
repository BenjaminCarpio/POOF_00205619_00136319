using System;
using System.Collections.Generic;
using System.Data;
using SourceCode.Modelo;

namespace SourceCode.Controlador
{
    public class DepartmentDAO
    {
        public static string MostPeople()
        {
            string DepartmentCongestioned = " ";
            
            var fecha = DateTime.Now.ToShortDateString();
            string sql = $"SELECT d.nombre, count(u.idDepartamento) as frecuencia " +
                         $"FROM REGISTRO r, DEPARTAMENTO d, USUARIO u " +
                         $"WHERE r.idUsuario = u.idUsuario AND d.idDepartamento = u.idDepartamento AND entrada = true AND fechaHora = '{fecha}' " +
                         $"GROUP BY d.idDepartamento ORDER BY frecuencia DESC LIMIT 1;";

            DataTable dt = ConnectionDB.ExecuteQuery(sql);
            DepartmentCongestioned = dt.Rows[0].ToString();
            return DepartmentCongestioned;
        }
    }
}
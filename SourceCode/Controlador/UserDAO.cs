using System;
using System.Collections.Generic;
using System.Data;
using SourceCode.Modelo;

namespace SourceCode.Controlador
{
    public class UserDAO
    {
        public static List<User> getIdUserList()
        
        {
            //Nombre de usuario
            string sql = $"SELECT idUsuario * FROM USUARIO";

            DataTable dt = ConnectionDB.ExecuteQuery(sql);
            List<User> list = new List<User>();
            foreach (DataRow Row in dt.Rows)
            {
                User userID = new User();
                userID.idUser = Row[1].ToString();
            }
            return list;
        }

        public static void AddEmployee()
        {
            string sql =
                $"INSERT INTO USUARIO (idUsuario, idDepartamento, contrasenia, nombre, apellido, dui, fechaNacimiento) " +
                $"VALUES ()";
            ConnectionDB.ExecuteNonQuery(sql);
        }

        public static void QuitEmpoloyee()
        {
            string sql = $"DELETE FROM USUARIO WHERE idUsuario = idUser";
            ConnectionDB.ExecuteNonQuery(sql);
            
        }

        public static void Top5Temperatures()
        {
            string sql = $"SELECT r.idUsuario, u.nombre, u.apellido, r.temperatura "+
                         $"FROM REGISTRO r, USUARIO u " +
                         $"WHERE r.idUsuario = u.idUsuario " +
                         $"ORDER BY r.temperatura DESC LIMIT 5;";
            DataTable dt = ConnectionDB.ExecuteQuery(sql);
            //List<> list = new List<>();//Crear clase xd
            foreach (DataRow Row in dt.Rows)
            {
                
            }
            ///return list;
        }
    }
}
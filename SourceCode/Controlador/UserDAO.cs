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
                list.Add(userID);
            }
            return list;
        }

        public static List<User> getUserFullList()
        {
            string sql = $"SELECT * FROM USUARIO";

            DataTable dt = ConnectionDB.ExecuteQuery(sql);
            List<User> list = new List<User>();
            foreach (DataRow Row in dt.Rows)
            {
                User user = new User();
                user.idUser = Row[0].ToString();
                user.idDepartment = Convert.ToInt32(Row[1]);
                user.name = Row[3].ToString();
                user.lastName = Row[4].ToString();
                user.dui = Row[5].ToString();
                list.Add(user);
            }
            return list;
        }
        
        public static List<User> getSeniorList()
        {
            string sql = $"SELECT * FROM USUARIO";

            DataTable dt = ConnectionDB.ExecuteQuery(sql);
            List<User> list = new List<User>();
            foreach (DataRow Row in dt.Rows)
            {
                User user = new User();
                user.idUser = Row[0].ToString();
                user.idDepartment = Convert.ToInt32(Row[1]);
                user.name = Row[3].ToString();
                user.lastName = Row[4].ToString();
                user.dui = Row[5].ToString();
                list.Add(user);
            }
            return list;
        }

        public static void AddEmployee(string carnet, int department, string name, string lastname, string dui, string birthdate)
        {
            string sql =
                $"INSERT INTO USUARIO (idUsuario, idDepartamento, contrasenia, nombre, apellido, dui, fechaNacimiento) " +
                $"VALUES ('{carnet}', {department}, '{name}', '{name}', '{lastname}', '{dui}', '{birthdate}')";
            ConnectionDB.ExecuteNonQuery(sql);
        }

        public static void QuitEmpoloyee(string idUser)
        {
            string sql = $"DELETE FROM USUARIO WHERE idUsuario = '{idUser}'";
            ConnectionDB.ExecuteNonQuery(sql);
            
        }
    }
}
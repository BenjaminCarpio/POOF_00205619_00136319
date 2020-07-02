using System;

namespace SourceCode.Modelo
{
    public class User
    {
        public int idUser;
        public int idDepartment;
        public string password;
        public string name;
        public string lastName;
        public string dui;
        public DateTime birthDate;

        public User(int idUser, int idDepartment, string password, string name, string lastName, string dui, DateTime birthDate)
        {
            this.idUser = idUser;
            this.idDepartment = idDepartment;
            this.password = password;
            this.name = name;
            this.lastName = lastName;
            this.dui = dui;
            this.birthDate = birthDate;
        }
    }
}
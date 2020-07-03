using System;

namespace SourceCode.Modelo
{
    public class User
    {
        public string idUser { get; set; }
        public int idDepartment { get; set; }
        public string password { get; set; }
        public string name { get; set; }
        public string lastName { get; set; }
        public string dui { get; set; }
        public string birthDate { get; set; }

        public User(){}
        public User(string idUser, int idDepartment, string password, string name, string lastName, string dui, string birthDate)
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
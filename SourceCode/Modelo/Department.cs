namespace SourceCode.Modelo
{
    public class Department
    {
        public int idDepartment { get; set; }
        public string name { get; set; }
        public string location { get; set; }

        public Department(){}
        public Department(int idDepartment, string name, string location)
        {
            this.idDepartment = idDepartment;
            this.name = name;
            this.location = location;
        }
    }
}
namespace SourceCode.Modelo
{
    public class Department
    {
        public int idDepartment;
        public string name;
        public string location;

        public Department(int idDepartment, string name, string location)
        {
            this.idDepartment = idDepartment;
            this.name = name;
            this.location = location;
        }
    }
}
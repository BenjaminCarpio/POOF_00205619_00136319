namespace SourceCode.Modelo
{
    public class Top
    {
        public string iduser { get; set;}
        public string name { get; set;}
        public string lastname { get; set;}
        public double temperature { get; set;}

        public Top(){ }

        public Top(string iduser, string name, string lastname, double temperature)
        {
            this.iduser = iduser;
            this.name = name;
            this.lastname = lastname;
            this.temperature = temperature;
        }
    }
}
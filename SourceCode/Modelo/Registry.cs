using System;

namespace SourceCode.Modelo
{
    public class Registry
    {
        public int idRegistry { get; set; }
        public string idUser { get; set; }
        public bool entrance { get; set; }
        public DateTime date_time { get; set; }
        public double temperature { get; set; }

        public Registry(){}
        public Registry(int idRegistry, string idUser, bool entrance, DateTime dateTime, double temperature)
        {
            this.idRegistry = idRegistry;
            this.idUser = idUser;
            this.entrance = entrance;
            date_time = dateTime;
            this.temperature = temperature;
        }
    }
}
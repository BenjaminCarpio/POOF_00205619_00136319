using System;

namespace SourceCode.Modelo
{
    public class Registry
    {
        public int idRegistry;
        public int idUser;
        public bool entrance;
        public DateTime date_time;
        public double temperature;

        public Registry(int idRegistry, int idUser, bool entrance, DateTime dateTime, double temperature)
        {
            this.idRegistry = idRegistry;
            this.idUser = idUser;
            this.entrance = entrance;
            date_time = dateTime;
            this.temperature = temperature;
        }
    }
}
using System;
using System.IO;
using System.Text.Json;

namespace AlcoGame
{
    public struct PersonalParameters
    {
        // Здоровье
        public sbyte health {get; set;}
        // Мана 
        public sbyte mana {get; set;}
        // Жизнерадостность
        public sbyte cFul {get; set;}
        // Усталость
        public sbyte fatigue {get; set;}
        // Деньги
        public int cash {get; set;}
    }
    class Persona
    {
        PersonalParameters stats = new PersonalParameters();

        public void savePersonaConfig(string path="persona_config.json") {}
        public void loadPersonaConfig(string path="persona_config.json") {
            string text = File.ReadAllText(path);
            stats = JsonSerializer.Deserialize<PersonalParameters>(text);
        }
        public PersonalParameters getPersonaStats() {
            return stats;
        }
    }
}
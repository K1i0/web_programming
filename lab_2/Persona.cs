using System;
using System.IO;
using System.Text.Json;

namespace AlcoGame
{

    class PersonParameterException :  ArgumentException
    {
        public int Value { get;}
        public PersonParameterException(string message, int val)
            : base(message)
            {
                Value = val;
            }
        public int ShowMessage() {
            switch (Value)
            {
                case -1:
                    Console.Write($"Error: {Message}");
                    Console.WriteLine("(parameter: Health)");
                    break;
                case -2:
                    Console.Write($"Error: {Message}");
                    Console.WriteLine("(parameter: Mana)");
                    break;
                case -3:
                    Console.Write($"Error: {Message}");
                    Console.WriteLine("(parameter: CFul)");
                    break;
                case -4:
                    Console.Write($"Error: {Message}");
                    Console.WriteLine("(parameter: Fatigue)");
                    break;
                default:
                    Console.WriteLine("Unknown error!");
                    break;
            }
            return Value;
        }
    }

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


        public void updateHealth(sbyte value) {
            if (health + value >= 0 && health + value <= 100) {
                health += value;
            } else {
                throw new PersonParameterException("Cannot update parameter. Invariant exception", -1);
            }
        }

        public void updateMana(sbyte value) {
            if (mana + value >= 0 && mana + value <= 100) {
                mana += value;
            } else {
                throw new PersonParameterException("Cannot update parameter. Invariant exception", -2);
            }
        }

        public void updateCFul(sbyte value) {
            if (cFul + value >= -10 && cFul + value <= 10) {
                cFul += value;
            } else {
                throw new PersonParameterException("Cannot update parameter. Invariant exception", -3);
            }
        }

        public void updateFatigue(sbyte value) {
            if (fatigue + value >= 0 && fatigue + value <= 100) {
                fatigue += value;
            } else {
                throw new PersonParameterException("Cannot update parameter. Invariant exception", -4);
            }
        }

        public void updateCash(int value) {
            cash += value;
        }

        public void printPersonalParameters() {
            var options = new JsonSerializerOptions { WriteIndented = true };
            Console.WriteLine(JsonSerializer.Serialize(this, options));
        }
    }
    class Persona
    {
        PersonalParameters stats = new PersonalParameters();

        public void savePersonaConfig(string path="persona_config.json") {
            File.WriteAllText(path, JsonSerializer.Serialize(stats));
        }
        public void loadPersonaConfig(string path="persona_config.json") {
            string text = File.ReadAllText(path);
            stats = JsonSerializer.Deserialize<PersonalParameters>(text);
        }
        public PersonalParameters getPersonaStats() {
            return stats;
        }
        public int updatePersonaStats(sbyte health=0, sbyte mana=0, sbyte cFul=0, sbyte fatigue=0, int cash=0) {
            try { stats.updateHealth(health); }
            catch (PersonParameterException ex) { ex.ShowMessage(); }

            try { stats.updateMana(mana); }
            catch (PersonParameterException ex) { ex.ShowMessage(); }
            
            try { stats.updateCFul(cFul); }
            catch (PersonParameterException ex) { ex.ShowMessage(); }
            
            try { stats.updateFatigue(fatigue); }
            catch (PersonParameterException ex) { ex.ShowMessage(); }

            stats.updateCash(cash);

            return 0;
        }

        public void printPersonaParameters() {
            Console.WriteLine("_____Current personal parameters_____");
            stats.printPersonalParameters();
            Console.WriteLine("_____________________________________\n");
        }
    }
}
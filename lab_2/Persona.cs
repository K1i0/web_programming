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
                case -5:
                    Console.Write($"Error: {Message}");
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
        const sbyte healthMin = 0;
        const sbyte healthMax = 100;
        // Мана 
        public sbyte mana {get; set;}
        const sbyte manaMin = 0;
        const sbyte manaMax = 100;
        // Жизнерадостность
        public sbyte cFul {get; set;}
        const sbyte cFulMin = -10;
        const sbyte cFulMax = 10;
        // Усталость
        public sbyte fatigue {get; set;}
        const sbyte fatigueMin = 0;
        const sbyte fatigueMax = 100;
        // Деньги
        public int cash {get; set;}

        public void updateHealth(sbyte value) {
            health = (health + value < healthMin) ? healthMin : (health + value > healthMax) ? healthMax : (sbyte)(health + value);
        }

        public void updateMana(sbyte value) {
            mana = (mana + value < manaMin) ? manaMin : (mana + value > manaMax) ? manaMax : (sbyte)(mana + value);
        }

        public void updateCFul(sbyte value) {
            cFul = (cFul + value < cFulMin) ? cFulMin : (cFul + value > cFulMax) ? cFulMax : (sbyte)(cFul + value);
        }

        public void updateFatigue(sbyte value) {
            fatigue = (fatigue + value < fatigueMin) ? fatigueMin : (fatigue + value > fatigueMax) ? fatigueMax : (sbyte)(fatigue + value);
        }

        public void updateCash(int value) {
            cash += value;
        }

        public void checkStats() {
            if (health > healthMax || health < healthMin) {
                throw new PersonParameterException("Incorrect health value when loading person configuration!", -5);
            } else if (mana > manaMax || mana < manaMin) {
                throw new PersonParameterException("Incorrect mana value when loading person configuration!", -5);
            } else if (cFul > cFulMax || cFul < cFulMin) {
                throw new PersonParameterException("Incorrect cFul value when loading person configuration!", -5);
            } else if (fatigue > fatigueMax || fatigue < fatigueMin) {
                throw new PersonParameterException("Incorrect fatigue value when loading person configuration!", -5);
            }
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
            var options = new JsonSerializerOptions { WriteIndented = true };
            File.WriteAllText(path, JsonSerializer.Serialize(stats, options));
        }
        public int loadPersonaConfig(string path="persona_config.json") {
            string text = File.ReadAllText(path);
            stats = JsonSerializer.Deserialize<PersonalParameters>(text);

            try
            {
                stats.checkStats();
            }
            catch (PersonParameterException ex)
            {
                ex.ShowMessage();
                return -1;
            }

            return 0;
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
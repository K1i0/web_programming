using System;

namespace AlcoGame
{
    class AlcoGame
    {
        static void Main(string[] args)
        {
            // Console.InputEncoding = System.Text.Encoding.GetEncoding("utf-16");
            // Console.Write("Enter the region to view statistics: ");
            // Guid myuuid = Guid.NewGuid();
            // string myuuidAsString = myuuid.ToString();
            Persona person = new Persona();
            person.loadPersonaConfig();
            PersonalParameters paraaams = person.getPersonaStats();
            Console.WriteLine($"Health : {paraaams.health}");
            Console.WriteLine($"Mana : {paraaams.mana}");
            Console.WriteLine($"cFul : {paraaams.cFul}");

            GameConfig gameConfig = new GameConfig();
            gameConfig.loadActionsConfig();
        }
    }
}
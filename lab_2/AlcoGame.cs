using System;

namespace AlcoGame
{
    class AlcoGame
    {
        static void Main(string[] args)
        {
            startAlcoGame();
        }

        static Persona person = new Persona();
        static Actions actions = new Actions();

        static void printMenue() {
            Console.Write("Choose an action (enter 8 to exit, 0 to save progress):\n\t" + 
                    "1.Work\n\t" + 
                    "2.Contemplate Nature\n\t" +
                    "3.Wine And Series\n\t" + 
                    "4.Go Bar\n\t" +
                    "5.Drink With Marginals\n\t" +
                    "6.Sing In The Metro\n\t" +
                    "7.Sleep\n" + 
                    "Your choice: ");
        }

        static void startAlcoGame() {
            Console.Clear();
            try
            {
                if (person.loadPersonaConfig() < 0) {
                    return;
                }
            }
            catch (System.Text.Json.JsonException ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
            while (true)
            {
                person.printPersonaParameters();
                printMenue();
                int variantChoice;

                while(true) {
                    string? str = Console.ReadLine();
                    if (Int32.TryParse(str, out variantChoice))
                        break;
                    else {
                        Console.Clear();
                        person.printPersonaParameters();
                        printMenue();
                        Console.WriteLine();
                        continue;
                    }
                        
                }
                
                Console.Clear();
                switch (variantChoice)
                {
                    case 0:
                        person.savePersonaConfig();
                        break;
                    case 1:
                        actions.Work(ref person);
                        break;
                    case 2:
                        actions.ContemplateNature(ref person);
                        break;
                    case 3:
                        actions.WineAndSeries(ref person);
                        break;
                    case 4:
                        actions.GoBar(ref person);
                        break;
                    case 5:
                        actions.DrinkWithMarginals(ref person);
                        break;
                    case 6:
                        actions.SingInMetro(ref person);
                        break;
                    case 7:
                        actions.Sleep(ref person);
                        break;
                    case 8:
                        return;
                    default:
                        Console.WriteLine("-------------Иди в хуй!-------------");
                        break;
                }
            }
        }
    }
}
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

        static void startAlcoGame() {
            person.loadPersonaConfig();
            while (true)
            {
                person.printPersonaParameters();
                Console.Write("Choose an action (enter 8 to exit):\n\t" + 
                    "1.Work\n\t" + 
                    "2.Contemplate Nature\n\t" +
                    "3.Wine And Series\n\t" + 
                    "4.Go Bar\n\t" +
                    "5.Drink With Marginals\n\t" +
                    "6.Sing In The Metro\n\t" +
                    "7.Sleep\n");
                int variantChoice = Convert.ToInt16(Console.ReadLine());
                Console.Clear();
                switch (variantChoice)
                {
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
                        Console.WriteLine("Иди в хуй!");
                        break;
                }
            }
        }
    }
}
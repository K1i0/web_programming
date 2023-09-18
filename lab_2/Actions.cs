using System;
using System.Text.Json;

namespace AlcoGame
{
    class GameConfig
    {
        WorkStats workStats = new WorkStats();
        //Пойти на работу
        struct WorkStats
        {
            public sbyte mana {get; set;} = -30;
            sbyte cFul = -5;
            sbyte fatigue = 70;
            int cash = 100;

            public WorkStats(){}
        }

        //Созерцать природу
        struct ContemplateNatureStats
        {
            sbyte mana = -10;
            sbyte cFul = 1;
            sbyte fatigue = 10;

            public ContemplateNatureStats() {}
        }

        //Пить вино, смотреть сериал
        struct WineAndSeriesStats
        {
            sbyte health = -5;
            sbyte mana = 30;
            sbyte cFul = -1;
            sbyte fatigue = 10;
            int cash = -20;

            public WineAndSeriesStats() {}
        }

        // Сходить в бар
        struct GoBarStats
        {
            sbyte health = -10;
            sbyte mana = 60;
            sbyte cFul = 1;
            sbyte fatigue = 40;
            int cash = -100;

             public GoBarStats() {}
        }

        // Выпить с маргинальными личностями
        struct DrinkWithMarginalsStats
        {
            sbyte health = -80;
            sbyte mana = 90;
            sbyte cFul = 5;
            sbyte fatigue = 80;
            int cash = -150;

            public DrinkWithMarginalsStats() {}
        }

        // Петь в метро
        struct SingInMetroStats
        {
            sbyte mana = 10;
            sbyte cFul = 1;
            sbyte fatigue = 20;
            int cash = 10; //+ $10 (еще + $50 если изначально алкоголь был > 40 & < 70)

            public SingInMetroStats() {}
        }

        // Спать
        struct SleepStats
        {
            sbyte health = 90;
            sbyte mana = -50;
            sbyte cFul = -3;
            sbyte fatigue = -70;

            public SleepStats() {}
        }

        public void loadActionsConfig(string path="actions_config.json") {
            string text = File.ReadAllText(path);
            
            var jsonDocument = JsonDocument.Parse(text).RootElement;
            var statWork = jsonDocument.GetProperty("actionWork");
            workStats = JsonSerializer.Deserialize<WorkStats>(statWork);
            Console.WriteLine(workStats.mana);
        }
    }
}
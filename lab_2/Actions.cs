using System;
using System.ComponentModel;
using System.Text.Json;

namespace AlcoGame
{
    class ActionsConfig
    {
        WorkStats workStats = new WorkStats();
        ContemplateNatureStats contemplateNatureStats = new ContemplateNatureStats();
        WineAndSeriesStats wineAndSeriesStats = new WineAndSeriesStats();
        GoBarStats goBarStats = new GoBarStats();
        DrinkWithMarginalsStats drinkWithMarginalsStats = new DrinkWithMarginalsStats();
        SingInMetroStats singInMetroStats = new SingInMetroStats();
        SleepStats sleepStats = new SleepStats();
        //Пойти на работу
        public struct WorkStats
        {
            public sbyte mana {get; set;} = -30;
            public sbyte cFul {get; set;} = -5;
            public sbyte fatigue {get; set;} = 70;
            public int cash {get; set;} = 100;

            public WorkStats(){}
        }

        //Созерцать природу
        public struct ContemplateNatureStats
        {
            public sbyte mana {get; set;} = -10;
            public sbyte cFul {get; set;} = 1;
            public sbyte fatigue {get; set;} = 10;

            public ContemplateNatureStats() {}
        }

        //Пить вино, смотреть сериал
        public struct WineAndSeriesStats
        {
            public sbyte health {get; set;} = -5;
            public sbyte mana {get; set;} = 30;
            public sbyte cFul {get; set;} = -1;
            public sbyte fatigue {get; set;}= 10;
            public int cash {get; set;}= -20;

            public WineAndSeriesStats() {}
        }

        // Сходить в бар
        public struct GoBarStats
        {
            public sbyte health {get; set;}= -10;
            public sbyte mana {get; set;}= 60;
            public sbyte cFul {get; set;}= 1;
            public sbyte fatigue {get; set;}= 40;
            public int cash {get; set;}= -100;

            public GoBarStats() {}
        }

        // Выпить с маргинальными личностями
        public struct DrinkWithMarginalsStats
        {
            public sbyte health {get; set;} = -80;
            public sbyte mana {get; set;}= 90;
            public sbyte cFul {get; set;}= 5;
            public sbyte fatigue {get; set;}= 80;
            public int cash {get; set;}= -150;

            public DrinkWithMarginalsStats() {}
        }

        // Петь в метро
        public struct SingInMetroStats
        {
            public sbyte mana {get; set;}= 10;
            public sbyte cFul {get; set;}= 1;
            public sbyte fatigue {get; set;}= 20;
            public int cash {get; set;}= 10; //+ $10 (еще + $50 если изначально алкоголь был > 40 & < 70)

            public SingInMetroStats() {}
        }

        // Спать
        public struct SleepStats
        {
            public sbyte health {get; set;}= 90;
            public sbyte mana {get; set;}= -50;
            public sbyte cFul {get; set;}= -3;
            public sbyte fatigue {get; set;}= -70;

            public SleepStats() {}
        }

        public void printActionsConfig() {
            var options = new JsonSerializerOptions { WriteIndented = true };
            Console.WriteLine(JsonSerializer.Serialize(workStats, options));
            Console.WriteLine(JsonSerializer.Serialize(contemplateNatureStats, options));
            Console.WriteLine(JsonSerializer.Serialize(wineAndSeriesStats, options));
            Console.WriteLine(JsonSerializer.Serialize(goBarStats, options));
            Console.WriteLine(JsonSerializer.Serialize(drinkWithMarginalsStats, options));
            Console.WriteLine(JsonSerializer.Serialize(singInMetroStats, options));
            Console.WriteLine(JsonSerializer.Serialize(sleepStats, options));
        }

        public void loadActionsConfig(string path="actions_config.json") {
            string text = File.ReadAllText(path);
            var jsonDocument = JsonDocument.Parse(text).RootElement;
            
            try
            {
                var actionWork = jsonDocument.GetProperty("actionWork");
                workStats = JsonSerializer.Deserialize<WorkStats>(actionWork);
            }
            catch (KeyNotFoundException)
            {
                
                Console.WriteLine("Object \"actionWork\" is not found in action config!");
            }

            try
            {
                var actionContemplateNature = jsonDocument.GetProperty("actionContemplateNature");
                contemplateNatureStats = JsonSerializer.Deserialize<ContemplateNatureStats>(actionContemplateNature);
            }
            catch (KeyNotFoundException)
            {
                Console.WriteLine($"Object \"actionContemplateNature\" is not found in action config!");
            }
            
            
            try
            {
                var actionWineAndSeries = jsonDocument.GetProperty("actionWineAndSeries");
                wineAndSeriesStats = JsonSerializer.Deserialize<WineAndSeriesStats>(actionWineAndSeries);
            }
            catch (KeyNotFoundException)
            {
                Console.WriteLine($"Object \"actionWineAndSeries\" is not found in action config!");
            }
        
            try
            {
                var actionGoBar = jsonDocument.GetProperty("actionGoBar");
                goBarStats = JsonSerializer.Deserialize<GoBarStats>(actionGoBar);
            }
            catch (KeyNotFoundException)
            {
                
                Console.WriteLine($"Object \"actionGoBar\" is not found in action config!");
            }

            try
            {
                var actionDrinkWithMarginals = jsonDocument.GetProperty("actionDrinkWithMarginals");
                drinkWithMarginalsStats = JsonSerializer.Deserialize<DrinkWithMarginalsStats>(actionDrinkWithMarginals);
            }
            catch (KeyNotFoundException)
            {
                
                Console.WriteLine($"Object \"actionDrinkWithMarginals\" is not found in action config!");
            }

            try
            {
                var actionSingInMetro = jsonDocument.GetProperty("actionSingInMetro");
                singInMetroStats = JsonSerializer.Deserialize<SingInMetroStats>(actionSingInMetro);
            }
            catch (KeyNotFoundException)
            {
                Console.WriteLine($"Object \"actionSingInMetro\" is not found in action config!");
            }
           
        
            try
            {
                var actionSleep = jsonDocument.GetProperty("actionSleep");
                sleepStats = JsonSerializer.Deserialize<SleepStats>(actionSleep);
            }
            catch (KeyNotFoundException)
            {
                
                Console.WriteLine($"Object \"actionSleep\" is not found in action config!");
            }
        }

        public WorkStats getWorkStats() {return workStats;}
        public ContemplateNatureStats getContemplateNatureStats() {return contemplateNatureStats;}
        public WineAndSeriesStats getWineAndSeriesStats() {return wineAndSeriesStats;}
        public GoBarStats getGoBarStats() {return goBarStats;}
        public DrinkWithMarginalsStats getDrinkWithMarginalsStats() {return drinkWithMarginalsStats;}
        public SingInMetroStats getSingInMetroStats() {return singInMetroStats;}
        public SleepStats getSleepStats() {return sleepStats;}
    }

    class Actions
    {
        ActionsConfig actionsConfig = new ActionsConfig();

        public Actions(string config="actions_config.json") {
            actionsConfig.loadActionsConfig(config);
        }

        public void Work(ref Persona person) {
            person.updatePersonaStats(
                mana: actionsConfig.getWorkStats().mana, 
                cFul: actionsConfig.getWorkStats().cFul, 
                fatigue: actionsConfig.getWorkStats().fatigue, 
                cash: actionsConfig.getWorkStats().cash
            );
        }

        public void ContemplateNature(ref Persona person) {
            person.updatePersonaStats(
                mana: actionsConfig.getContemplateNatureStats().mana, 
                cFul: actionsConfig.getContemplateNatureStats().cFul, 
                fatigue: actionsConfig.getContemplateNatureStats().fatigue
            );
        }

        public void WineAndSeries(ref Persona person) {
            person.updatePersonaStats(
                health: actionsConfig.getWineAndSeriesStats().health,
                mana: actionsConfig.getWineAndSeriesStats().mana, 
                cFul: actionsConfig.getWineAndSeriesStats().cFul, 
                fatigue: actionsConfig.getWineAndSeriesStats().fatigue, 
                cash: actionsConfig.getWineAndSeriesStats().cash
            );
        }

        public void GoBar(ref Persona person) {
            person.updatePersonaStats(
                health: actionsConfig.getGoBarStats().health,
                mana: actionsConfig.getGoBarStats().mana, 
                cFul: actionsConfig.getGoBarStats().cFul, 
                fatigue: actionsConfig.getGoBarStats().fatigue, 
                cash: actionsConfig.getGoBarStats().cash
            );
        }

        public void DrinkWithMarginals(ref Persona person) {
            person.updatePersonaStats(
                health: actionsConfig.getDrinkWithMarginalsStats().health,
                mana: actionsConfig.getDrinkWithMarginalsStats().mana, 
                cFul: actionsConfig.getDrinkWithMarginalsStats().cFul, 
                fatigue: actionsConfig.getDrinkWithMarginalsStats().fatigue, 
                cash: actionsConfig.getDrinkWithMarginalsStats().cash
            );
        }

        public void SingInMetro(ref Persona person) {
            person.updatePersonaStats(
                mana: actionsConfig.getSingInMetroStats().mana, 
                cFul: actionsConfig.getSingInMetroStats().cFul, 
                fatigue: actionsConfig.getSingInMetroStats().fatigue, 
                cash: actionsConfig.getSingInMetroStats().cash
            );
        }

        public void Sleep(ref Persona person) {
            person.updatePersonaStats(
                health: actionsConfig.getSleepStats().health,
                mana: actionsConfig.getSleepStats().mana, 
                cFul: actionsConfig.getSleepStats().cFul, 
                fatigue: actionsConfig.getSleepStats().fatigue
            );
        }
    }
}
using System;
using Microsoft.VisualBasic.FileIO;

namespace parserCSV
{
    struct Region
    {
        public string region_name = "";
        Dictionary<int, double> stats = new Dictionary<int, double>();

        double min = double.PositiveInfinity;
        double max = double.NegativeInfinity;
        double avg = 0.0;
        double variance = 0.0;

        public Region(string name) {
            region_name = name;
        }

        public void statInsert(int year, double stat) {
            stats.Add(year, stat);
        }

        public void allCSVStatInsert(ref string[] years, ref string[] region_stats) {
            for(int i = 1; i < region_stats.Length; i++) {
                statInsert(Convert.ToInt32(years[i]), Convert.ToDouble(region_stats[i].Replace('.', ',')));
            }   
        }

        public void printRegionStats() {
            Console.WriteLine($"Region: {region_name}");
            Console.WriteLine($"Minimal Stat: {min}");
            Console.WriteLine($"Maximum Stat: {max}");
            Console.WriteLine($"Average Stat: {avg}");
            Console.WriteLine($"Variance Stat: {variance}");
            foreach(var stat in stats)
            {
                Console.WriteLine($"\tyear: {stat.Key}  stats: {stat.Value}");
            }
        }

        public void calculateMinStat() {
            foreach (var stat in stats)
            {
                if (min > stat.Value) {
                    min = stat.Value;
                }
            }
        }
        public void calculateMaxStat() {
            foreach (var stat in stats)
            {
                if (max < stat.Value) {
                    max = stat.Value;
                }
            }
        }
        public void calculateAvgStat() {
            foreach (var stat in stats)
            {   
                avg += stat.Value;
            }
            avg /= stats.Count;
        }
        public void calculateVarianceStat() {
            if (avg == 0.0) {
                calculateAvgStat();
            }
            //Выборочная дисперсия
            foreach (var stat in stats)
            {   
                double val = stat.Value;
                variance += 1.0/(stats.Count - 1) * Math.Pow(Math.Abs(val - avg), 2);
            }
        }
    }

    class ParseCSV
    {
        string pathCSV = "res/postrad.csv";
        List<Region> regions_list = new List<Region>();
        bool isCached = false;

        public void createRegionStats() {
            string[] rows = File.ReadAllLines(pathCSV);
            string[] years = rows[0].Split(',');
            for (int i = 1; i < rows.Length; i++)
            {
                string[] region_stats = rows[i].Split(',');
                Region reg = new Region(region_stats[0]);
                reg.allCSVStatInsert(ref years, ref region_stats);
                reg.calculateMinStat();
                reg.calculateMaxStat();
                reg.calculateAvgStat();
                reg.calculateVarianceStat();
                regions_list.Add(reg);
            }
            isCached = true;
        }
        public void printCertRegionStats(string name) {
            if (isCached) {
                int index = regions_list.FindIndex(f => f.region_name == name);
                if (index >= 0) 
                {
                    regions_list[index].printRegionStats();
                } else {
                    Console.WriteLine($"Region: {name} is not found");
                }
            } else {
                Console.WriteLine("The data has not been cached yet");
            }
        }

        public void printAllRegionStats() {
            if (isCached) {
                foreach(var reg in regions_list) {
                    reg.printRegionStats();
                }
            } else {
                Console.WriteLine("The data has not been cached yet");
            }
        }
    }

    
}
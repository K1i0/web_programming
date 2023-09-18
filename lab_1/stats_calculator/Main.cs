using System;
using parserCSV;
using Microsoft.VisualBasic.FileIO;

class ParseCSV
{
    static void Main(string[] args)
    {
        Console.InputEncoding = System.Text.Encoding.GetEncoding("utf-16");
        Console.Write("Enter the region to view statistics: ");
        string? input_region = Console.ReadLine();
        while(string.IsNullOrEmpty(input_region)) {
            input_region = Console.ReadLine();
        }
        parserCSV.ParseCSV parserObject = new parserCSV.ParseCSV();
        parserObject.createRegionStats();
        parserObject.printCertRegionStats(input_region);
    }

}
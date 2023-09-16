using System;
using parserCSV;
using Microsoft.VisualBasic.FileIO;



class ParseCSV
{
    // static string pathCSV = "doc/postrad.csv";
    static void Main(string[] args)
    {

        parserCSV.ParseCSV parserObject = new parserCSV.ParseCSV();
        parserObject.createRegionStats();
        parserObject.printCertRegionStats("Новосибирская область");
    }

}
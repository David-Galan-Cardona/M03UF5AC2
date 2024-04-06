using System;
using M03UF5AC2.Classes;

namespace M03UF5AC2
{
    public class M03UF5AC2
    {
        public static void Main()
        {
            string path = "..\\..\\..\\Files\\Consum_d_aigua_a_Catalunya.csv";
            var records = Helper.GetCSVData(path);
            Helper.CreateXMLFileWithLINQ(records);
            Console.WriteLine();
            Helper.IdentifyComarquesWithPopulationSuperiorTo(records, 200000);
            Console.WriteLine();
            Helper.CalculateAverageDomesticConsumptionPerComarca(records);
            Console.WriteLine();
            Helper.ShowComarquesWithHighestDomesticConsumptionPerCapita(records);
            Console.WriteLine();
            Helper.ShowComarquesWithLowestDomesticConsumptionPerCapita(records);
            Console.WriteLine();
            Helper.FilterComarquesByNameOrCode(records, "Barcelona");
            Console.WriteLine();
            Helper.FilterComarquesByNameOrCode(records, "1");
        }
        
    }
}
using CsvHelper;
using System.Globalization;
using System.Xml.Linq;

namespace M03UF5AC2.Classes
{
    public class Helper
    {
        public static void IdentifyComarquesWithPopulationSuperiorTo(List<Registre> records, int population)
        {
            var comarques = records.FindAll(record => record.Població > population);
            foreach (var comarca in comarques)
            {
                Console.WriteLine(comarca.Comarca);
            }
        }
        public static void CalculateAverageDomesticConsumptionPerComarca(List<Registre> records)
        {
            var comarques = records.GroupBy(record => record.Comarca);
            foreach (var comarca in comarques)
            {
                var average = comarca.Average(record => record.Consum_domèstic_per_càpita);
                Console.WriteLine($"{comarca.Key}: {average}");
            }
        }
        public static void ShowComarquesWithHighestDomesticConsumptionPerCapita(List<Registre> records)
        {
            var comarques = records.OrderByDescending(record => record.Consum_domèstic_per_càpita).Take(5);
            foreach (var comarca in comarques)
            {
                Console.WriteLine($"{comarca.Comarca}: {comarca.Consum_domèstic_per_càpita}");
            }
        }
        public static void ShowComarquesWithLowestDomesticConsumptionPerCapita(List<Registre> records)
        {
            var comarques = records.OrderBy(record => record.Consum_domèstic_per_càpita).Take(5);
            foreach (var comarca in comarques)
            {
                Console.WriteLine($"{comarca.Comarca}: {comarca.Consum_domèstic_per_càpita}");
            }
        }
        public static void FilterComarquesByNameOrCode(List<Registre> records, string filter)
        {
            var comarques = records.FindAll(record => record.Comarca.Equals(filter) || record.Codi_comarca.ToString().Equals(filter));
            foreach (var comarca in comarques)
            {
                Console.WriteLine(comarca.Comarca);
            }
        }
        public static List<Registre> GetCSVData(string path)
        {
            using var reader = new StreamReader(path);
            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
            return csv.GetRecords<Registre>().ToList();
        }
        public static void CreateXMLFileWithLINQ(List<Registre> records)
        {
            XDocument xmlDocs = new XDocument(new XElement("records"));
            foreach (var registre in records)
            {
                XElement xmlDoc = new XElement("registre",
                    new XElement("Any", registre.Any),
                    new XElement("Codi_comarca", registre.Codi_comarca),
                    new XElement("Comarca", registre.Comarca),
                    new XElement("Població", registre.Població),
                    new XElement("Domèstic_xarxa", registre.Domèstic_xarxa),
                    new XElement("Activitats_econòmiques_i_fonts_pròpies", registre.Activitats_econòmiques_i_fonts_pròpies),
                    new XElement("Total", registre.Total),
                    new XElement("Consum_domèstic_per_càpita", registre.Consum_domèstic_per_càpita)
                    );
                xmlDocs.Element("records").Add(xmlDoc);
            }
            string xmlFilePath = "..\\..\\..\\Files\\csvread.xml";
            xmlDocs.Save(xmlFilePath);
            Console.WriteLine("Documento XML creado correctamente.");
        }
    }
}

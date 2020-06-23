using System;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace SurrogateProperty
{
    class Program
    {
        static void Main(string[] args)
        {
            var stats = new CountryStats();
            stats.Capitals.Add("France", "Paris");
            
            var xs = new XmlSerializer(typeof(CountryStats));
            var sb = new StringBuilder();
            var sw = new StringWriter(sb);
            xs.Serialize(sw, stats);

            var newStats = (CountryStats) xs.Deserialize(
                new StringReader(sb.ToString()));

            Console.WriteLine(newStats.Capitals["France"]);
        }
    }
}
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

namespace SurrogateProperty
{
    public class CountryStats
    {
        [XmlIgnore]
        public Dictionary<string, string> Capitals { get; set; } = new Dictionary<string, string>();

        public (string, string)[] CapitalsSerializable
        {
            get
            {
                return Capitals.Keys.Select(country =>
                    (country, Capitals[country])).ToArray();
            }
            set
            {
                Capitals = value.ToDictionary(x => x.Item1, x => x.Item2);
            }
        }
    }
}
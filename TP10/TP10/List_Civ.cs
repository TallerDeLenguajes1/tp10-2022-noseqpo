using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace TP10
{
    public class List_Civ
    {
        [JsonPropertyName("civilizations")]
        public List<Civilization> Civilizations { get; set; }
    }
}

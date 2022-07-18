using System.Text.Json;
using System.Net;
using TP10;

var url = $"https://age-of-empires-2-api.herokuapp.com/api/v1/civilizations";
var request = (HttpWebRequest)WebRequest.Create(url);
request.Method = "GET";
request.ContentType = "application/json";
request.Accept = "application/json";
try
{
    using (WebResponse response = request.GetResponse())
    {
        using (Stream strReader = response.GetResponseStream())
        {
            if (strReader == null) return;
            using (StreamReader objReader = new StreamReader(strReader))
            {
                string responseBody = objReader.ReadToEnd();
                List_Civ ListCivilizaciones = JsonSerializer.Deserialize<List_Civ>(responseBody);
                foreach (Civilization civ in ListCivilizaciones.Civilizations)
                {
                    Console.WriteLine("id: " + civ.Id + " Nombre: " + civ.Name);
                }
                Random r = new Random();
                int randazo = r.Next(1, 33);
                Console.WriteLine("Estos son los datos de una civilizacion tomada al azar:");
                Console.WriteLine("id: " + ListCivilizaciones.Civilizations[randazo].Id);
                Console.WriteLine("Nombre: " + ListCivilizaciones.Civilizations[randazo].Name);
                Console.WriteLine("Tipo de ejercito: " + ListCivilizaciones.Civilizations[randazo].ArmyType);
                Console.WriteLine("Bonus de civilizacion: " + ListCivilizaciones.Civilizations[randazo].CivilizationBonus);
                Console.WriteLine("Expansion: " + ListCivilizaciones.Civilizations[randazo].Expansion);
                Console.WriteLine("Bonus de equipo:" + ListCivilizaciones.Civilizations[randazo].TeamBonus);
                Console.WriteLine("Tecnologia unica: " + ListCivilizaciones.Civilizations[randazo].UniqueTech);
                Console.WriteLine("Unidad unica: " + ListCivilizaciones.Civilizations[randazo].UniqueUnit);
            }
        }
    }
}
catch (WebException ex)
{
    Console.WriteLine("Problemas de acceso a la API");
}

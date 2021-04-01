using System.Collections.Generic;
using Newtonsoft.Json;
using System.Net.Http;
using BridgeMonitor.Models;

namespace BridgeMonitor.Models
{
    public class Boats : Boat
    {
        public List<Boat> _boatsInfo;

        public Boats()
        {
            _boatsInfo = new List<Boat>(GetBoatsFromApi());

        }
        private static List<Boat> GetBoatsFromApi()
        {
            //Création un HttpClient (= outil qui va permettre d'interroger une URl via une requête HTTP)
            using (var client = new HttpClient())
            {
                //Interrogation de l'URL censée me retourner les données
                var response = client.GetAsync("https://api.alexandredubois.com/pont-chaban/api.php");
                //Récupération du corps de la réponse HTTP sous forme de chaîne de caractères
                var stringResult = response.Result.Content.ReadAsStringAsync();
                //Conversion de mon flux JSON (string) en une collection d'objets BikeStation
                //d'un flux de données vers des objets => Déserialisation
                //d'objets vers un flux de données => Sérialisation
                var result = JsonConvert.DeserializeObject<List<Boat>>(stringResult.Result);
                return result;
            }
        }
    }
}

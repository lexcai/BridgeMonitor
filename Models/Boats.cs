using System.Collections.Generic;
using Newtonsoft.Json;
using System.Net.Http;
using BridgeMonitor.Models;
using System;

namespace BridgeMonitor.Models
{
    public class Boats
    {
        public List<Boat> _boatsInfo;

        [JsonProperty("next_closing")]
        public Boat _NextClosing { get; set; }


        public Boats()
        {
            _boatsInfo = new List<Boat>(GetBoatsFromApi());
            _NextClosing = FindNextClosing(_boatsInfo);

        }

        public static Boat FindNextClosing(List<Boat> _boatInfo)
        {
            DateTime actual = DateTime.Today;
            Boat nextOne = new Boat();

            nextOne._ClosingDate = new DateTime(9999, 1, 1);

            foreach(Boat item in _boatInfo)
            {
                if(actual < item._ClosingDate && nextOne._ClosingDate > item._ClosingDate)
                    nextOne = item;
            }
            return nextOne;
        }

        //       public static Boat FindEvent(List<Boat> _boatInfo)
        //       {
        //            Boat name = 
        //    }
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

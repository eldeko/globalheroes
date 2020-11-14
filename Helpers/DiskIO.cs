using GlobalHeroes.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;

namespace GlobalHeroes.Helpers
{
    public class DiskIO : IDiskIO
    {
        public  async Task Save(Character character)
        {
            try
            {
                using (StreamWriter file = File.CreateText("D:\\\\GlobalHeroes\\HeroesDB.json"))
                {
                    JsonSerializer serializer = new JsonSerializer();              

                    serializer.Serialize(file, character);
                }
            }
            catch (Exception)
            {
                throw;
            }           
        }

        public List<CharactersResponse> LoadCharactersResponse()
        {
            try
            {
                using StreamReader r = new StreamReader("D:\\\\GlobalHeroes\\HeroesDB.json");
                string json = r.ReadToEnd();
                List<CharactersResponse> items = JsonConvert.DeserializeObject<List<CharactersResponse>>(json);
                return items;
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}

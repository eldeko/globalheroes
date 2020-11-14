using GlobalHeroes.Entities;
using System.Collections.Generic;

namespace GlobalHeroes.Factories
{
    public static class CustomCharactersFactory
    {
        public static List<Character> GetCustomCharactersMock()
        {
            var returnList = new List<Character>();
            Character Spiderman = new Character() {id = 1, Name = "Spiderman", Description = "A guy who dresses as a spider and throws webs." };
            Character Superman  = new Character() {id = 2, Name = "Superman", Description = "A man who has superpowers because the sun of the planet he came from is older." };
            Character Batman    = new Character() {id = 3, Name = "Batman", Description = "A man who punishes criminals cause he cannot sleep." };
             
            returnList.Add(Spiderman); returnList.Add(Batman); returnList.Add(Superman);

            return returnList;
        }
    }
}

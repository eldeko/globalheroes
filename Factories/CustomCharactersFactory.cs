using GlobalHeroes.Entities;
using System.Collections.Generic;
using System.Linq;
namespace GlobalHeroes.Factories
{
    public static class CustomCharactersFactory
    {
        
        public static List<Character> GetCustomCharactersMock()
        {
           Character Spiderman = new Character() { id = 1, Name = "Spiderman", Description = "A guy who dresses as a spider and throws webs." };
           Character Superman = new Character() { id = 2, Name = "Superman", Description = "A man who has superpowers because the sun of the planet he came from is older." };
           Character Batman = new Character() { id = 3, Name = "Batman", Description = "A man who punishes criminals cause he cannot sleep." };

            var returnList = new List<Character>();
           
            returnList.Add(Spiderman); returnList.Add(Batman); returnList.Add(Superman);

            return returnList;
        }

        public static Character GetOneCharacter()
        {
            return GetCustomCharactersMock().FirstOrDefault();
        }
    }
}

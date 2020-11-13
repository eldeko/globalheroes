using GlobalHeroes.Entities;
using GlobalHeroes.Factories;
using System.Collections.Generic;
using System.Linq;

namespace GlobalHeroes.Persistance
{
    public class FakeDB : IFakeDB
    {
        private static List<Character> CustomCharacters;

        public FakeDB()
        {
            CustomCharacters = CustomCharactersFactory.GetCustomCharactersMock();
        }       

        public Character Get (int id)
        {
            return CustomCharacters.Where(x => x.id == id).FirstOrDefault();
        }

        public List<Character> GetAll()
        {
            return CustomCharacters;
        }

        public void AddCharacter (Character character)
        {
            CustomCharacters.Add(character);
        }

        public void DeleteCharacter(int id)
        {
            CustomCharacters.RemoveAll(x => x.id == id);
        }

        public void UpdateCharacter(Character character)
        {
            CustomCharacters.RemoveAll(x => x.id == character.id);
            CustomCharacters.Add(character);
        }
    }
}

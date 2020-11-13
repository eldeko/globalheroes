using GlobalHeroes.Entities;
using GlobalHeroes.Factories;
using GlobalHeroes.Persistance;
using System.Collections.Generic;
using System.Linq;

namespace GlobalHeroes.Repositories
{
    public class CustomCharactersRepository : ICustomCharactersRepository
    {
        private readonly IFakeDB _fakeDB;

        public CustomCharactersRepository(IFakeDB fakeDB)
        {
            _fakeDB = fakeDB;
        }
        public List<Character> GetAllCharacters()
        {
            return _fakeDB.GetAll();
        }

        public Character GetCharacterById(int id)
        {
            return _fakeDB.GetAll().Where(x => x.id == id).FirstOrDefault();
        }

        public Character GetCharacterByName()
        {
            throw new System.NotImplementedException();
        }

        public void AddCharacter(Character character)
        {
            _fakeDB.AddCharacter(character);
        }

        public void UpdateCharacter(Character character)
        {
            _fakeDB.UpdateCharacter(character);
        }

        public void DeleteCharacter(int id)
        {
            _fakeDB.DeleteCharacter(id);
        }
    }
}
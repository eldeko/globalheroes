using GlobalHeroes.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GlobalHeroes.Repositories
{
    public interface ICustomCharactersRepository
    {
        Character GetCharacterById( int id);
        Character GetCharacterByName();
        List<Character> GetAllCharacters();
        void AddCharacter(Character character);
        void UpdateCharacter(Character character);
        void DeleteCharacter(int id);

    }
}

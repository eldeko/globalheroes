using GlobalHeroes.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GlobalHeroes.Services.Contracts
{   
    public interface ICharactersService
    {
        List<Character> GetAllMarvelCharacters();
        List<Character> GetAllCustomCharacters();

        Character GetCustomCharacterById(int id);
        void AddCharacter(Character character);
        void UpadteCharacter(Character character);
        void DeleteCharacter(int id);
    }
}

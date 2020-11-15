using GlobalHeroes.Entities;
using GlobalHeroes.Extensions;
using GlobalHeroes.Helpers;
using GlobalHeroes.Repositories;
using GlobalHeroes.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GlobalHeroes.Services
{
    public class CharactersService : ICharactersService
    {
        private readonly IMarvelDataService _marvelDataService;
        private readonly ICustomCharactersRepository _customCharactersRepository;
        private readonly IDiskIO _diskIO;

        public CharactersService(IMarvelDataService marvelDataService, ICustomCharactersRepository customCharactersRepository, IDiskIO diskIO)
        {
            _marvelDataService = marvelDataService;
            _customCharactersRepository = customCharactersRepository;
            _diskIO = diskIO;
        }

        public void AddCharacter(Character character)
        {
            var lastId = _customCharactersRepository.GetAllCharacters().Max(x => x.id);

            if (character.id == 0 || character.id == null)
            {
                character.id = lastId + 1;
            }
            _customCharactersRepository.AddCharacter(character);
        }

        public void DeleteCharacter(int id)
        {            
            _customCharactersRepository.DeleteCharacter(id);
        }

        public List<Character> GetAllCustomCharacters()
        {
            return _customCharactersRepository.GetAllCharacters();
        }

        public List<Character> GetAllMarvelCharacters()
        {
            var response = _marvelDataService.GetAllCharactersResponse();

            return response.MapToCharacterList();
        }

        public Character GetCustomCharacterById(int id)
        {
            var res = _customCharactersRepository.GetCharacterById(id);
            return res;
        }

        public async Task SaveCharacterAsync(Character character)
        {
            await _diskIO.Save(character);
        }

        public void UpadteCharacter(Character character)
        {
            _customCharactersRepository.UpdateCharacter(character);
        }
    }
}

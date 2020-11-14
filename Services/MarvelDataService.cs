using GlobalHeroes.Entities;
using GlobalHeroes.Helpers;
using GlobalHeroes.Services.Contracts;
using System.Collections.Generic;

namespace GlobalHeroes.Services
{
    public class MarvelDataService : IMarvelDataService
    {
        private readonly IMarvelAPIHelper _marvelHelper;

        public MarvelDataService(IMarvelAPIHelper marvelHelper)
        {
            _marvelHelper = marvelHelper;
        }
        public List<CharactersResponse> GetAllCharactersResponse()
        {
            var res = _marvelHelper.GetAllCharacters();

            return res;
        }
    }
}

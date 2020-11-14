using GlobalHeroes.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GlobalHeroes.Services.Contracts
{
    public interface IMarvelDataService
    {
        List<CharactersResponse> GetAllCharactersResponse();
    }
}

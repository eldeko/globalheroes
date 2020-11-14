using GlobalHeroes.Entities;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GlobalHeroes.Helpers
{
    public interface IMarvelAPIHelper
    {
       List<CharactersResponse> GetAllCharacters();
    }
}

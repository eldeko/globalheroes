using GlobalHeroes.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GlobalHeroes.Helpers
{
    public interface IDiskIO
    {
        Task Save(Character character);
        List<CharactersResponse> LoadCharactersResponse();
    }
}
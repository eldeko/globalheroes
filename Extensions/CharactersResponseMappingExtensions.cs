using GlobalHeroes.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace GlobalHeroes.Extensions
{
    public static class CharactersResponseMappingExtensions
    {
        public static List<Character> MapToCharacterList(this List<CharactersResponse> charResponseList)
        {
            var charList = new List<Character>();
            foreach (var charResp in charResponseList)
            {
                foreach (var character in charResp.Data.Results)
                {
                    charList.Add(MapToCharacter(character));
                }
            }
            return charList;
        }

        private static Character MapToCharacter(Result character)
        {
            return new Character { Name = character.Name, Description = character.Description };
        }
    }
}

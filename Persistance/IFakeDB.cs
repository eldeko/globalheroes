using GlobalHeroes.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GlobalHeroes.Persistance
{
    public interface IFakeDB
    {
        Character Get(int id);
        List<Character> GetAll();
        void AddCharacter(Character character);
        void DeleteCharacter(int id);
        public void UpdateCharacter(Character character);
    }
}

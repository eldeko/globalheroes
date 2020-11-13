using GlobalHeroes.Entities;
using GlobalHeroes.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GlobalHeroes.Controllers
{
    [ApiController]
    [Route("[controller]")]    
    public class CustomCharactersController : ControllerBase
    {
        private readonly ICharactersService _charactersService;
        public CustomCharactersController(ICharactersService charactersService)
        {
            _charactersService = charactersService;
        }
        
        [HttpGet("/[controller]")]       
        public IActionResult Get()
        {
            return Ok(_charactersService.GetAllCustomCharacters());           
        }

        // GET api/<CharactersController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_charactersService.GetCustomCharacterById(id));
        }

        // POST api/<CharactersController>
        [HttpPost]
        public void Post([FromBody] Character character)
        {
            _charactersService.AddCharacter(character);
        }

        // PUT api/<CharactersController>/5
        [HttpPut("{id}")]
        public void Put([FromBody] Character character)
        {
            if(character.id !=0)
            _charactersService.UpadteCharacter(character);
        }

        // DELETE api/<CharactersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _charactersService.DeleteCharacter(id);
        }
    }
}

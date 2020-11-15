using GlobalHeroes.Entities;
using GlobalHeroes.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

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
            var res = _charactersService.GetCustomCharacterById(id);

            if (res != null)
            return Ok(res);

            return NoContent();
        }

        // POST api/<CharactersController>
        [HttpPost]
        public IActionResult Post([FromBody] Character character)
        {
           _charactersService.AddCharacter(character);
            return Created("Ok", character);
        }

        // PUT api/<CharactersController>/5
        [HttpPut("{id}")]
        public IActionResult Put([FromBody] Character character)
        {
            if(character.id !=0)
            _charactersService.UpadteCharacter(character);
            return Ok(character);
        }

        // DELETE api/<CharactersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _charactersService.DeleteCharacter(id);
        }
    }
}

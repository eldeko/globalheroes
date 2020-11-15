using GlobalHeroes.Entities;
using GlobalHeroes.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using System;

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

            return NotFound();
        }
       
        [HttpPost]
        public IActionResult Post([FromBody] Character character)
        {
            try
            {
                _charactersService.AddCharacter(character);
                return Created("Ok", character);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);           
            }
        }
      
        [HttpPut("{id}")]
        public IActionResult Put([FromBody] Character character)
        {
            if (character.id != 0)
                _charactersService.UpadteCharacter(character);
            return Ok(character);
        }
        
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var charac = _charactersService.GetCustomCharacterById(id);

            if (charac != null)
            {
                _charactersService.DeleteCharacter(id);
                return NoContent();
            }
            return NotFound();
        }
    }
}
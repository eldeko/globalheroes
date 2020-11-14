using GlobalHeroes.Entities;
using GlobalHeroes.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GlobalHeroes.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MarvelCharactersController : ControllerBase
    {
        private readonly ICharactersService _charactersService;
        public MarvelCharactersController(ICharactersService charactersService)
        {
            _charactersService = charactersService;
        }


        [HttpGet("/[controller]")]
        public IActionResult Get()
        {
            return Ok(_charactersService.GetAllMarvelCharacters());
        }
      

        // GET api/<CharactersController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CharactersController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<CharactersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CharactersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

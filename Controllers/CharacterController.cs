using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using dotnet_rpg.Models;
using dotnet_rpg.Services.CharacterService;

namespace dotnet_rpg.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CharacterController : ControllerBase
    {

        private readonly ICharacterService _characterService;

        public CharacterController(ICharacterService characterService)
        {
            _characterService = characterService;
        }

        // this is return action for the HTTP GET request
        [HttpGet]  // this is for Swagger
        [Route("GetAll")] // /Characters/GetAll
        public ActionResult<List<Character>> Get()
        {
            return Ok(_characterService.GetAllCharacters());
        }

        [HttpGet]
        [Route("{id}")] // this creates a parameter on the route  /Characters/{id}
        public ActionResult<Character> GetSingle(int id)
        {
            return Ok(_characterService.GetCharacterById(id));
        }

        [HttpPost] // uri /Characters POST
        public ActionResult<List<Character>> AddCharacter(Character newCharacter)
        {


            return Ok(_characterService.AddCharacter(newCharacter));
        }
    }
}
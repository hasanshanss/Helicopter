using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using Helicopter.Services.Abstraction;
using Helicopter.DAL.Entities;
using System.Threading.Tasks;
using Helicopter.API.Contracts.V1;
using static Helicopter.API.Extensions.HttpContextExtensions;
using Helicopter.API.Contracts.V1.Requests;
using AutoMapper;
using Helicopter.API.Attributes;
using System.IO;
using static Helicopter.API.Helpers.Helpers;
using Helicopter.API.Contracts.V1.Responses;
using System.Collections.Generic;

namespace Helicopter.API.Controllers.V1
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class GameController : ControllerBase
    {
        private readonly IGameService<Game, GameCategory> _gameService;
        private readonly IMapper _mapper;

        public GameController(IGameService<Game, GameCategory> gameService, 
                              IMapper mapper)
        {
            _gameService = gameService;
            _mapper = mapper;
        }

        [HttpGet]
        //[Cached(3600)]
        public  IActionResult Get() =>  new OkObjectResult(_gameService.GetGameList().ToArray());



        //[Cached(3600)]
        
        [HttpGet("query")]

        public async Task<IActionResult> Get(int id) => Ok(await _gameService.GetOneGameAsync(id));
        

        [HttpGet]
        //[Cached(3600)]
        [Route("Download")]
        public async Task<FileContentResult> DownloadAsTxt()
        {
            var Game = _mapper.Map<IEnumerable<DownloadGameResponse>>(_gameService.GetGameList());
            string data = string.Join("", Game);
            var (fileContent, fileName) = await SaveAsAsync(data);
            return File(fileContent, "application/octet-stream", fileName);
        }

        [HttpGet("Count")]
        public async Task<IActionResult> GetCount() => Ok(await _gameService.GetCountAsync());


        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] CreateGameRequest createGameRequest)
        {
            Game Game =  _mapper.Map<Game>(createGameRequest);
            await _gameService.AddGameAsync(Game);
            string locationUrl = Path.Combine(HttpContext.GetBaseUrl(), ApiRoutes.Game.Get.Replace("{gameId}", Game.Id.ToString()));
            return Created(locationUrl, Game);
        }

    }
}

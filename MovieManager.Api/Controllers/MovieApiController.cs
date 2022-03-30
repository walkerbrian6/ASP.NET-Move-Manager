using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using MovieManager.Services.ServicesContracts;
using MovieManager.Data.DataModels;

namespace MovieManager.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovieApiController : ControllerBase
    {
        private readonly IGetFromDbService getFromDbService;

        public MovieApiController(IGetFromDbService getFromDbService)
        {
            this.getFromDbService = getFromDbService;
        }

        /// <summary>
        /// Get user playlists
        /// </summary>
        /// <param name="userName">The user's username</param>
        /// <returns></returns>
        /// 


        [HttpPost]
        [Route("userPlaylists")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetPlaylists(string userName)
        {
            try
            {
                await getFromDbService.GetAllUserPlaylistsAsync(userName); //this needs to be async
            }
            catch (ArgumentException ae)
            {
                return BadRequest(ae.Message);
            }

            return Ok();
        }

        //get user stats

        //get movie stats

        /* - not async
        [HttpPost]
        [Route("userPlaylists")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public string? GetUserPlaylists(string userName)
        {
            var playlists = getFromDbService.GetAllUserPlaylists(userName);

            return playlists.ToString();
        }
        */
    }
}
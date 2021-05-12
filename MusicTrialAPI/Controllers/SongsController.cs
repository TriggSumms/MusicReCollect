using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MusicTrialAPI.Data;
using MusicTrialAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MusicTrialAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SongsController : ControllerBase
    {
        private ApiDbContext _dbContext;
        public SongsController(ApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        // GET: api/<SongsController>
        [HttpGet]
        //public IEnumerable<Song> Get()
        //{
        //    return _dbContext.Song;
        //}
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _dbContext.Song.ToListAsync());
            //return StatusCode(StatusCodes.Result)
        }



        // GET api/<SongsController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
           var song = await _dbContext.Song.FindAsync(id);
            return Ok(song);
        }



        // POST api/<SongsController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Song song)
        {
            await _dbContext.Song.AddAsync(song);
            await _dbContext.SaveChangesAsync();
            return StatusCode(StatusCodes.Status201Created);
        }

        // PUT api/<SongsController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Song songObj)
        {
            var song= await _dbContext.Song.FindAsync(id);
            if (song == null)
            {
                return NotFound("No record available");
            }
            else
            {
                song.Title = songObj.Title;
                song.Language = songObj.Language;
                await _dbContext.SaveChangesAsync();
                return Ok("Updated!");
            }
        }

        // DELETE api/<SongsController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
           var song = await _dbContext.Song.FindAsync(id);
            _dbContext.Song.Remove(song);
           await _dbContext.SaveChangesAsync();
            return Ok("Deleted");

        }
    }
}

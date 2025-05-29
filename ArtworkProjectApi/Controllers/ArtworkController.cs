using ArtworkProjectApi.DTOs;
using ArtworkProjectApi.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ArtworkProjectApi.Controllers
{
    [Authorize(Roles = "Admin")]
    [ApiController]
    [Route("store/[Controller]")]
    public class ArtworkController : ControllerBase
    {
        private readonly IArtworkService _artworkService;

        public ArtworkController(IArtworkService artworkService)
        {
            _artworkService = artworkService;
        }

        // GET: store/artwork
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ArtworkDto>>> GetAll()
        {
            var artworks = await _artworkService.GetAllAsync();
            return Ok(artworks);
        }

        // GET: store/artwork/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<ArtworkDto>> GetById(int id)
        {
            var artwork = await _artworkService.GetByIdAsync(id);
            if (artwork == null) return NotFound();
            return Ok(artwork);
        }

        // POST: store/artwork
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<ArtworkDto>> Create([FromBody] ArtworkDto dto)
        {
            var created = await _artworkService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        // PUT: api/artwork/{id}
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update(int id, [FromBody] ArtworkDto dto)
        {
            var success = await _artworkService.UpdateAsync(id, dto);
            if (!success) return NotFound();
            return NoContent();
        }

        // DELETE: store/artwork/{id}
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _artworkService.DeleteAsync(id);
            if (!success) return NotFound();
            return NoContent();
        }
    }
}
/* 
 HTTP Metoda	Endpoint	        Popis	                Role
GET	            /api/artwork	    Získání všech děl	    veřejné
GET	            /api/artwork/{id}	Získání díla dle ID	    veřejné
POST	        /api/artwork	    Vytvoření nového díla	pouze admin
PUT	            /api/artwork/{id}	Aktualizace díla	    pouze admin
DELETE	        /api/artwork/{id}	Smazání díla	        pouze admin
 */

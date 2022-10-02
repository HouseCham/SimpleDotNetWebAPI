using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using NetCoreApiMySQL.Data.Repositories;
using NetCoreApiMySQL.Model;

namespace NetCore6ApiMySQL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticulosController : ControllerBase
    {
        private readonly ArticuloRepository _articuloRepository;

        public ArticulosController(ArticuloRepository articuloRepository)
        {
            _articuloRepository = articuloRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllArticles()
        {
            return Ok(await _articuloRepository.GetAllArticles());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetArticleDetails(int id)
        {
            return Ok(await _articuloRepository.GetArticleById(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateArticle([FromBody] Artitulo articulo)    // [FromBody] = es para especificar que la info vendra en el cuerpo del post
        {
            if (articulo == null) return BadRequest();
            if (!ModelState.IsValid) return BadRequest();

            bool created = await _articuloRepository.InsertArticle(articulo);
            return Created("created", created);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateArticle([FromBody] Artitulo articulo)    // [FromBody] = es para especificar que la info vendra en el cuerpo del post
        {
            if (articulo == null) return BadRequest();
            if (!ModelState.IsValid) return BadRequest();

            await _articuloRepository.UpdateArticle(articulo);
            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteArticle(int id)
        {
            await _articuloRepository.DeleteArticle(new Artitulo { Id = id });
            return NoContent();
        }
    }
}

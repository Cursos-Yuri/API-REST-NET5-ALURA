using alura_api_filmes.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace alura_api_filmes.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmeController : ControllerBase
    {
        private static List<Filme> filmes = new List<Filme>();

        public FilmeController()
        {

        }

        [HttpPost]
        public IActionResult CreateFilme([FromBody] Filme filme) 
        {
            try
            {
                filmes.Add(filme);

                return CreatedAtAction(nameof(GetFilmePerId), new { Id = filme.Id }, filme);
            }
            catch(Exception ex)
            {
                return BadRequest(new { ex.Message });
            }
        }

        [HttpGet]
        public IActionResult GetFilmes() 
        {
            try
            {
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { ex.Message });
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetFilmePerId(int id)
        {
            try
            {
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { ex.Message });
            }
        }
    }
}

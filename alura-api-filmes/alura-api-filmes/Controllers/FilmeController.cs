using alura_api_filmes.Data;
using alura_api_filmes.Data.DTOs;
using alura_api_filmes.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace alura_api_filmes.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmeController : ControllerBase
    {
        private FilmeContext _context;
        private IMapper _mapper;
        public FilmeController(FilmeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult CreateFilme([FromBody] CreateFilmeDTO filmedto)
        {
            try
            {
                Filme filme = _mapper.Map<Filme>(filmedto);

                _context.Filme.Add(filme);
                _context.SaveChanges();

                return CreatedAtAction(nameof(GetFilmePerId), new { Id = filme.Id }, filme);
            }
            catch (Exception ex)
            {
                return BadRequest(new { ex.Message });
            }
        }

        [HttpGet]
        public IEnumerable<Filme> GetFilmes()
        {
            try
            {
                return _context.Filme;
            }
            catch (Exception)
            {
                return null;
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetFilmePerId(int id)
        {
            try
            {
                Filme filme = _context.Filme.FirstOrDefault(x => x.Id == id);

                ReadFilmeDTO filmeDto = _mapper.Map<ReadFilmeDTO>(filme);

                return Ok(filme);
            }
            catch (Exception ex)
            {
                return BadRequest(new { ex.Message });
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateFilme(int id, [FromBody] UpdateFilmeDTO filmeDTO)
        {
            Filme filme = _context.Filme.FirstOrDefault(x => x.Id == id);

            if (filme.Equals(null)) return NotFound();

            _mapper.Map(filmeDTO, filme);

            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteFilme(int id)
        {
            Filme filme = _context.Filme.FirstOrDefault(x => x.Id == id);

            if (filme.Equals(null)) return NotFound();

            _context.Remove(filme);
            _context.SaveChanges();

            return NoContent();
        }

    }
}

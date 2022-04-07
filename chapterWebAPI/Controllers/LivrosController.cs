using chapterWebAPI.Models;
using chapterWebAPI.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace chapterWebAPI.Controllers
{
    [Produces("application/json")]

    [Route("api/[controller]")]

    [ApiController]

    [Authorize]
    public class LivrosController : ControllerBase
    {
        private readonly LivroRepository _livroRepository;
        public LivrosController(LivroRepository livroRepository)
        {
            _livroRepository = livroRepository;
        }
        [HttpGet]
        public IActionResult Listar()
        {
            try
            {
                return Ok(_livroRepository.Listar());
            }
            catch (System.Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        //HttpGetAtribute /api/livros/1
        [HttpGet("{Id}")]
        public IActionResult BuscarPorId(int Id)
        {
            try
            {
                Livro LivroProcurado = _livroRepository.BuscarPorId(Id);

                if (LivroProcurado == null)
                {
                    return NotFound();
                }
                return Ok(LivroProcurado);

            }
            catch (System.Exception e)
            {

                throw new Exception(e.Message);
            }

        }
        [HttpPost]
        public IActionResult Cadastrar(Livro Livro)
        {
            try
            {
                _livroRepository.Cadastrar(Livro);

                return StatusCode(201);
            }
            catch (System.Exception e)
            {

                throw new Exception(e.Message);
            }

        }


        [HttpPut("{Id}")]

        public IActionResult Atualizar(int id, Livro Livro)
        {
            try
            {
                _livroRepository.Atualizar(id, Livro);

                return StatusCode(204);
            }
            catch (System.Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        [HttpDelete("{id}")]

        public IActionResult Deletar(int id)
        {
            try
            {
                _livroRepository.Deletar(id);

                return StatusCode(204);
            }
            catch (System.Exception e)
            {

                throw new Exception(e.Message);
            }
        }
    }
}
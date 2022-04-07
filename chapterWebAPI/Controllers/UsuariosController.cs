using chapterWebAPI.Models;
using chapterWebAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace chapterWebAPI.Controllers
{
    [Produces("application/json")]

    [Route("api/[controller]")]

    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly UsuarioRepository _UsuarioRepository;

        public UsuariosController(UsuarioRepository usuarioRepository)
        {
            _UsuarioRepository = usuarioRepository;
        }

        [HttpGet]
        public IActionResult Listar()
        {
            try
            {
                return Ok(_UsuarioRepository.Listar());
            }
            catch (System.Exception e)
            { 
                throw new Exception(e.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            try
            {
                Usuarios usuarioProcurado = _UsuarioRepository.BuscarPorId(id);

                if (usuarioProcurado == null)
                {
                    return NotFound();
                }
                return Ok(usuarioProcurado);
                
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [HttpPost]
        public IActionResult Cadastrar(Usuarios u)
        {
            try
            {
                _UsuarioRepository.Cadastrar(u);

                return StatusCode(201);
             
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [HttpPut]
        public IActionResult Atualizar(int id, Usuarios usuarios)
        {
            try
            {
             _UsuarioRepository.Atualizar(id, usuarios);

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
                _UsuarioRepository.Deletar(id);

                return StatusCode(204);

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }


    }
}

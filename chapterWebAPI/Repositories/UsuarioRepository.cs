using chapterWebAPI.Contexts;
using chapterWebAPI.Models;
using System.Collections.Generic;
using System.Linq;

namespace chapterWebAPI.Repositories
{
    public class UsuarioRepository
    {
        private readonly ChapterContext _context;

        public UsuarioRepository(ChapterContext context)
        {
            _context = context;
        }

        public List<Usuarios> Listar()
        {
            return _context.Usuarios.ToList();
        }

        public void Cadastrar(Usuarios u)
        {
            _context.Usuarios.Add(u);
            _context.SaveChanges();
        }
        
        public Usuarios BuscarPorId(int id)
        {
            return _context.Usuarios.Find(id);
        }

        public void Atualizar(int id, Usuarios U)
        {
            Usuarios UsuarioBuscado = _context.Usuarios.Find(id);
            if (UsuarioBuscado != null)
            {
                UsuarioBuscado.Email = U.Email;
                UsuarioBuscado.Senha = U.Senha;
                UsuarioBuscado.Tipo = U.Tipo;
            }

            _context.Usuarios.Update(UsuarioBuscado);

            _context.SaveChanges();
        }
        public void Deletar(int id)
        {
            Usuarios UsuarioBuscado = _context.Usuarios.Find(id);

            _context.Usuarios.Remove(UsuarioBuscado);

            _context.SaveChanges();
        }


        public Usuarios Login(string email, string senha)
        {
            return _context.Usuarios.FirstOrDefault(u => u.Email == email && u.Senha == senha);
        }

    }
}

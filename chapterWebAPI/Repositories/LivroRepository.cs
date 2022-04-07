
using chapterWebAPI.Contexts;
using chapterWebAPI.Models;
using System.Collections.Generic;
using System.Linq;
namespace chapterWebAPI.Repositories
{
    public class LivroRepository
    {
        // possui acesso aos dados
        private readonly ChapterContext _context;
        public LivroRepository(ChapterContext context)
        {
            _context = context;
        }
        public List<Livro> Listar()
        {

            return _context.Livros.ToList();
        }


        public Livro BuscarPorId(int id)
        {
            return _context.Livros.Find(id);
        }

        public void Cadastrar(Livro livro) 
        {
            _context.Livros.Add(livro);

            _context.SaveChanges();
        }

        public void Atualizar(int id, Livro Livro)
        {
            Livro LivroBuscado = _context.Livros.Find(id);
            if (LivroBuscado != null)
            {
                LivroBuscado.Titulo = Livro.Titulo;
                LivroBuscado.QuantidadePaginas = Livro.QuantidadePaginas;
                LivroBuscado.Disponivel = Livro.Disponivel;
            }

            _context.Livros.Update(LivroBuscado);

            _context.SaveChanges();
        }

        public void Deletar(int id)
        {
            Livro LivroBuscado = _context.Livros.Find(id);

            _context.Livros.Remove(LivroBuscado);

            _context.SaveChanges();
        }
    }
}

using chapterWebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace chapterWebAPI
{
    public class ChapterContext : DbContext
    {
        public ChapterContext()
        {
        }
        public ChapterContext(DbContextOptions <ChapterContext> options) : base(options)
        {
        }
        protected override void
        OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source = FEHENR\\SQLEXPRESS; trusted_connection=true;");
            }
        }
        public DbSet<Livro> Livros { get; set; }

        public DbSet<Usuarios> Usuarios { get; set; }
    }
}
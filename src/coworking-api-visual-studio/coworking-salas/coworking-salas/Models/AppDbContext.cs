using Microsoft.EntityFrameworkCore;

namespace coworking_salas.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        { 

        }
        //o On ModelCreating faz com que quando cria um modelo tem como de modo programático configurar as relações
        protected override void OnModelCreating(ModelBuilder builder)
        {
            //Entity é a entidade que quer configurar que no caso é a SalaUsuarios
            builder.Entity<SalaUsuarios>()
                //o que será feito nessa configuração: colocar uma chave - HasKey
                //essa chave vai ter uma chave composta (que possui mais de um campo)
                ////ela vai criar New SalaId e UsuarioId
                //o que significa que não pode ter uma mesma sala associada ao mesmo usuário
                .HasKey(c => new { c.SalaId, c.UsuarioId });
            //tem que criar as foreign keys
            builder.Entity<SalaUsuarios>()
                //fazer os relacionamentos
                //relacionado a uma sala
                //para cada sala pode ter muito usuários
                .HasOne(c => c.Sala).WithMany(c => c.Usuarios)
                //essa relação é definida pela Foreign key
                .HasForeignKey(c => c.SalaId);
            //então repete a relação
            builder.Entity<SalaUsuarios>()
               .HasOne(c => c.Usuario).WithMany(c => c.Salas)
               .HasForeignKey(c => c.UsuarioId);

        }
        //tabela chamada salas baseada na classe sala
        public DbSet<Sala> Salas { get; set; }
        public DbSet<Uso> Usos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<SalaUsuarios> SalasUsuarios { get; set; }

        //public object Salas { get; internal set; }

        //não sei se deveria ter adicionado esse
        //public object Usos { get; internal set; }
    }
    
}

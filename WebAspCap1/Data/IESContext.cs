using Microsoft.EntityFrameworkCore;
using Modelo.Cadastros;
using Modelo.Discente;
using Modelo.Docente;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using WebAspCap1.Models.Infra;


namespace WebAspCap1.Data
{
    public class IESContext : IdentityDbContext<UsuarioDaAplicacao>
    {
        public DbSet<Departamento> Departamentos { get; set; }
        public DbSet<Instituicao> Instituicoes { get; set; }
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Disciplina> Disciplinas { get; set; }
        public DbSet<Academico> Academicos { get; set; }
        public DbSet<Professor> Professores { get; set; }
        public IESContext(DbContextOptions<IESContext> options) : base(options) 
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<CursoDisciplina>()
                .HasKey(cd => new { cd.CursoID, cd.DisciplinaID });

            modelBuilder.Entity<CursoDisciplina>()
                .HasOne(c => c.Curso)
                .WithMany(cd => cd.CursoDisciplinas)
                .HasForeignKey(c => c.CursoID);

            modelBuilder.Entity<CursoDisciplina>()
                .HasOne(d => d.Disciplina)
                .WithMany(cd => cd.CursoDisciplinas)
                .HasForeignKey(d => d.DisciplinaID);

            modelBuilder.Entity<CursoProfessor>()
                .HasKey(cd => new { cd.CursoID, cd.ProfessorID });

            modelBuilder.Entity<CursoProfessor>()
                .HasOne(c => c.Curso)
                .WithMany(cd => cd.CursosProfessores)
                .HasForeignKey(c => c.CursoID);

            modelBuilder.Entity<CursoProfessor>()
                .HasOne(d => d.Professor)
                .WithMany(cd => cd.CursosProfessores)
                .HasForeignKey(d => d.ProfessorID);

            modelBuilder.Entity<Curso>()
                .HasData(
                    new Curso
                    {
                        CursoID = 1,
                        Nome = "Leituras Práticas"
                    },
                    new Curso
                    {
                        CursoID = 2,
                        Nome = "Meditações"
                    }
                );

            modelBuilder.Entity<Professor>()
                .HasData(
                    new Professor
                    {
                        ProfessorID = 1,
                        Nome = "Carlos Pedrinho",
                        CursoID = 1
                    },
                    new Professor
                    {
                        ProfessorID = 2,
                        Nome = "João Silva",
                        CursoID = 2
                    }
                );
        }

    }
}

using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Modelo.Cadastros;
using Modelo.Docente;

namespace WebAspCap1.Data
{
    public class IESDbInitializer
    {
        public static void Initialize(IESContext context)
        {
          //  context.Database.EnsureDeleted();
           // context.Database.EnsureCreated();

         /*   if (context.Departamentos.Any())
            {
                return;
            }

            var instituicoes = new Instituicao[]
            {
                new Instituicao { Nome="UniAcre", Endereco="Acre"},
                new Instituicao { Nome="UniParana", Endereco="Paraná"}
            };

            foreach (Instituicao i in instituicoes)
            {
                context.Instituicoes.Add(i);
            }
            context.SaveChanges();

            var departamentos = new Departamento[]
            {
                new Departamento { Nome="Ciência da Computação", InstituicaoID=1},
                new Departamento { Nome="Ciência de Alimentos", InstituicaoID=2}
            };

            foreach (Departamento d in departamentos)
            {
                context.Departamentos.Add(d);
            }
            context.SaveChanges();
         */

            if (context.Cursos.Any())
            {
                return;
            }

            var cursos = new Curso[]
            {
                new Curso {Nome="Teste", CursoID=1 }
            };

            foreach (Curso c in cursos)
            {
                context.Cursos.Add(c);
            }
            context.SaveChanges();
        }

        
    }
}

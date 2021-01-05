using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Modelo.Docente;
using Modelo.Cadastros;
using Microsoft.EntityFrameworkCore;

namespace WebAspCap1.Data.DAL.Docente
{
    public class ProfessorDAL
    {
        private IESContext _context;

        public ProfessorDAL(IESContext context)
        {
            _context = context;
        }

        public IQueryable<Professor> ObterProfessoresClassificadosPorNome()
        {
            return _context.Professores.Include(c => c.Curso).OrderBy(b => b.Nome);
        }

        public async Task<Professor> ObterProfessoresPorId(long id)
        {
            var professor = await _context.Professores.SingleOrDefaultAsync(m => m.ProfessorID == id);
            _context.Cursos.Where(i => professor.CursoID == i.CursoID).Load();
            return professor;
        }

        public async Task<Professor> GravarProfessor(Professor professor)
        {
            if (professor.ProfessorID == null)
            {
                _context.Professores.Add(professor);
            }
            else
            {
                _context.Update(professor);
            }
            await _context.SaveChangesAsync();
            return professor;
        }

        public async Task<Professor> EliminarProfessorPorId(long id)
        {
            Professor professor = await ObterProfessoresPorId(id);
            _context.Professores.Remove(professor);
            await _context.SaveChangesAsync();
            return professor;
        }
    }
}

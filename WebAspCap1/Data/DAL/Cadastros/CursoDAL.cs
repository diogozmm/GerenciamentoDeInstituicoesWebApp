using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Modelo.Cadastros;
using Modelo.Docente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAspCap1.Data.DAL.Cadastros
{
    public class CursoDAL
    {
        private IESContext _context;

        public CursoDAL(IESContext context)
        {
            _context = context;
        }

        public IQueryable<Curso> ObterCursosClassificadosPorNome()
        {
            return _context.Cursos.Include(d => d.Departamento).OrderBy(b => b.Nome);
        }

       public async Task<Curso> ObterCursosPorId(long id)
        {
            var curso = await _context.Cursos.SingleOrDefaultAsync(m => m.CursoID == id);
            _context.Departamentos.Where(i => curso.DepartamentoID == i.DepartamentoID).Load();
            return curso;
        }

        public async Task<Curso> GravarCurso(Curso curso)
        {
            if (curso.CursoID == null)
            {
                _context.Cursos.Add(curso);
            }
            else
            {
                _context.Update(curso);
            }
            await _context.SaveChangesAsync();
            return curso;
        }

        public async Task<Curso> EliminarCursoPorId(long id)
        {
            Curso curso = await ObterCursosPorId(id);
            _context.Cursos.Remove(curso);
            await _context.SaveChangesAsync();
            return curso;
        }

        public void RegistrarProfessor(long cursoID, long professorID)
        {
            var curso = _context.Cursos.Where(c => c.CursoID == cursoID).Include(cp => cp.CursosProfessores).First();
            var professor = _context.Professores.Find(professorID);
            curso.CursosProfessores.Add(new CursoProfessor() { Curso = curso, Professor = professor });
            _context.SaveChanges();
        }

        public IQueryable<Curso> ObterCursosPorDepartamento(long departamentoID)
        {
            var cursos = _context.Cursos.Where(c => c.DepartamentoID == departamentoID).OrderBy(d => d.Nome);
            return cursos;
        }

        public IQueryable<Professor> ObterProfessoresForaDoCurso(long cursoID)
        {
            var curso = _context.Cursos.Where(c => c.CursoID == cursoID).Include(cp => cp.CursosProfessores).First();
            var professoresDoCurso = curso.CursosProfessores.Select(cp => cp.ProfessorID).ToArray();
            var professoresForaDoCurso = _context.Professores.Where(p => !professoresDoCurso.Contains(p.ProfessorID));
            return professoresForaDoCurso;
        }
    }
}

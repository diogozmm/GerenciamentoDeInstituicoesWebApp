using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAspCap1.Data;
using WebAspCap1.Data.DAL.Cadastros;
using WebAspCap1.Data.DAL.Docente;
using Modelo.Cadastros;
using Microsoft.CodeAnalysis.Emit;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebAspCap1.Areas.Cadastros.Controllers
{
    [Area("Cadastros")]
    public class CursoController : Controller
    {
        private readonly IESContext _context;
        private readonly InstituicaoDAL instituicaoDAL;
        private readonly DepartamentoDAL departamentoDAL;
        private readonly CursoDAL cursoDAL;
        private readonly ProfessorDAL professorDAL;

        public CursoController(IESContext context)
        {
            _context = context;
            instituicaoDAL = new InstituicaoDAL(context);
            departamentoDAL = new DepartamentoDAL(context);
            cursoDAL = new CursoDAL(context);
            professorDAL = new ProfessorDAL(context);
        }

        private async Task<IActionResult> ObterVisaoCursoPorId(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var curso = await cursoDAL.ObterCursosPorId((long)id);
            if (curso == null)
            {
                return NotFound();
            }

            return View(curso);
        }

        public async Task<IActionResult> Index()
        {
            return View(await cursoDAL.ObterCursosClassificadosPorNome().ToListAsync());
        }

        public IActionResult Create()
        {
            var departamentos = departamentoDAL.ObterDepartamentosClassificadosPorNome().ToList();
            departamentos.Insert(0, new Departamento() { DepartamentoID = 0, Nome = "Selecione o departamento" });
            ViewBag.Departamentos = departamentos;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind("Nome, DepartamentoID")] Curso curso)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await cursoDAL.GravarCurso(curso);
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (DbUpdateException)
            {
                ModelState.AddModelError("", "Não foi possível inserir os dados.");
            }
            return View(curso);
        }
        
        public async Task<IActionResult> Edit(long? id)
        {
            ViewResult visaoCurso = (ViewResult)await ObterVisaoCursoPorId(id);
            Curso cursos = (Curso)visaoCurso.Model;
            ViewBag.Departamentos = new SelectList(departamentoDAL.ObterDepartamentosClassificadosPorNome(), "DepartamentoID", "Nome", cursos.DepartamentoID);
            return visaoCurso;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long? id, [Bind("CursoID, Nome, DepartamentoID")] Curso curso)
        {
            if (id != curso.CursoID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await cursoDAL.GravarCurso(curso);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await CursoExists(curso.CursoID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Departamentos = new SelectList(departamentoDAL.ObterDepartamentosClassificadosPorNome(), "DepartamentoID", "Nome", curso.DepartamentoID);
            return View(curso);
        }

        private async Task<bool> CursoExists(long? id)
        {
            return await cursoDAL.ObterCursosPorId((long)id) != null;
        }

        

        public async Task<IActionResult> Details(long? id)
        {
            return await ObterVisaoCursoPorId(id);
        }

        public async Task<IActionResult> Delete(long? id)
        {
            return await ObterVisaoCursoPorId(id);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long? id)
        {
            var curso = await cursoDAL.EliminarCursoPorId((long)id);
            TempData["Message"] = "Curso " + curso.Nome.ToUpper() + " foi removido com sucesso!";
            return RedirectToAction(nameof(Index));
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Modelo.Cadastros;
using Modelo.Docente;
using Newtonsoft.Json;
using WebAspCap1.Areas.Docente.Models;
using WebAspCap1.Data;
using WebAspCap1.Data.DAL.Cadastros;
using WebAspCap1.Data.DAL.Docente;

namespace WebAspCap1.Areas.Docente.Controllers
{
    [Area("Docente")]
    public class ProfessorController : Controller
    {
        private readonly IESContext _context;
        private readonly InstituicaoDAL instituicaoDAL;
        private readonly DepartamentoDAL departamentoDAL;
        private readonly CursoDAL cursoDAL;
        private readonly ProfessorDAL professorDAL;

        public ProfessorController(IESContext context)
        {
            _context = context;
            instituicaoDAL = new InstituicaoDAL(context);
            departamentoDAL = new DepartamentoDAL(context);
            cursoDAL = new CursoDAL(context);
            professorDAL = new ProfessorDAL(context);
        }

        private async Task<IActionResult> ObterVisaoProfessorPorId(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var professor = await professorDAL.ObterProfessoresPorId((long)id);
            if (professor == null)
            {
                return NotFound();
            }

            return View(professor);
        }

        public async Task<IActionResult> Index()
        {
            return View(await professorDAL.ObterProfessoresClassificadosPorNome().ToListAsync());
        }

        public IActionResult Create()
        {
            var cursos = cursoDAL.ObterCursosClassificadosPorNome().ToList();
            cursos.Insert(0, new Curso() { CursoID = 0, Nome = "Selecione o curso" });
            ViewBag.Cursos = cursos;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind("Nome, CursoID")] Professor professor)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await professorDAL.GravarProfessor(professor);
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (DbUpdateException)
            {
                ModelState.AddModelError("", "Não foi possível inserir os dados.");
            }
            return View(professor);
        }

        public async Task<IActionResult> Edit(long? id)
        {
            ViewResult visaoProfessor = (ViewResult)await ObterVisaoProfessorPorId(id);
            Professor professores = (Professor)visaoProfessor.Model;
            ViewBag.Cursos = new SelectList(cursoDAL.ObterCursosClassificadosPorNome(), "CursoID", "Nome", professores.CursoID);
            return visaoProfessor;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long? id, [Bind("ProfessorID, Nome, CursoID")] Professor professor)
        {
            if (id != professor.ProfessorID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await professorDAL.GravarProfessor(professor);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await ProfessorExists(professor.ProfessorID))
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
            ViewBag.Cursos = new SelectList(cursoDAL.ObterCursosClassificadosPorNome(), "CursoID", "Nome", professor.CursoID);
            return View(professor);
        }

        private async Task<bool> ProfessorExists(long? id)
        {
            return await professorDAL.ObterProfessoresPorId((long)id) != null;
        }



        public async Task<IActionResult> Details(long? id)
        {
            return await ObterVisaoProfessorPorId(id);
        }

        public async Task<IActionResult> Delete(long? id)
        {
            return await ObterVisaoProfessorPorId(id);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long? id)
        {
            var professor = await professorDAL.EliminarProfessorPorId((long)id);
            TempData["Message"] = "Professor " + professor.Nome.ToUpper() + " foi removido com sucesso!";
            return RedirectToAction(nameof(Index));
        }

        public void PrepararViewBags(List<Instituicao> instituicoes, List<Departamento> departamentos, List<Curso> cursos, List<Professor> professores)
        {
            instituicoes.Insert(0, new Instituicao() { InstituicaoID = 0, Nome = "Selecione a instituição" });
            ViewBag.Instituicoes = instituicoes;

            departamentos.Insert(0, new Departamento() { DepartamentoID = 0, Nome = "Selecione o departamento" });
            ViewBag.Departamentos = departamentos;

            cursos.Insert(0, new Curso() { CursoID = 0, Nome = "Selecione o curso" });
            ViewBag.Cursos = cursos;

            professores.Insert(0, new Professor() { ProfessorID = 0, Nome = "Selecione o professor" });
            ViewBag.Professores = professores;
        }

        [HttpGet]
        public IActionResult AdicionarProfessor()
        {
            PrepararViewBags(instituicaoDAL.ObterInstituicoesClassificadasPorNome().ToList(),
                new List<Departamento>().ToList(), new List<Curso>().ToList(), new List<Professor>().ToList());
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AdicionarProfessor([Bind("InstituicaoID, DepartamentoID, CursoID, ProfessorID")] AdicionarProfessorViewModel model)
        {
            if (model.InstituicaoID == 0 || model.DepartamentoID == 0 || model.CursoID == 0 || model.ProfessorID == 0)
            {
                ModelState.AddModelError("", "É preciso selecionar todos os dados");
            } else
            {
                cursoDAL.RegistrarProfessor((long)model.CursoID, (long)model.ProfessorID);
                RegistrarProfessorNaSessao((long)model.CursoID, (long)model.ProfessorID);

                PrepararViewBags(instituicaoDAL.ObterInstituicoesClassificadasPorNome().ToList(),
                    departamentoDAL.ObterDepartamentosPorInstituicao((long)model.InstituicaoID).ToList(),
                    cursoDAL.ObterCursosPorDepartamento((long)model.DepartamentoID).ToList(),
                    cursoDAL.ObterProfessoresForaDoCurso((long)model.CursoID).ToList());
            }
            return View(model);
        }

        public JsonResult ObterDepartamentosPorInstituicao(long actionID)
        {
            var departamentos = departamentoDAL.ObterDepartamentosPorInstituicao(actionID).ToList();
            return Json(new SelectList(departamentos, "DepartamentoID", "Nome"));
        }

        public JsonResult ObterCursosPorDepartamento(long actionID)
        {
            var cursos = cursoDAL.ObterCursosPorDepartamento(actionID).ToList();
            return Json(new SelectList(cursos, "CursoID", "Nome"));
        }

        public JsonResult ObterProfessoresForaDoCurso(long actionID)
        {
            var professores = cursoDAL.ObterProfessoresForaDoCurso(actionID).ToList();
            return Json(new SelectList(professores, "ProfessorID", "Nome"));
        }

        public void RegistrarProfessorNaSessao(long cursoID, long professorID)
        {
            var cursoProfessor = new CursoProfessor() { ProfessorID = professorID, CursoID = cursoID };
            List<CursoProfessor> cursosProfessor = new List<CursoProfessor>();
            string cursosProfessoresSession = HttpContext.Session.GetString("cursosProfessores");
            if (cursosProfessoresSession != null)
            {
                cursosProfessor = JsonConvert.DeserializeObject<List<CursoProfessor>>(cursosProfessoresSession);
            }
            cursosProfessor.Add(cursoProfessor);
            HttpContext.Session.SetString("cursosProfessores", JsonConvert.SerializeObject(cursosProfessor));
        }

        public IActionResult VerificarUltimosRegistros()
        {
            List<CursoProfessor> cursosProfessor = new List<CursoProfessor>();
            string cursosProfessoresSession = HttpContext.Session.GetString("cursosProfessores");
            if (cursosProfessoresSession != null)
            {
                cursosProfessor = JsonConvert.DeserializeObject<List<CursoProfessor>>(cursosProfessoresSession);
            }
            return View(cursosProfessor);
        }
    }
}

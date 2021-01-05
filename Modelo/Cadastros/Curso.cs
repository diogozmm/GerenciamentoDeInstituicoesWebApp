using Modelo.Docente;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Modelo.Cadastros
{
    public class Curso
    {
        [DisplayName("Id")]
        public long? CursoID { get; set; }
        [Required]
        public string Nome { get; set; }

        public long? DepartamentoID { get; set; }
        public Departamento Departamento { get; set; }

        public virtual ICollection<CursoDisciplina> CursoDisciplinas { get; set; }
        public virtual ICollection<CursoProfessor> CursosProfessores { get; set; }
        public virtual ICollection<Professor> Professores { get; set; }
    }
}

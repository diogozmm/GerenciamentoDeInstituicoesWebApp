using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace Modelo.Cadastros
{
    public class Departamento
    {
        [DisplayName("Id")]
        public long? DepartamentoID { get; set; }
        
        [DisplayName("Departamento")]
        [Required]
        public string Nome { get; set; }

        public long? InstituicaoID { get; set; }
        public Instituicao Instituicao { get; set; }

        public virtual ICollection<Curso> Cursos { get; set; }
    }
}

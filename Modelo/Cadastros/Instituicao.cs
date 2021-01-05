using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Modelo.Cadastros
{
    public class Instituicao
    {
        [DisplayName("Id")]
        public long? InstituicaoID { get; set; }
        
        [DisplayName("Instituição")]
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Endereco { get; set; }

        public virtual ICollection<Departamento> Departamentos { get; set; }
    }
}

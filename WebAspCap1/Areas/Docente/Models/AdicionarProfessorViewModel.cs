﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAspCap1.Areas.Docente.Models
{
    public class AdicionarProfessorViewModel
    {
        public long? InstituicaoID { get; set; }
        public long? DepartamentoID { get; set; }
        public long? CursoID { get; set; }
        public long? ProfessorID { get; set; }
    }
}

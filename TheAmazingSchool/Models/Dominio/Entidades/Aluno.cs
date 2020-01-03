using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheAmazingSchool.Models.Dominio.Enum;

namespace TheAmazingSchool.Models.Dominio.Entidades
{
    public class Aluno : EntityBase
    {
        public string Nome { get; set; }
        public string Matricula { get; set; }
        public double PrimeiraNota { get; set; }
        public double SegundaNota { get; set; }
        public double TerceiraNota { get; set; }
        public double MediaPonderada { get; set; }
        public EnumAluno Status { get; set; }


    }
}

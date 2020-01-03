using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheAmazingSchool.Models.Dominio.Enum;

namespace TheAmazingSchool.Models.Dominio.Entidades
{
    public class Turma : EntityBase
    {
        public EnumTurma NumeroDaTurma { get; set; }
        public ICollection<Aluno> ListaDeAlunos { get; } = new List<Aluno>();
    }
}

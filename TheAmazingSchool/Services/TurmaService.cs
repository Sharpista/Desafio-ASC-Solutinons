using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheAmazingSchool.Models;
using TheAmazingSchool.Models.Dominio.Entidades;

namespace TheAmazingSchool.Services
{
    public class TurmaService
    {
        private readonly TheAmazingSchoolContext _context;

        public TurmaService(TheAmazingSchoolContext context) {

            _context = context;
        }

        public List<Aluno> GetAlunos() {
            return _context.Aluno.ToList();
        }
    }
}

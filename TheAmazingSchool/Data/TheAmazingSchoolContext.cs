using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TheAmazingSchool.Models.Dominio.Entidades;

namespace TheAmazingSchool.Models
{
    public class TheAmazingSchoolContext : DbContext
    {
        public TheAmazingSchoolContext (DbContextOptions<TheAmazingSchoolContext> options)
            : base(options)
        {
        }

        public DbSet<TheAmazingSchool.Models.Dominio.Entidades.Aluno> Aluno { get; set; }

        public DbSet<TheAmazingSchool.Models.Dominio.Entidades.Turma> Turma { get; set; }
    }
}

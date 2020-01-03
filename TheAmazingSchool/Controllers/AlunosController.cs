using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TheAmazingSchool.Models;
using TheAmazingSchool.Models.Dominio.Entidades;
using TheAmazingSchool.Models.Dominio.Enum;

namespace TheAmazingSchool.Controllers
{
    public class AlunosController : Controller
    {
        private readonly TheAmazingSchoolContext _context;

        public AlunosController(TheAmazingSchoolContext context)
        {
            _context = context;
        }

        // GET: Alunos
        public async Task<IActionResult> Index()
        {
            return View(await _context.Aluno.ToListAsync());
        }

        // GET: Alunos/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aluno = await _context.Aluno
                .FirstOrDefaultAsync(m => m.Id == id);
            if (aluno == null)
            {
                return NotFound();
            }

            return View(aluno);
        }

        // GET: Alunos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Alunos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nome,Matricula,PrimeiraNota,SegundaNota,TerceiraNota,MediaPonderada,Status,Id")] Aluno aluno)
        {
            if (ModelState.IsValid)
            {
                aluno.Id = Guid.NewGuid();
                aluno.MediaPonderada = calcularMedia(aluno.PrimeiraNota, aluno.SegundaNota, aluno.TerceiraNota);
                StatusAluno(aluno.MediaPonderada);
                _context.Add(aluno);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(aluno);
        }

        public double calcularMedia(double a , double b, double c) {

            double media =  (((b * 2) + (c * 4)) + a) / (2.0 + 4.0);

            return Math.Round(media, 2);
        }
        public void StatusAluno(double media) {
            Aluno aluno = new Aluno();

            if (media > 6)
            {

                aluno.Status = EnumAluno.APROVADO;
            }
            else if (media >= 4 && media <= 6)
            {
                aluno.Status = EnumAluno.PROVAFINAL;
            }
            else
            {
                aluno.Status = EnumAluno.REPROVADO;
            }
        }
       

        // GET: Alunos/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aluno = await _context.Aluno.FindAsync(id);
            if (aluno == null)
            {
                return NotFound();
            }
            return View(aluno);
        }

        // POST: Alunos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Nome,Matricula,PrimeiraNota,SegundaNota,TerceiraNota,MediaPonderada,Status,Id")] Aluno aluno)
        {
            if (id != aluno.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                   aluno.MediaPonderada = calcularMedia(aluno.PrimeiraNota, aluno.SegundaNota, aluno.TerceiraNota);
                    
                    _context.Update(aluno);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AlunoExists(aluno.Id))
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
            return View(aluno);
        }

        // GET: Alunos/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aluno = await _context.Aluno
                .FirstOrDefaultAsync(m => m.Id == id);
            if (aluno == null)
            {
                return NotFound();
            }

            return View(aluno);
        }

        // POST: Alunos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var aluno = await _context.Aluno.FindAsync(id);
            _context.Aluno.Remove(aluno);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AlunoExists(Guid id)
        {
            return _context.Aluno.Any(e => e.Id == id);
        }
    }
}

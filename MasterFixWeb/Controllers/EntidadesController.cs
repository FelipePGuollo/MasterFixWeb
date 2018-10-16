using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MasterFixWeb.DataContext;
using MasterFixWeb.DataEntities;

namespace MasterFixWeb.Controllers
{
    public class EntidadesController : Controller
    {
        private readonly MasterFixContext _context;

        public EntidadesController(MasterFixContext context)
        {
            _context = context;
        }

        // GET: Entidades
        public async Task<IActionResult> Index(int? id)
        {
            if (id == null)
                id = 10;
            var listView = await _context.Entidade.ToListAsync();
            return View(listView.Take(id.Value));
        }

        // GET: Entidades/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entidade = await _context.Entidade
                .FirstOrDefaultAsync(m => m.Id == id);
            if (entidade == null)
            {
                return NotFound();
            }

            return View(entidade);
        }

        // GET: Entidades/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Entidades/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Rua,Numero,Complemento,Bairro,Cidade,Uf,Cep,Fone1,Fone2,Email,Homepage,Contato,ContatoFone,CnpjCpf,InscRg,Obs")] Entidade entidade)
        {
            if (ModelState.IsValid)
            {
                _context.Add(entidade);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(entidade);
        }

        // GET: Entidades/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entidade = await _context.Entidade.FindAsync(id);
            if (entidade == null)
            {
                return NotFound();
            }
            return View(entidade);
        }

        // POST: Entidades/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Rua,Numero,Complemento,Bairro,Cidade,Uf,Cep,Fone1,Fone2,Email,Homepage,Contato,ContatoFone,CnpjCpf,InscRg,Obs")] Entidade entidade)
        {
            if (id != entidade.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(entidade);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EntidadeExists(entidade.Id))
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
            return View(entidade);
        }

        // GET: Entidades/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entidade = await _context.Entidade
                .FirstOrDefaultAsync(m => m.Id == id);
            if (entidade == null)
            {
                return NotFound();
            }

            return View(entidade);
        }

        // POST: Entidades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var entidade = await _context.Entidade.FindAsync(id);
            _context.Entidade.Remove(entidade);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EntidadeExists(int id)
        {
            return _context.Entidade.Any(e => e.Id == id);
        }
    }
}

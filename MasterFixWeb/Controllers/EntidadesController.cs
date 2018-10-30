using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MasterFixWeb.DataContext;
using MasterFixWeb.Models;

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
        public IActionResult Index(int? id)
        {
            if (id == null)
                id = 35;
            return PartialView(_context.Entidade.OrderBy(s=> s.Id).Take(id.Value));
        }
        public PartialViewResult getListaEntidade(){
            return PartialView("_listaEntidades", _context.Entidade.OrderBy(s=> s.Id).Take(35));
        }


        [HttpPost, ActionName("getEntidade")]
        public PartialViewResult getEditEntidade(int id){
            return PartialView("_editEntidade", _context.Entidade.Find(id));
        }

        // GET: Entidades/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Criação da entidade
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

        // POST: Edição da entidade
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
                //entidade.Obs = System.Text.Encoding.ASCII.GetBytes(entidade.getObs);
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
            }
                //Retorna a tabela após atualizar a entidade.
                return RedirectToAction(nameof(getListaEntidade));
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BackendNextGen.Models;
using R3NextGenBackend;

namespace R3NextGenBackend.Controllers
{
    public class CompletedFormsController : Controller
    {
        private readonly RepositoryContext _context;

        public CompletedFormsController(RepositoryContext context)
        {
            _context = context;
        }

        // GET: CompletedForms
        public async Task<IActionResult> Index()
        {
            var repositoryContext = _context.CompletedForm.Include(c => c.Form);
            return View(await repositoryContext.ToListAsync());
        }

        // GET: CompletedForms/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var completedForm = await _context.CompletedForm
                .Include(c => c.Form)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (completedForm == null)
            {
                return NotFound();
            }

            return View(completedForm);
        }

        // GET: CompletedForms/Create
        public IActionResult Create()
        {
            ViewData["FormId"] = new SelectList(_context.Form, "Id", "Id");
            return View();
        }

        // POST: CompletedForms/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserId,CompletedDate,FormId")] CompletedForm completedForm)
        {
            if (ModelState.IsValid)
            {
                _context.Add(completedForm);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FormId"] = new SelectList(_context.Form, "Id", "Id", completedForm.FormId);
            return View(completedForm);
        }

        // GET: CompletedForms/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var completedForm = await _context.CompletedForm.FindAsync(id);
            if (completedForm == null)
            {
                return NotFound();
            }
            ViewData["FormId"] = new SelectList(_context.Form, "Id", "Id", completedForm.FormId);
            return View(completedForm);
        }

        // POST: CompletedForms/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,UserId,CompletedDate,FormId")] CompletedForm completedForm)
        {
            if (id != completedForm.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(completedForm);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CompletedFormExists(completedForm.Id))
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
            ViewData["FormId"] = new SelectList(_context.Form, "Id", "Id", completedForm.FormId);
            return View(completedForm);
        }

        // GET: CompletedForms/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var completedForm = await _context.CompletedForm
                .Include(c => c.Form)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (completedForm == null)
            {
                return NotFound();
            }

            return View(completedForm);
        }

        // POST: CompletedForms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var completedForm = await _context.CompletedForm.FindAsync(id);
            _context.CompletedForm.Remove(completedForm);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CompletedFormExists(long id)
        {
            return _context.CompletedForm.Any(e => e.Id == id);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BackendNextGen.Models;
using R3NextGenBackend;

namespace R3NextGenBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FormsController : ControllerBase
    {
        private readonly RepositoryContext _context;

        public FormsController(RepositoryContext context)
        {
            _context = context;
        }

        // GET: api/Forms
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Form>>> GetForm()
        {
            //return await _context.Form.ToListAsync();
            return await _context.Form
                .Include(form => form.FormFields)
                    .ThenInclude(FormFields => FormFields.Component)
                .Include(c => c.CompletedForms)
                    .ThenInclude(CompletedForms => CompletedForms.FormFieldValues)

                .ToListAsync();
        }

        // Henter kun de informationer vi skal bruge
        // GET: api/Forms
        // [HttpGet]
        //public async Task<ActionResult<IEnumerable<Form>>> GetForm()
        //{
        //    return await _context.Form
        //        .Include(form => form.FormFields)
        //            .ThenInclude(FormFields => FormFields.Select(a => a.Headline))
        //        // .Include(CompletedForms => CompletedForms.CompletedForms.Select(b => b.CompletedDate))
        //        .ToListAsync();
        //}

        // Get form name and id and show the names in a dropdown list.
        // Get form based on id and show the form on the formbuilder.
        // Create a form, give it a name and save it.

        // GET: api/Forms/all
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<Form>>> GetForm()
        //{
        //var formItems = _context.Form
        //    .Include(form => form.FormFields)

        //    .FirstOrDefaultAsync();

        //return await formItems.ToListAsync();
        //return await _context.Form.Include(f => f.FormFields).ToListAsync();
        //}

        // GET: api/Forms/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Form>> GetForm(long id)
        {
            var dd = _context.Form.ToList();
            var form = await _context.Form.FindAsync(id);

            if (form == null)
            {
                return NotFound();
            }

            return form;
        }

        // PUT: api/Forms/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutForm(long id, Form form)
        {
            if (id != form.Id)
            {
                return BadRequest();
            }

            _context.Entry(form).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FormExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Forms
        [HttpPost]
        public async Task<ActionResult<Form>> PostForm(Form form)
        {
            _context.Form.Add(form);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetForm", new { id = form.Id }, form);
        }

        // DELETE: api/Forms/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Form>> DeleteForm(long id)
        {
            var form = await _context.Form.FindAsync(id);
            if (form == null)
            {
                return NotFound();
            }

            _context.Form.Remove(form);
            await _context.SaveChangesAsync();

            return form;
        }

        private bool FormExists(long id)
        {
            return _context.Form.Any(e => e.Id == id);
        }
    }
}

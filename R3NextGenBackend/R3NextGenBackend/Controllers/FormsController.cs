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
            var list = _context.Form
                .Include(form => form.FormFields)
                    .ThenInclude(FormFields => FormFields.Component)
                .Include(c => c.CompletedForms)
                    .ThenInclude(CompletedForms => CompletedForms.FormFieldValues)
                .ToListAsync();
            return await list;
            //return await _context.Form
            //    .Include(form => form.FormFields)
            //        .ThenInclude(FormFields => FormFields.Component)
            //    .Include(c => c.CompletedForms)
            //        .ThenInclude(CompletedForms => CompletedForms.FormFieldValues)
            //    .ToListAsync();
        }

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

        // PUT api/values/5
        //[HttpPut("{id}")]
        //public void Put(long id, [FromBody] Form form)
        //{
        //    // Get the row from the database
        //    var formRow = _context.Form.Find(id);
        //    //var changedHeadline = _context.FormField.Find(id);
        //    // var formRow = _context.Form
        //    //    .Include(form => form.FormFields)

        //    if (formRow != null)
        //    {
        //        formRow.Name = form.Name;
                 
                
        //        _context.SaveChanges();
        //    }
        //}

        // PUT: api/Forms/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutForm(long id, Form form)
        {

            //if (id != form.Id)
            //{
            //    return BadRequest();
            //}


            // await _context.Form.First<Form>(f => f.FormFields == id);

            var rowToUpdate = await _context.Form
                .Include(f => f.FormFields)
                    .ThenInclude(FormFields => FormFields.Component)
                .Include(a => a.CompletedForms)
                    .ThenInclude(CompletedForms => CompletedForms.FormFieldValues)
                .FirstOrDefaultAsync(FormFields => FormFields.Id == id);

            //var rowToUpdate = _context.Form
            //    .Include(f => f.FormFields).FirstOrDefault(f => f.Id == id);

            //var formFields = _context.FormField.Where(ff => ff.FormId == id).ToList();

                //rowToUpdate.Name = form.Name;
                // rowToUpdate.FormFields = form.FormFields;

                //rowToUpdate.FormFields = form.FormFields;

                //foreach(var field in rowToUpdate.FormFields)
                //{

                //}

                _context.Update(rowToUpdate);
            //_context.Entry(rowToUpdate).CurrentValues.SetValues(form);
                                   
            //_context.Update(form).State = EntityState.Modified;
            _context.SaveChanges();

            //_context.Update(form).State = EntityState.Modified;
            // _context.Update(form); // .State = EntityState.Modified; // _context.UpdateRange(form); Entry

            // _context.Entry(form.FormFields).State = EntityState.Modified;
            // var formRow = _context.Form.Find(id);
            // formRow.Name = form.Name;

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

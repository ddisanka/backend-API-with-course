using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using studentapp.Model;

namespace studentapp.Controllers {
    [Route ("api/[controller]")]
    [ApiController]
    [DisableCors]
    public class StudentController : ControllerBase 
    {
        private readonly StudentContext _context;

        public StudentController (StudentContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Student> Gettblstudents () 
        {
            return _context.tblstudents;
        }

        [HttpGet ("{id}")]
        public async Task<IActionResult> GetStudent ([FromRoute] int id) 
        {
            if (!ModelState.IsValid) {
                return BadRequest (ModelState);
            }

            var student = await _context.tblstudents.FindAsync (id);

            if (student == null) {
                return NotFound ();
            }
            return Ok (student);
        }

        [HttpPut ("{id}")]
        public async Task<IActionResult> PutStudent ([FromRoute] int id, [FromBody] Student student) 
        {
            if (!ModelState.IsValid) 
            {
                return BadRequest (ModelState);
            }
            if (id != student.ID) 
            {
                return BadRequest ();
            }
            _context.Entry (student).State = EntityState.Modified;

            try 
            {
                await _context.SaveChangesAsync ();
            } 
            catch (DbUpdateConcurrencyException) 
            {
                if (!StudentExists (id)) 
                {
                    return NotFound ();
                } 
                else 
                {
                    throw;
                }
            }
            return NoContent ();
        }

        [HttpPost]
        public async Task<IActionResult> PostStudent ([FromBody] Student student) 
        {
            if (!ModelState.IsValid) 
            {
                return BadRequest (ModelState);
            }
            _context.tblstudents.Add (student);
            await _context.SaveChangesAsync ();

            return CreatedAtAction ("GetStudent", new { id = student.ID }, student);
        }

        [HttpDelete ("{id}")]
        public async Task<IActionResult> DeleteStudent ([FromRoute] int id)
        {
            if (!ModelState.IsValid) 
            {
                return BadRequest (ModelState);
            }

            var student = await _context.tblstudents.FindAsync (id);
            if (student == null) 
            {
                return NotFound ();
            }
            _context.tblstudents.Remove (student);
            await _context.SaveChangesAsync ();

            return Ok (student);
        }
        private bool StudentExists (int id) 
        {
            return _context.tblstudents.Any (e => e.ID == id);
        }
    }
}
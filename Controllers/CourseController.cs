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
    public class CourseController : ControllerBase 
    {
        private readonly StudentContext _context;

        public CourseController (StudentContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Course> Gettblcourses () 
        {
            return _context.tblcourses;
        }

        [HttpGet ("{id}")]
        public async Task<IActionResult> GetCourse ([FromRoute] int id) 
        {
            if (!ModelState.IsValid) {
                return BadRequest (ModelState);
            }

            var course = await _context.tblstudents.FindAsync (id);

            if (course == null) {
                return NotFound ();
            }
            return Ok (course);
        }

        [HttpPut ("{id}")]
        public async Task<IActionResult> PutCourse ([FromRoute] int id, [FromBody] Course course) 
        {
            if (!ModelState.IsValid) 
            {
                return BadRequest (ModelState);
            }
            if (id != course.CrseCode) 
            {
                return BadRequest ();
            }
            _context.Entry (course).State = EntityState.Modified;

            try 
            {
                await _context.SaveChangesAsync ();
            } 
            catch (DbUpdateConcurrencyException) 
            {
                if (!CourseExists (id)) 
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
        public async Task<IActionResult> PostCourse ([FromBody] Course course) 
        {
            if (!ModelState.IsValid) 
            {
                return BadRequest (ModelState);
            }
            _context.tblcourses.Add (course);
            await _context.SaveChangesAsync ();

            return CreatedAtAction ("GetCourse", new { id = course.CrseCode }, course);
        }

        [HttpDelete ("{id}")]
        public async Task<IActionResult> DeleteCourse ([FromRoute] int id)
        {
            if (!ModelState.IsValid) 
            {
                return BadRequest (ModelState);
            }

            var course = await _context.tblcourses.FindAsync (id);
            if (course == null) 
            {
                return NotFound ();
            }
            _context.tblcourses.Remove (course);
            await _context.SaveChangesAsync ();

            return Ok (course);
        }
        private bool CourseExists (int id) 
        {
            return _context.tblcourses.Any (c => c.CrseCode == id);
        }
    }
}
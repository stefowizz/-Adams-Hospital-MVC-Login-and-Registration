using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AuthSystem2.Data;
using AuthSystem2.Models;

namespace AuthSystem2.Controllers
{
    public class PatientMedHxesController : Controller
    {
        private readonly AuthDbContext _context;

        public PatientMedHxesController(AuthDbContext context)
        {
            _context = context;
        }

        


        public async Task<IActionResult> Index()
        {
            var lstHistory = await _context.PatientMedHx.ToListAsync();
            return View(lstHistory); 
        }

        


        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patientMedHx = await _context.PatientMedHx
                .FirstOrDefaultAsync(m => m.Id == id);
            if (patientMedHx == null)
            {
                return NotFound();
            }

            return View(patientMedHx);
        }

        

        public IActionResult Create()
        {
            return View();
        }

        



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PatientName,DateOfBirth,Gender,VisitDate,ChiefComplaint,Diagnosis,Treatment,DocNotes")] PatientMedHx patientMedHx)
        {
            if (ModelState.IsValid)
            {
                _context.Add(patientMedHx);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(patientMedHx);
        }

        


        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patientMedHx = await _context.PatientMedHx.FindAsync(id);
            if (patientMedHx == null)
            {
                return NotFound();
            }
            return View(patientMedHx);
        }

        



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PatientName,DateOfBirth,Gender,VisitDate,ChiefComplaint,Diagnosis,Treatment,DocNotes")] PatientMedHx patientMedHx)
        {
            if (id != patientMedHx.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(patientMedHx);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PatientMedHxExists(patientMedHx.Id))
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
            return View(patientMedHx);
        }

        



        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patientMedHx = await _context.PatientMedHx
                .FirstOrDefaultAsync(m => m.Id == id);
            if (patientMedHx == null)
            {
                return NotFound();
            }

            return View(patientMedHx);
        }

        




        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var patientMedHx = await _context.PatientMedHx.FindAsync(id);
            if (patientMedHx != null)
            {
                _context.PatientMedHx.Remove(patientMedHx);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PatientMedHxExists(int id)
        {
            return _context.PatientMedHx.Any(e => e.Id == id);
        }
    }
}

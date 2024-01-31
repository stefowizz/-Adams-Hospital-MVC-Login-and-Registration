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
    public class PrescriptionsController : Controller
    {
        private readonly AuthDbContext _context;

        public PrescriptionsController(AuthDbContext context)
        {
            _context = context;
        }

        
        public async Task<IActionResult> Index()
        {
            var lstPrsec = await _context.Prescription.ToListAsync();
            return View(lstPrsec); 
        }

        
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prescription = await _context.Prescription
                .FirstOrDefaultAsync(m => m.Id == id);
            if (prescription == null)
            {
                return NotFound();
            }

            return View(prescription);
        }

        
        public IActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PatientName,PatientAddress,Medication,Dosage,PrescriptionDate,DocNotes")] Prescription prescription)
        {
            if (ModelState.IsValid)
            {
                _context.Add(prescription);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(prescription);
        }

        
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prescription = await _context.Prescription.FindAsync(id);
            if (prescription == null)
            {
                return NotFound();
            }
            return View(prescription);
        }

        


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PatientName,PatientAddress,Medication,Dosage,PrescriptionDate,DocNotes")] Prescription prescription)
        {
            if (id != prescription.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(prescription);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PrescriptionExists(prescription.Id))
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
            return View(prescription);
        }

        


        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prescription = await _context.Prescription
                .FirstOrDefaultAsync(m => m.Id == id);
            if (prescription == null)
            {
                return NotFound();
            }

            return View(prescription);
        }

        



        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var prescription = await _context.Prescription.FindAsync(id);
            if (prescription != null)
            {
                _context.Prescription.Remove(prescription);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PrescriptionExists(int id)
        {
            return _context.Prescription.Any(e => e.Id == id);
        }
    }
}

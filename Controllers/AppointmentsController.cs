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
    public class AppointmentsController : Controller
    {
        private readonly AuthDbContext _context;

        public AppointmentsController(AuthDbContext context)
        {
            _context = context;
        }

        



        public async Task<IActionResult> Index()
        {
            var lstappoint = await _context.Points.ToListAsync();
            return View(lstappoint);
        }

        





        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appointment = await _context.Points.FirstOrDefaultAsync(m => m.Id == id);

            if (appointment == null)
            {
                return NotFound();
            }

            return View(appointment);
        }

       




        public IActionResult Create()
        {
            return View();
        }

        



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,StartTime,EndTime,Location,Description")] Appointment appointment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(appointment);

                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(appointment);
        }

        




        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appointment = await _context.Points.FindAsync(id);

            if (appointment == null)
            {
                return NotFound();
            }

            return View(appointment);
        }

        




        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,StartTime,EndTime,Location,Description")] Appointment appointment)
        {
            if (id != appointment.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(appointment);

                    await _context.SaveChangesAsync();
                }

                catch (DbUpdateConcurrencyException)
                {
                    if (!AppointmentExists(appointment.Id))
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

            return View(appointment);
        }

        





        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appointment = await _context.Points.FirstOrDefaultAsync(m => m.Id == id);

            if (appointment == null)
            {
                return NotFound();
            }

            return View(appointment);
        }

        





        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var appointment = await _context.Points.FindAsync(id);

            if (appointment != null)
            {
                _context.Points.Remove(appointment);
            }

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        private bool AppointmentExists(int id)
        {
            return _context.Points.Any(e => e.Id == id);
        }
    }
}

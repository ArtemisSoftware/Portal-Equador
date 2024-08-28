using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PortalEquador.Data;
using PortalEquador.Data.Curriculum.Entities;
using PortalEquador.Domain.Curriculum.Repository;
using PortalEquador.Domain.PersonalInformation.Repository;
using PortalEquador.Domain.PersonalInformation.ViewModels;

namespace PortalEquador.Controllers.Curriculum
{
    public class CurriculumController(
        CurriculumRepository repository,
        IPersonalInformationRepository personalInformationRepository
        ) : Controller
    {

        // GET: CurriculumsController
        public async Task<IActionResult> Index()
        {
            var result = await personalInformationRepository.GetAll();
            return View(result);
        }

        // GET: CurriculumsController/Dashboard
        public async Task<IActionResult> Dashboard(int identifier)
        {
            var model = await repository.GetCurriculumDashboard(identifier);
            return View(model);
        }


        /*
        private readonly ApplicationDbContext _context = context;

        // GET: Curriculum
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.CurriculumEntity.Include(c => c.ApplicationUserEntity);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Curriculum/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var curriculumEntity = await _context.CurriculumEntity
                .Include(c => c.ApplicationUserEntity)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (curriculumEntity == null)
            {
                return NotFound();
            }

            return View(curriculumEntity);
        }

        // GET: Curriculum/Create
        public IActionResult Create()
        {
            ViewData["EditorId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: Curriculum/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,EditorId,DateCreated,DateModified")] CurriculumEntity curriculumEntity)
        {
            if (ModelState.IsValid)
            {
                _context.Add(curriculumEntity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EditorId"] = new SelectList(_context.Users, "Id", "Id", curriculumEntity.EditorId);
            return View(curriculumEntity);
        }

        // GET: Curriculum/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var curriculumEntity = await _context.CurriculumEntity.FindAsync(id);
            if (curriculumEntity == null)
            {
                return NotFound();
            }
            ViewData["EditorId"] = new SelectList(_context.Users, "Id", "Id", curriculumEntity.EditorId);
            return View(curriculumEntity);
        }

        // POST: Curriculum/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,EditorId,DateCreated,DateModified")] CurriculumEntity curriculumEntity)
        {
            if (id != curriculumEntity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(curriculumEntity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CurriculumEntityExists(curriculumEntity.Id))
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
            ViewData["EditorId"] = new SelectList(_context.Users, "Id", "Id", curriculumEntity.EditorId);
            return View(curriculumEntity);
        }

        // GET: Curriculum/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var curriculumEntity = await _context.CurriculumEntity
                .Include(c => c.ApplicationUserEntity)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (curriculumEntity == null)
            {
                return NotFound();
            }

            return View(curriculumEntity);
        }

        // POST: Curriculum/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var curriculumEntity = await _context.CurriculumEntity.FindAsync(id);
            if (curriculumEntity != null)
            {
                _context.CurriculumEntity.Remove(curriculumEntity);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CurriculumEntityExists(int id)
        {
            return _context.CurriculumEntity.Any(e => e.Id == id);
        }
        */
    }
}

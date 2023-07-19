using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PortalEquador.Constants;
using PortalEquador.Data;
using PortalEquador.Data.CurriculumVitae;
using PortalEquador.Data.DriversLicence.Entities;
using PortalEquador.Data.Migrations;
using PortalEquador.Domain.Converters;
using PortalEquador.Domain.Models.DriversLicence;
using PortalEquador.Domain.Repositories;
using PortalEquador.Domain.UseCases.Documents;
using PortalEquador.Domain.UseCases.DriversLicence;
using PortalEquador.Models.Documents;

namespace PortalEquador.Controllers.DriversLicence
{
    public class DriversLicenceController : Controller
    {
        private readonly IWebHostEnvironment _hostEnvironment;
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly DriversLicenceRepository _driversLicenceRepository;
        private readonly SaveDriversLicenceUseCase _saveDriversLicenceUseCase;
        private readonly SaveDocumentUseCase _saveDocumentUseCase;

        public DriversLicenceController(
            ApplicationDbContext context, 
            DriversLicenceRepository driversLicenceRepository,
            IWebHostEnvironment hostEnvironment,
            IMapper mapper,
            SaveDriversLicenceUseCase saveDriversLicenceUseCase,
            SaveDocumentUseCase saveDocumentUseCase
            )
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
            _mapper = mapper;
            _driversLicenceRepository = driversLicenceRepository;

            _saveDriversLicenceUseCase = saveDriversLicenceUseCase;
            _saveDocumentUseCase = saveDocumentUseCase;
        }

        // GET: DriversLicence
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.DriversLicenceEntity.Include(d => d.GroupItem);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: DriversLicence/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.DriversLicenceEntity == null)
            {
                return NotFound();
            }

            var driversLicenceEntity = await _context.DriversLicenceEntity
                .Include(d => d.GroupItem)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (driversLicenceEntity == null)
            {
                return NotFound();
            }

            return View(driversLicenceEntity);
        }

        // GET: DriversLicence/Create
        public IActionResult Create()
        {
            var model = new DriversLicenceCreateViewModel
            {
                CurriculumId = 1,
                LicenceTypes = _driversLicenceRepository.GroupItems(Groups.DRIVERS_LICENCE)
            };

            ViewData["GroupItemId"] = new SelectList(_context.GroupItems, "Id", "Id");
            return View(model);
        }

        // POST: DriversLicence/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DriversLicenceCreateViewModel model)
        {
 
            if (ModelState.IsValid)
            {/*
                if(model.ImageFile != null) {
                    var document = _mapper.Map<Document>(model);
                    await _saveDocumentUseCase.Invoke(document);
                }
                */
                 await _saveDriversLicenceUseCase.Invoke(model);
 
                return RedirectToAction(nameof(Index));
            }
            /*
            ViewData["GroupItemId"] = new SelectList(_context.GroupItems, "Id", "Id", driversLicenceEntity.GroupItemId);
            return View(driversLicenceEntity);
            */
            return View(model);
        }

        // GET: DriversLicence/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.DriversLicenceEntity == null)
            {
                return NotFound();
            }

            var driversLicenceEntity = await _context.DriversLicenceEntity.FindAsync(id);
            if (driversLicenceEntity == null)
            {
                return NotFound();
            }
            ViewData["GroupItemId"] = new SelectList(_context.GroupItems, "Id", "Id", driversLicenceEntity.GroupItemId);
            return View(driversLicenceEntity);
        }

        // POST: DriversLicence/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CurriculumId,ExpirationDate,ProvisionalRenewalNumber,ProvisionalExpirationDate,GroupItemId,Id,DateCreated,DateModified")] DriversLicenceEntity driversLicenceEntity)
        {
            if (id != driversLicenceEntity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(driversLicenceEntity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DriversLicenceEntityExists(driversLicenceEntity.Id))
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
            ViewData["GroupItemId"] = new SelectList(_context.GroupItems, "Id", "Id", driversLicenceEntity.GroupItemId);
            return View(driversLicenceEntity);
        }

        // GET: DriversLicence/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.DriversLicenceEntity == null)
            {
                return NotFound();
            }

            var driversLicenceEntity = await _context.DriversLicenceEntity
                .Include(d => d.GroupItem)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (driversLicenceEntity == null)
            {
                return NotFound();
            }

            return View(driversLicenceEntity);
        }

        // POST: DriversLicence/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.DriversLicenceEntity == null)
            {
                return Problem("Entity set 'ApplicationDbContext.DriversLicenceEntity'  is null.");
            }
            var driversLicenceEntity = await _context.DriversLicenceEntity.FindAsync(id);
            if (driversLicenceEntity != null)
            {
                _context.DriversLicenceEntity.Remove(driversLicenceEntity);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DriversLicenceEntityExists(int id)
        {
          return (_context.DriversLicenceEntity?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

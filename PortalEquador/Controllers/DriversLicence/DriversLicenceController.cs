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
using PortalEquador.Domain.Models.Document;
using PortalEquador.Domain.Models.DriversLicence;
using PortalEquador.Domain.Repositories;
using PortalEquador.Domain.UseCases;
using PortalEquador.Domain.UseCases.Documents;
using PortalEquador.Domain.UseCases.DriversLicence;
using PortalEquador.Domain.UseCases.PersonalInformation;
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
        private readonly SaveDriversLicenceUseCase__ _saveDriversLicenceUseCase__;
        private readonly SaveDocumentUseCase _saveDocumentUseCase;
        private readonly GetAllDriversLicencesUseCase _getAllDriversLicencesUseCase;
        private readonly GetDriversLicenceCreationInfoUseCase _getDriversLicenceCreationInfoUseCase;
        private readonly GetDriversLicenceUseCase _getDriversLicenceUseCase;
        private readonly GetDriversLicenceUseCase__ _getDriversLicenceUseCase__;
        private readonly RenewDriversLicenceUseCase _renewDriversLicenceUseCase;

        public DriversLicenceController(
            ApplicationDbContext context, 
            DriversLicenceRepository driversLicenceRepository,
            IWebHostEnvironment hostEnvironment,
            IMapper mapper,
            SaveDriversLicenceUseCase saveDriversLicenceUseCase,
            SaveDriversLicenceUseCase__ saveDriversLicenceUseCase__,
            SaveDocumentUseCase saveDocumentUseCase,
            GetAllDriversLicencesUseCase getAllDriversLicencesUseCase,
            GetDriversLicenceCreationInfoUseCase getDriversLicenceCreationInfoUseCase,
            GetDriversLicenceUseCase getDriversLicenceUseCase,
            GetDriversLicenceUseCase__ getDriversLicenceUseCase__,
            RenewDriversLicenceUseCase renewDriversLicenceUseCase
            )
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
            _mapper = mapper;
            _driversLicenceRepository = driversLicenceRepository;

            _saveDriversLicenceUseCase = saveDriversLicenceUseCase;
            _saveDriversLicenceUseCase__ = saveDriversLicenceUseCase__;
            _saveDocumentUseCase = saveDocumentUseCase;
            _getAllDriversLicencesUseCase = getAllDriversLicencesUseCase;
            _getDriversLicenceCreationInfoUseCase = getDriversLicenceCreationInfoUseCase;
            _getDriversLicenceUseCase = getDriversLicenceUseCase;
            _getDriversLicenceUseCase__ = getDriversLicenceUseCase__;
            _renewDriversLicenceUseCase = renewDriversLicenceUseCase;
        }

        // GET: DriversLicence
        public async Task<IActionResult> Index()
        {
            var result = await _getAllDriversLicencesUseCase.Invoke();
            return View(result);
        }

        // GET: DriversLicence/Details/5
        public async Task<IActionResult> Details(int CurriculumId)
        {

            var model = await _getDriversLicenceUseCase__.Invoke((int)CurriculumId);
            if (model == null)
            {
                return NotFound();
            }
            return View(model);

            /*
            if (CurriculumId == null)
            {
                return NotFound();
            }
            else
            {
                var model = await _getDriversLicenceUseCase.Invoke((int)CurriculumId);
                if (model == null)
                {
                    return NotFound();
                }
                return View(model);
            }
            */
            return NotFound();
        }

        // GET: DriversLicence/Create
        public async Task<IActionResult> Create(int CurriculumId)
        {
            var model = await _getDriversLicenceCreationInfoUseCase.Invoke(CurriculumId);

            return View(model);
        }

        // POST: DriversLicence/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DriversLicenceCreateViewModel model)
        {
            return RedirectToAction(nameof(Index));
            /*
            if (ModelState.IsValid)
            {
                if(model.ImageFile != null) {
                    var document = _mapper.Map<DocumentEntity>(model);
                    await _saveDocumentUseCase.Invoke(document);
                }
                
                 await _saveDriversLicenceUseCase.Invoke(model);
 
                return RedirectToAction(nameof(Index));
            }
            
            return View(model);
            */
        }

        // GET: DriversLicence/Edit/5
        public async Task<IActionResult> Edit(int? CurriculumId)
        {
            if (CurriculumId == null)
            {
                return NotFound();
            }

            var model = await _getDriversLicenceUseCase__.Invoke((int)CurriculumId);

            if (model == null)
            {
                return NotFound();
            }
           ViewData["GroupItemId"] = model.LicenceTypes;
            return View(model);
        }

        // POST: DriversLicence/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(DriversLicenceViewModel__ model)
        {

             await _saveDriversLicenceUseCase__.Invoke(model, OperationType.Update);
            return RedirectToAction(nameof(Index));

            /*
            if (id != driversLicenceEntity.Id)
            {*/
            return NotFound();
            /*}

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
            */
        }

        // GET: DriversLicence/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            return NotFound();
            /*
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
            */
        }

        // POST: DriversLicence/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            return NotFound();
            /*
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
            */
        }


        // GET: DriversLicence/RenewLicence
        public async Task<IActionResult> RenewLicence(int? CurriculumId)
        {
            if (CurriculumId == null)
            {
                return NotFound();
            }

            var model = await _getDriversLicenceUseCase__.Invoke((int)CurriculumId);

            if (model == null)
            {
                return NotFound();
            }
            return View(model);
        }


        // POST: DriversLicence/RenewLicence/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RenewLicence(DriversLicenceViewModel__ model)
        {

            await _renewDriversLicenceUseCase.Invoke(model);
            return RedirectToAction(nameof(Index));

            /*
            if (id != driversLicenceEntity.Id)
            {*/
            return NotFound();
            /*}

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
            */
        }



        // GET: DriversLicence/RenewLicence
        public async Task<IActionResult> RenewProvisional(int? CurriculumId)
        {
            if (CurriculumId == null)
            {
                return NotFound();
            }

            var model = await _getDriversLicenceUseCase__.Invoke((int)CurriculumId);

            if (model == null)
            {
                return NotFound();
            }
            return View(model);
        }

        // POST: DriversLicence/RenewLicence/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RenewProvisional(DriversLicenceViewModel__ model)
        {

            await _saveDriversLicenceUseCase__.Invoke(model, OperationType.Update);

            if (model.ImageFile != null) {
               // await _saveDocumentUseCase.Invoke()
             }

            return RedirectToAction(nameof(Index));

            /*
            if (id != driversLicenceEntity.Id)
            {*/
            return NotFound();
            /*}

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
            */
        }



        private bool DriversLicenceEntityExists(int id)
        {
          return /*(_context.DriversLicenceEntity?.Any(e => e.Id == id)).GetValueOrDefault()*/true;
        }
    }
}

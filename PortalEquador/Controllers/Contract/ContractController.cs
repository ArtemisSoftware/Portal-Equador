using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PortalEquador.Data;
using PortalEquador.Data.Contract.Entities;
using PortalEquador.Domain.Contract.Repository;
using PortalEquador.Domain.Education.School.Repository;
using PortalEquador.Domain.PersonalInformation.Repository;

namespace PortalEquador.Controllers.Contract
{
    public class ContractController(IContractRepository repository) : Controller
    {

        // GET: Contract
        public async Task<IActionResult> Index()
        {
            var result = await repository.GetAll();
            return View(result);
        }

        // GET: Contract/Dashboard
        public async Task<IActionResult> Dashboard(int identifier)
        {
            var model = await repository.GetDashboard(identifier);
            return View(model);
        }

        /*
        private readonly ApplicationDbContext _context;

        public ContractController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Contract
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ContractEntity.Include(c => c.ApplicationUserEntity).Include(c => c.LocationGroupItemEntity).Include(c => c.PersonalInformationEntity).Include(c => c.RegimentGroupItemEntity);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Contract/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contractEntity = await _context.ContractEntity
                .Include(c => c.ApplicationUserEntity)
                .Include(c => c.LocationGroupItemEntity)
                .Include(c => c.PersonalInformationEntity)
                .Include(c => c.RegimentGroupItemEntity)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contractEntity == null)
            {
                return NotFound();
            }

            return View(contractEntity);
        }

        // GET: Contract/Create
        public IActionResult Create()
        {
            ViewData["EditorId"] = new SelectList(_context.Users, "Id", "Id");
            ViewData["LocationId"] = new SelectList(_context.GroupItemEntity, "Id", "Id");
            ViewData["PersonalInformationId"] = new SelectList(_context.PersonalInformationEntity, "Id", "Id");
            ViewData["RegimentId"] = new SelectList(_context.GroupItemEntity, "Id", "Id");
            return View();
        }

        // POST: Contract/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PersonalInformationId,StartDate,Duration,UndeterminateDuration,EndDate,LocationId,LocationDate,RegimentId,Observation,Id,EditorId,DateCreated,DateModified")] ContractEntity contractEntity)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contractEntity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EditorId"] = new SelectList(_context.Users, "Id", "Id", contractEntity.EditorId);
            ViewData["LocationId"] = new SelectList(_context.GroupItemEntity, "Id", "Id", contractEntity.LocationId);
            ViewData["PersonalInformationId"] = new SelectList(_context.PersonalInformationEntity, "Id", "Id", contractEntity.PersonalInformationId);
            ViewData["RegimentId"] = new SelectList(_context.GroupItemEntity, "Id", "Id", contractEntity.RegimentId);
            return View(contractEntity);
        }

        // GET: Contract/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contractEntity = await _context.ContractEntity.FindAsync(id);
            if (contractEntity == null)
            {
                return NotFound();
            }
            ViewData["EditorId"] = new SelectList(_context.Users, "Id", "Id", contractEntity.EditorId);
            ViewData["LocationId"] = new SelectList(_context.GroupItemEntity, "Id", "Id", contractEntity.LocationId);
            ViewData["PersonalInformationId"] = new SelectList(_context.PersonalInformationEntity, "Id", "Id", contractEntity.PersonalInformationId);
            ViewData["RegimentId"] = new SelectList(_context.GroupItemEntity, "Id", "Id", contractEntity.RegimentId);
            return View(contractEntity);
        }

        // POST: Contract/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PersonalInformationId,StartDate,Duration,UndeterminateDuration,EndDate,LocationId,LocationDate,RegimentId,Observation,Id,EditorId,DateCreated,DateModified")] ContractEntity contractEntity)
        {
            if (id != contractEntity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contractEntity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContractEntityExists(contractEntity.Id))
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
            ViewData["EditorId"] = new SelectList(_context.Users, "Id", "Id", contractEntity.EditorId);
            ViewData["LocationId"] = new SelectList(_context.GroupItemEntity, "Id", "Id", contractEntity.LocationId);
            ViewData["PersonalInformationId"] = new SelectList(_context.PersonalInformationEntity, "Id", "Id", contractEntity.PersonalInformationId);
            ViewData["RegimentId"] = new SelectList(_context.GroupItemEntity, "Id", "Id", contractEntity.RegimentId);
            return View(contractEntity);
        }

        // GET: Contract/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contractEntity = await _context.ContractEntity
                .Include(c => c.ApplicationUserEntity)
                .Include(c => c.LocationGroupItemEntity)
                .Include(c => c.PersonalInformationEntity)
                .Include(c => c.RegimentGroupItemEntity)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contractEntity == null)
            {
                return NotFound();
            }

            return View(contractEntity);
        }

        // POST: Contract/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var contractEntity = await _context.ContractEntity.FindAsync(id);
            if (contractEntity != null)
            {
                _context.ContractEntity.Remove(contractEntity);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContractEntityExists(int id)
        {
            return _context.ContractEntity.Any(e => e.Id == id);
        }
        */
    }
}

using Microsoft.AspNetCore.Mvc;
using PortalEquador.Domain.Contract.Repository;
using PortalEquador.Domain.Contract.ViewModels;
using PortalEquador.Util.Constants;

namespace PortalEquador.Controllers.Contract
{
    public class ContractController(IContractRepository repository) : Controller
    {

        // GET: Contract
        public async Task<IActionResult> Index(int stateId = -1)
        {
            var result = await repository.GetAll(stateId);
            return View(result);
        }


        // GET: Contract/Dashboard
        public async Task<IActionResult> Dashboard(int identifier)
        {
            var model = await repository.GetDashboard(identifier);
            return View(model);
        }


        public async Task<IActionResult> Create(int identifier, string fullName, string origin)
        {
            ViewData[ViewBagConstants.PERSONAL_ID] = identifier;
            ViewData[ViewBagConstants.FULL_NAME] = fullName;
            ViewData[ViewBagConstants.ORIGIN] = origin;

            var model = await repository.GetCreateModel(identifier, fullName);
            return View(model);
        }


        // POST: Contract/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ContractCreate__ViewModel model)
        {

            ViewData[ViewBagConstants.ORIGIN] = model.Origin;
            ViewData[ViewBagConstants.PERSONAL_ID] = model.PersonaInformationId;
            ViewData[ViewBagConstants.FULL_NAME] = model.FullName;

            if (ModelState.IsValid)
            {
                await repository.Save(model);
                return await Redirect();
            }

            var recoverModel = await RecoverModel(model);
            return View(recoverModel);
        }

        private async Task<ContractCreate__ViewModel> RecoverModel(ContractCreate__ViewModel model)
        {
            return await repository.GetCreateModel(model);
        }

        // GET: Contract/Resign
        public async Task<IActionResult> Resign(int identifier, string fullName, string origin)
        {
            var model = await repository.GetResignationModel(identifier);
            model.Origin = origin;
            model.FullName = fullName;

            ViewData[ViewBagConstants.ORIGIN] = origin;
            ViewData[ViewBagConstants.PERSONAL_ID] = identifier;
            ViewData[ViewBagConstants.FULL_NAME] = model.FullName;

            return View(model);
        }

        // POST: Language/Edit
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Resign(ContractResignViewModel model)
        {

            ViewData[ViewBagConstants.ORIGIN] = model.Origin;
            ViewData[ViewBagConstants.PERSONAL_ID] = model.PersonaInformationId;
            ViewData[ViewBagConstants.FULL_NAME] = model.FullName;

            if (ModelState.IsValid)
            {
                await repository.Save(model);
                return await Redirect();
            }

            var recoverModel = await RecoverModel(model);
            return View(recoverModel);
        }

        private async Task<ContractResignViewModel> RecoverModel(ContractResignViewModel model)
        {
            return await repository.GetResignationModel(model);
        }






        public async Task<IActionResult> History(int identifier, string fullName)
        {
            ViewData[ViewBagConstants.PERSONAL_ID] = identifier;
            ViewData[ViewBagConstants.FULL_NAME] = fullName;
            var model = await repository.GetAllContracts(identifier);
            return View(model);
        }

        private async Task<IActionResult> Redirect()
        {

            var origin = ViewData[ViewBagConstants.ORIGIN];
            var identifier = ViewData[ViewBagConstants.PERSONAL_ID];

            if (origin == "cv")
            {
                return RedirectToAction(nameof(Dashboard), "Curriculum", new { identifier = identifier });
            }
            else
            {
                return RedirectToAction(nameof(Dashboard), "Contract", new { identifier = identifier });
            }
        }



        /*
        

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

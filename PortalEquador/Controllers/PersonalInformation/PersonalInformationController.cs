using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PortalEquador.Data;
using PortalEquador.Data.PersonalInformation.Entity;
using PortalEquador.Domain.GroupTypes.Repository;
using PortalEquador.Domain.PersonalInformation.Repository;
using PortalEquador.Domain.PersonalInformation.ViewModels;
using PortalEquador.Util.Constants;

namespace PortalEquador.Controllers.PersonalInformation
{
    public class PersonalInformationController(IPersonalInformationRepository repository) : Controller
    {

        public async Task<IActionResult> Create(string? identityCard, bool? validIdentityCard)
        {
            var model = await repository.GetCreateModel(null);

            if (identityCard != null)
            {
                model.IdentityCard = identityCard;
                model.ValidatedIdentityCard = (bool)validIdentityCard;

                if (validIdentityCard == false)
                {
                    ModelState.AddModelError(nameof(model.Error), StringConstants.Error.EXISTING_IDENTITY_CARD);
                }
            }
            return View(model);
        }

        // POST: PersonalInformation/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PersonalInformationViewModel model)
        {
            var valid = await repository.ValidateIdentityCardNumber(model.IdentityCard);

            if (valid == false)
            {
                ModelState.AddModelError(nameof(model.Error), StringConstants.Error.EXISTING_IDENTITY_CARD);
            }
            else if (ModelState.IsValid && valid)
            {
                await repository.Save(model);
                var savedModel = await repository.GetPersonalInformationFromBI(model.IdentityCard);
                return RedirectToAction(StringConstants.Controller.Action.Dashboard, StringConstants.Controller.Curriculums, new { identifier = savedModel.Id });
            }

            model = await RecoverPersonalInformationtModel(model);
            return View(model);
        }

        public async Task<IActionResult> ValidateIdentityCard(PersonalInformationViewModel model)
        {
            if (model.IdentityCard == null)
            {
                return RedirectToAction(nameof(Create));
            }
            else
            {
                var valid = await repository.ValidateIdentityCardNumber(model.IdentityCard);
                return RedirectToAction(nameof(Create), new { identityCard = model.IdentityCard, validIdentityCard = valid });
            }
        }

        private async Task<PersonalInformationViewModel> RecoverPersonalInformationtModel(PersonalInformationViewModel model)
        {
            return await repository.GetCreateModel(model);
        }


        // GET: PersonalInformation/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            else
            {
                var model = await repository.GetPersonalInformationDetail((int)id);
                ViewData["id"] = model.Id;
                return View(model);
            }
        }
        

        // GET: PersonalInformation/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            ViewData["id"] = id;
            if (id == null)
            {
                return NotFound();
            }

            var model = await repository.GetPersonalInformation((int)id);
            model = await RecoverPersonalInformationtModel(model);
            return View(model);
        }

        // POST: PersonalInformation/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(PersonalInformationViewModel model)
        {
            if (ModelState.IsValid)
            {
                await repository.Save(model);
                return RedirectToAction(StringConstants.Controller.Action.Dashboard, StringConstants.Controller.Curriculums, new { identifier = model.Id });
            }
            ViewData["identifier"] = model.Id;
            model = await RecoverPersonalInformationtModel(model);
            return View(model);
        }



        /*
        // GET: PersonalInformation
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.PersonalInformationEntity.Include(p => p.ApplicationUserEntity).Include(p => p.MaritalStatusIdGroupItemEntity).Include(p => p.MotherTongueGroupItemEntity).Include(p => p.NationalityGroupItemEntity).Include(p => p.NeighbourhoodGroupItemEntity).Include(p => p.ProvinceGroupItemEntity);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: PersonalInformation/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personalInformationEntity = await _context.PersonalInformationEntity
                .Include(p => p.ApplicationUserEntity)
                .Include(p => p.MaritalStatusIdGroupItemEntity)
                .Include(p => p.MotherTongueGroupItemEntity)
                .Include(p => p.NationalityGroupItemEntity)
                .Include(p => p.NeighbourhoodGroupItemEntity)
                .Include(p => p.ProvinceGroupItemEntity)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (personalInformationEntity == null)
            {
                return NotFound();
            }

            return View(personalInformationEntity);
        }

        // GET: PersonalInformation/Create
        public IActionResult Create()
        {
            ViewData["EditorId"] = new SelectList(_context.Users, "Id", "Id");
            ViewData["MaritalStatusId"] = new SelectList(_context.GroupItemEntity, "Id", "Id");
            ViewData["MotherTongueId"] = new SelectList(_context.GroupItemEntity, "Id", "Id");
            ViewData["NationalityId"] = new SelectList(_context.GroupItemEntity, "Id", "Id");
            ViewData["NeighbourhoodId"] = new SelectList(_context.GroupItemEntity, "Id", "Id");
            ViewData["ProvinceId"] = new SelectList(_context.GroupItemEntity, "Id", "Id");
            return View();
        }

        // POST: PersonalInformation/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdentityCard,Nif,IdentityCardExpirationDate,BeneficiaryNumber,FirstName,LastName,DateOfBirth,Email,Contacts,NationalityId,ProvinceId,NeighbourhoodId,Address,MotherTongueId,MaritalStatusId,Id,EditorId,DateCreated,DateModified")] PersonalInformationEntity personalInformationEntity)
        {
            if (ModelState.IsValid)
            {
                _context.Add(personalInformationEntity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EditorId"] = new SelectList(_context.Users, "Id", "Id", personalInformationEntity.EditorId);
            ViewData["MaritalStatusId"] = new SelectList(_context.GroupItemEntity, "Id", "Id", personalInformationEntity.MaritalStatusId);
            ViewData["MotherTongueId"] = new SelectList(_context.GroupItemEntity, "Id", "Id", personalInformationEntity.MotherTongueId);
            ViewData["NationalityId"] = new SelectList(_context.GroupItemEntity, "Id", "Id", personalInformationEntity.NationalityId);
            ViewData["NeighbourhoodId"] = new SelectList(_context.GroupItemEntity, "Id", "Id", personalInformationEntity.NeighbourhoodId);
            ViewData["ProvinceId"] = new SelectList(_context.GroupItemEntity, "Id", "Id", personalInformationEntity.ProvinceId);
            return View(personalInformationEntity);
        }

        // GET: PersonalInformation/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personalInformationEntity = await _context.PersonalInformationEntity.FindAsync(id);
            if (personalInformationEntity == null)
            {
                return NotFound();
            }
            ViewData["EditorId"] = new SelectList(_context.Users, "Id", "Id", personalInformationEntity.EditorId);
            ViewData["MaritalStatusId"] = new SelectList(_context.GroupItemEntity, "Id", "Id", personalInformationEntity.MaritalStatusId);
            ViewData["MotherTongueId"] = new SelectList(_context.GroupItemEntity, "Id", "Id", personalInformationEntity.MotherTongueId);
            ViewData["NationalityId"] = new SelectList(_context.GroupItemEntity, "Id", "Id", personalInformationEntity.NationalityId);
            ViewData["NeighbourhoodId"] = new SelectList(_context.GroupItemEntity, "Id", "Id", personalInformationEntity.NeighbourhoodId);
            ViewData["ProvinceId"] = new SelectList(_context.GroupItemEntity, "Id", "Id", personalInformationEntity.ProvinceId);
            return View(personalInformationEntity);
        }

        // POST: PersonalInformation/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdentityCard,Nif,IdentityCardExpirationDate,BeneficiaryNumber,FirstName,LastName,DateOfBirth,Email,Contacts,NationalityId,ProvinceId,NeighbourhoodId,Address,MotherTongueId,MaritalStatusId,Id,EditorId,DateCreated,DateModified")] PersonalInformationEntity personalInformationEntity)
        {
            if (id != personalInformationEntity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(personalInformationEntity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PersonalInformationEntityExists(personalInformationEntity.Id))
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
            ViewData["EditorId"] = new SelectList(_context.Users, "Id", "Id", personalInformationEntity.EditorId);
            ViewData["MaritalStatusId"] = new SelectList(_context.GroupItemEntity, "Id", "Id", personalInformationEntity.MaritalStatusId);
            ViewData["MotherTongueId"] = new SelectList(_context.GroupItemEntity, "Id", "Id", personalInformationEntity.MotherTongueId);
            ViewData["NationalityId"] = new SelectList(_context.GroupItemEntity, "Id", "Id", personalInformationEntity.NationalityId);
            ViewData["NeighbourhoodId"] = new SelectList(_context.GroupItemEntity, "Id", "Id", personalInformationEntity.NeighbourhoodId);
            ViewData["ProvinceId"] = new SelectList(_context.GroupItemEntity, "Id", "Id", personalInformationEntity.ProvinceId);
            return View(personalInformationEntity);
        }

        // GET: PersonalInformation/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personalInformationEntity = await _context.PersonalInformationEntity
                .Include(p => p.ApplicationUserEntity)
                .Include(p => p.MaritalStatusIdGroupItemEntity)
                .Include(p => p.MotherTongueGroupItemEntity)
                .Include(p => p.NationalityGroupItemEntity)
                .Include(p => p.NeighbourhoodGroupItemEntity)
                .Include(p => p.ProvinceGroupItemEntity)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (personalInformationEntity == null)
            {
                return NotFound();
            }

            return View(personalInformationEntity);
        }

        // POST: PersonalInformation/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var personalInformationEntity = await _context.PersonalInformationEntity.FindAsync(id);
            if (personalInformationEntity != null)
            {
                _context.PersonalInformationEntity.Remove(personalInformationEntity);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PersonalInformationEntityExists(int id)
        {
            return _context.PersonalInformationEntity.Any(e => e.Id == id);
        }
        */
    }
}

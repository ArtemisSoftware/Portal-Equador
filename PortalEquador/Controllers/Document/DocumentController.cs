using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PortalEquador.Data;
using PortalEquador.Data.Document.Entity;
using PortalEquador.Domain.Document.Repository;
using PortalEquador.Domain.Document.ViewModels;
using PortalEquador.Domain.GroupTypes.Repository;
using PortalEquador.Util.Constants;

namespace PortalEquador.Controllers.Document
{
    public class DocumentController(IDocumentRepository documentRepository) : Controller
    {
        
        // GET: Documents/Create
        public async Task<IActionResult> Create(int identifier, string fullName)
        {
            var model = await documentRepository.GetCreateModel(identifier, fullName);
            return View(model);
        }

        // POST: Documents/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DocumentViewModel model)
        {
            var exists = await documentRepository.DocumentExists(model.PersonaInformationId, model.DocumentTypeId);
            if (exists)
            {
                ModelState.AddModelError(nameof(model.Error), StringConstants.Error.EXISTING_DOCUMENT);
            }
            else
            {
                if (ModelState.IsValid)
                {
                    await documentRepository.Save(model);
                    return RedirectToAction(nameof(Index), new { identifier = model.PersonaInformationId });
                }
            }

            //ViewData["id"] = model.Id;
            model = await RecoverModel(model);
            return View(model);

        }
        /*
// GET: Documents
public async Task<IActionResult> Index(int identifier, string? username)
{
    var result = await _getDocumentsUseCase.Invoke(identifier);
    ViewData["identifier"] = identifier;
    ViewData["username"] = username;

    if (result.Count > 0)
    {
        ViewData["username"] = result[0].PersonalInformation.FullName;
    }
    return View(result);
}

[HttpPost, ActionName("Delete")]
[ValidateAntiForgeryToken]
public async Task<IActionResult> DeleteConfirmed(int id, int identifier, string username)
{
    await _deleteDocumentUseCase.Invoke(id);
    return RedirectToAction(nameof(Index), new { identifier = identifier, username = username });
}


*/

        private async Task<DocumentViewModel> RecoverModel(DocumentViewModel model)
        {
            return await documentRepository.GetCreateModel(model.Id, model.FullName);
        }





        /*
        private readonly ApplicationDbContext _context;

        public DocumentController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Document
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.DocumentEntity.Include(d => d.ApplicationUserEntity).Include(d => d.DocumentTypeGroupItemEntity).Include(d => d.PersonalInformationEntity);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Document/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var documentEntity = await _context.DocumentEntity
                .Include(d => d.ApplicationUserEntity)
                .Include(d => d.DocumentTypeGroupItemEntity)
                .Include(d => d.PersonalInformationEntity)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (documentEntity == null)
            {
                return NotFound();
            }

            return View(documentEntity);
        }

        // GET: Document/Create
        public IActionResult Create()
        {
            ViewData["EditorId"] = new SelectList(_context.Users, "Id", "Id");
            ViewData["DocumentTypeId"] = new SelectList(_context.GroupItemEntity, "Id", "Id");
            ViewData["PersonalInformationId"] = new SelectList(_context.PersonalInformationEntity, "Id", "Id");
            return View();
        }

        // POST: Document/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PersonalInformationId,Observation,DocumentTypeId,Extension,Id,EditorId,DateCreated,DateModified")] DocumentEntity documentEntity)
        {
            if (ModelState.IsValid)
            {
                _context.Add(documentEntity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EditorId"] = new SelectList(_context.Users, "Id", "Id", documentEntity.EditorId);
            ViewData["DocumentTypeId"] = new SelectList(_context.GroupItemEntity, "Id", "Id", documentEntity.DocumentTypeId);
            ViewData["PersonalInformationId"] = new SelectList(_context.PersonalInformationEntity, "Id", "Id", documentEntity.PersonalInformationId);
            return View(documentEntity);
        }

        // GET: Document/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var documentEntity = await _context.DocumentEntity.FindAsync(id);
            if (documentEntity == null)
            {
                return NotFound();
            }
            ViewData["EditorId"] = new SelectList(_context.Users, "Id", "Id", documentEntity.EditorId);
            ViewData["DocumentTypeId"] = new SelectList(_context.GroupItemEntity, "Id", "Id", documentEntity.DocumentTypeId);
            ViewData["PersonalInformationId"] = new SelectList(_context.PersonalInformationEntity, "Id", "Id", documentEntity.PersonalInformationId);
            return View(documentEntity);
        }

        // POST: Document/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PersonalInformationId,Observation,DocumentTypeId,Extension,Id,EditorId,DateCreated,DateModified")] DocumentEntity documentEntity)
        {
            if (id != documentEntity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(documentEntity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DocumentEntityExists(documentEntity.Id))
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
            ViewData["EditorId"] = new SelectList(_context.Users, "Id", "Id", documentEntity.EditorId);
            ViewData["DocumentTypeId"] = new SelectList(_context.GroupItemEntity, "Id", "Id", documentEntity.DocumentTypeId);
            ViewData["PersonalInformationId"] = new SelectList(_context.PersonalInformationEntity, "Id", "Id", documentEntity.PersonalInformationId);
            return View(documentEntity);
        }

        // GET: Document/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var documentEntity = await _context.DocumentEntity
                .Include(d => d.ApplicationUserEntity)
                .Include(d => d.DocumentTypeGroupItemEntity)
                .Include(d => d.PersonalInformationEntity)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (documentEntity == null)
            {
                return NotFound();
            }

            return View(documentEntity);
        }

        // POST: Document/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var documentEntity = await _context.DocumentEntity.FindAsync(id);
            if (documentEntity != null)
            {
                _context.DocumentEntity.Remove(documentEntity);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DocumentEntityExists(int id)
        {
            return _context.DocumentEntity.Any(e => e.Id == id);
        }
        */
    }
}

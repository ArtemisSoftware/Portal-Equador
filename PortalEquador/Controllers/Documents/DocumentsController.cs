
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PortalEquador.Constants;
using PortalEquador.Data;
using PortalEquador.Data.CurriculumVitae;
using PortalEquador.Domain;
using PortalEquador.Domain.Documents.UseCases;
using PortalEquador.Domain.Documents.ViewModels;
using PortalEquador.Domain.GroupTypes.UseCases;

namespace PortalEquador.Controllers.Documents
{
    public class DocumentsController : Controller
    {
        private readonly GetDocumentCreationModelUseCase _getDocumentCreationModelUseCase;
        private readonly SaveDocumentUseCase _saveDocumentUseCase;
        private readonly GetAllDocumentsUseCase _getDocumentsUseCase;
        private readonly DeleteDocumentUseCase _deleteDocumentUseCase;
        private readonly DocumentExistsUseCase _documentExistsUseCase;

        public DocumentsController(
            GetDocumentCreationModelUseCase getDocumentCreationModelUseCase,
            SaveDocumentUseCase saveDocumentUseCase,
            GetAllDocumentsUseCase getDocumentsUseCase,
            DeleteDocumentUseCase deleteDocumentUseCase,
            DocumentExistsUseCase documentExistsUseCase
         )
        {
            _getDocumentCreationModelUseCase = getDocumentCreationModelUseCase;
            _saveDocumentUseCase = saveDocumentUseCase;
            _getDocumentsUseCase = getDocumentsUseCase;
            _deleteDocumentUseCase = deleteDocumentUseCase;
            _documentExistsUseCase = documentExistsUseCase;
        }

        // GET: Documents/Create
        public async Task<IActionResult> Create(int identifier)
        {
            var model = await _getDocumentCreationModelUseCase.Invoke(identifier);
            return View(model);
        }

        // POST: Documents/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DocumentViewModel model)
        {
            var exists = await _documentExistsUseCase.Invoke(model);
            if (exists)
            {
                ModelState.AddModelError(nameof(model.Error), StringConstants.Error.EXISTING_DOCUMENT);
            }
            else
            {
                if (ModelState.IsValid)
                {
                    await _saveDocumentUseCase.Invoke(model);
                    return RedirectToAction(nameof(Index), new { identifier = model.PersonaInformationId });
                }
            }
            
            //ViewData["id"] = model.Id;
            model = await RecoverModel(model);
            return View(model);
            
        }

        // GET: Documents
        public async Task<IActionResult> Index(int identifier, string? username)
        {
            var result = await _getDocumentsUseCase.Invoke(identifier);
            ViewData["identifier"] = identifier;
            ViewData["username"] = username;

            if(result.Count > 0)
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

        private async Task<DocumentViewModel> RecoverModel(DocumentViewModel model)
        {
            var recover = await _getDocumentCreationModelUseCase.Invoke(model.Id);
            return recover;
        }





















        //----------------








        /*
        // GET: Documents/Details/5
        public async Task<IActionResult> Details(int? curriculumId)
        {
            if (curriculumId == null)
            {
                return NotFound();
            }

            var result = await documentRepository.GetAllDocumentsAsync((int)curriculumId);
            var documents = mapper.Map<List<DocumentDetailViewModel>>(result);

            return View(documents);
        }
        */

        /*


        // GET: Documents/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Documents == null)
            {
                return NotFound();
            }

            var document = await _context.Documents.FindAsync(id);
            if (document == null)
            {
                return NotFound();
            }
            ViewData["GroupItemId"] = new SelectList(_context.GroupItems, "Id", "Id", document.GroupItemId);
            ViewData["CurriculumId"] = new SelectList(_context.PersonalInformation, "Id", "Id", document.CurriculumId);
            return View(document);
        }

        // POST: Documents/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FileExtension,CurriculumId,GroupItemId,Id,DateCreated,DateModified")] Document document)
        {
            if (id != document.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(document);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DocumentExists(document.Id))
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
            ViewData["GroupItemId"] = new SelectList(_context.GroupItems, "Id", "Id", document.GroupItemId);
            ViewData["CurriculumId"] = new SelectList(_context.PersonalInformation, "Id", "Id", document.CurriculumId);
            return View(document);
        }

        // GET: Documents/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Documents == null)
            {
                return NotFound();
            }

            var document = await _context.Documents
                .Include(d => d.GroupItem)
                .Include(d => d.PersonalInformation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (document == null)
            {
                return NotFound();
            }

            return View(document);
        }

        // POST: Documents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Documents == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Documents'  is null.");
            }
            var document = await _context.Documents.FindAsync(id);
            if (document != null)
            {
                _context.Documents.Remove(document);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DocumentExists(int id)
        {
            return _context.Documents.Any(e => e.Id == id);
        }*/
    }
}

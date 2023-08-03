using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using PortalEquador.Constants;
using PortalEquador.Contracts;
using PortalEquador.Data;
using PortalEquador.Data.CurriculumVitae;
using PortalEquador.Data.GroupTypes;
using PortalEquador.Models.Documents;
using PortalEquador.Models.GroupTypes;
using PortalEquador.Repositories;

namespace PortalEquador.Controllers.CurriculumVitae
{
    public class DocumentsController : Controller
    {
        private readonly IDocumentRepository documentRepository;
        private readonly IWebHostEnvironment _hostEnvironment;
        private readonly ApplicationDbContext _context;
        private readonly IMapper mapper;

        public DocumentsController(
            ApplicationDbContext context,
            IDocumentRepository documentRepository, 
            IWebHostEnvironment hostEnvironment,
            IMapper mapper
         )
        {
            _context = context; 
            this.documentRepository = documentRepository;
            this._hostEnvironment = hostEnvironment;
            this.mapper = mapper;
        }

        // GET: Documents
        public async Task<IActionResult> Index()
        {
            /*
            var applicationDbContext = _context.Documents.Include(d => d.GroupItem).Include(d => d.PersonalInformation);
            var lolo = await applicationDbContext.ToListAsync();
            return View(lolo);
            */
            var result = await documentRepository.GetAllPersonalDocAsync();
            return View(result);
        }

        // GET: Documents/Create
        public IActionResult Create(int CurriculumId)
        {
            return NotFound();
            /*
            var model = new DocumentCreateViewModel
            {
                DocumentTypes = new SelectList(_context.GroupItems.Where(x => x.GroupId == Groups.DOCUMENTS), "Id", "Description")
            };
            ViewData["CurriculumId"] = CurriculumId;
            return View(model);
            */
        }

        // POST: Documents/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DocumentCreateViewModel documentCreateViewModel)
        {

            return RedirectToAction(nameof(Index));
            /*
            if (ModelState.IsValid)
            {
                string fileName = Path.GetFileNameWithoutExtension(documentCreateViewModel.ImageFile.FileName);
                string extension = Path.GetExtension(documentCreateViewModel.ImageFile.FileName);
                string wwwRootPath = _hostEnvironment.WebRootPath;
                string root = wwwRootPath + "/images/" + documentCreateViewModel.CurriculumId + "/";
                fileName = documentCreateViewModel.GroupItemId +  extension;
                
                if (!Directory.Exists(root))
                {
                    Directory.CreateDirectory(root);
                }

                string path = Path.Combine(root, fileName);

                using (var fileStream = new FileStream(path, FileMode.Create))
                 {
                     await documentCreateViewModel.ImageFile.CopyToAsync(fileStream);
                 }

                var document = mapper.Map<DocumentEntity>(documentCreateViewModel);
                document.FileExtension = extension;
                await documentRepository.AddAsync(document);

                return RedirectToAction(nameof(Index));
            }
            ViewData["GroupItemId"] = new SelectList(_context.GroupItems, "Id", "Description", documentCreateViewModel.GroupItemId);
            ViewData["CurriculumId"] = new SelectList(_context.PersonalInformation, "Id", "Id", documentCreateViewModel.CurriculumId);
            return View(documentCreateViewModel);
            */
        }

        
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

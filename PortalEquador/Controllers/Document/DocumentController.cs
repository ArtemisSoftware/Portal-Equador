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

        // GET: Documents
        public async Task<IActionResult> Index(int identifier, string fullName)
        {
            var result = await documentRepository.GetAllDocuments(identifier);
            ViewData["identifier"] = identifier;
            ViewData["username"] = fullName;

            return View(result);
        }

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

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id, int identifier, string username)
        {
            await documentRepository.DeleteDocument(identifier, id);
            return RedirectToAction(nameof(Index), new { identifier = identifier, fullName = username });
        }


        private async Task<DocumentViewModel> RecoverModel(DocumentViewModel model)
        {
            return await documentRepository.GetCreateModel(model.Id, model.FullName);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PortalEquador.Data;
using PortalEquador.Data.Uniforms.Entities;
using PortalEquador.Domain.GroupTypes.Repository;
using PortalEquador.Domain.GroupTypes.ViewModels;
using PortalEquador.Domain.Uniforms.Repository;
using PortalEquador.Domain.Uniforms.ViewModels;
using PortalEquador.Util.Constants;

namespace PortalEquador.Controllers.Uniform
{
    public class UniformController(
        IUniformRepository repository
        ) : Controller
    {

        // GET: Uniform
        public async Task<IActionResult> Index()
        {
            var model = await repository.GetAll();
            return View(model);
        }

        public IActionResult Create()
        {
            return View();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UniformViewModel viewModel)
        {
            if (await repository.UniformExists(viewModel.Description))
            {
                ModelState.AddModelError(nameof(viewModel.Error), StringConstants.Error.EXISTING_DESCRIPTION);
            }
            else
            {
                if (ModelState.IsValid)
                {
                    await repository.Save(viewModel);
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(viewModel);
        }


        public async Task<IActionResult> Details(int id)
        {
            var model = await repository.GetUniform(id);

            if (model == null)
            {
                return NotFound();
            }
            else
            {
                return View(model);
            }
        }
        /*
                // GET: Uniform/Details/5
                public async Task<IActionResult> Details(int? id)
                {
                    if (id == null)
                    {
                        return NotFound();
                    }

                    var uniformEntity = await _context.UniformEntity
                        .Include(u => u.ApplicationUserEntity)
                        .FirstOrDefaultAsync(m => m.Id == id);
                    if (uniformEntity == null)
                    {
                        return NotFound();
                    }

                    return View(uniformEntity);
                }

                // GET: Uniform/Create
                public IActionResult Create()
                {
                    ViewData["EditorId"] = new SelectList(_context.Users, "Id", "Id");
                    return View();
                }

                // POST: Uniform/Create
                // To protect from overposting attacks, enable the specific properties you want to bind to.
                // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
                [HttpPost]
                [ValidateAntiForgeryToken]
                public async Task<IActionResult> Create([Bind("Description,Observation,isSizeNumeric,Active,Id,EditorId,DateCreated,DateModified")] UniformEntity uniformEntity)
                {
                    if (ModelState.IsValid)
                    {
                        _context.Add(uniformEntity);
                        await _context.SaveChangesAsync();
                        return RedirectToAction(nameof(Index));
                    }
                    ViewData["EditorId"] = new SelectList(_context.Users, "Id", "Id", uniformEntity.EditorId);
                    return View(uniformEntity);
                }

                // GET: Uniform/Edit/5
                public async Task<IActionResult> Edit(int? id)
                {
                    if (id == null)
                    {
                        return NotFound();
                    }

                    var uniformEntity = await _context.UniformEntity.FindAsync(id);
                    if (uniformEntity == null)
                    {
                        return NotFound();
                    }
                    ViewData["EditorId"] = new SelectList(_context.Users, "Id", "Id", uniformEntity.EditorId);
                    return View(uniformEntity);
                }

                // POST: Uniform/Edit/5
                // To protect from overposting attacks, enable the specific properties you want to bind to.
                // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
                [HttpPost]
                [ValidateAntiForgeryToken]
                public async Task<IActionResult> Edit(int id, [Bind("Description,Observation,isSizeNumeric,Active,Id,EditorId,DateCreated,DateModified")] UniformEntity uniformEntity)
                {
                    if (id != uniformEntity.Id)
                    {
                        return NotFound();
                    }

                    if (ModelState.IsValid)
                    {
                        try
                        {
                            _context.Update(uniformEntity);
                            await _context.SaveChangesAsync();
                        }
                        catch (DbUpdateConcurrencyException)
                        {
                            if (!UniformEntityExists(uniformEntity.Id))
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
                    ViewData["EditorId"] = new SelectList(_context.Users, "Id", "Id", uniformEntity.EditorId);
                    return View(uniformEntity);
                }

                // GET: Uniform/Delete/5
                public async Task<IActionResult> Delete(int? id)
                {
                    if (id == null)
                    {
                        return NotFound();
                    }

                    var uniformEntity = await _context.UniformEntity
                        .Include(u => u.ApplicationUserEntity)
                        .FirstOrDefaultAsync(m => m.Id == id);
                    if (uniformEntity == null)
                    {
                        return NotFound();
                    }

                    return View(uniformEntity);
                }

                // POST: Uniform/Delete/5
                [HttpPost, ActionName("Delete")]
                [ValidateAntiForgeryToken]
                public async Task<IActionResult> DeleteConfirmed(int id)
                {
                    var uniformEntity = await _context.UniformEntity.FindAsync(id);
                    if (uniformEntity != null)
                    {
                        _context.UniformEntity.Remove(uniformEntity);
                    }

                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }

                private bool UniformEntityExists(int id)
                {
                    return _context.UniformEntity.Any(e => e.Id == id);
                }
        */
    }
}

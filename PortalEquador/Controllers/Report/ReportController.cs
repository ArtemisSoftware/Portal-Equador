using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PortalEquador.Data;
using PortalEquador.Data.Contract.Entities;
using PortalEquador.Domain.Report.Repository;
using PortalEquador.Domain.Report.ViewModels;
using PortalEquador.Domain.Trainning.Repository;
using PortalEquador.Domain.Trainning.UseCases;
using PortalEquador.Util;

namespace PortalEquador.Controllers.Report
{
    public class ReportController(
        IReportRepository repository
        ) : Controller
    {

        // GET: Report
        public async Task<IActionResult> Index()
        {
            var result = await repository.GetAlchoolTestReport();
            return View();
        }



        [HttpGet]
        public async Task<FileResult> ExportAgeReportInExcel()
        {
            var result = await repository.GetAgeReport();
            return ReportUtil.GenerateReport(result);
        }

        /*
        private void FileResult GenerateExcel(AgeReportViewModel viewModel)
        {
            DataTable dataTable = new DataTable("People");


            dataTable.Columns.AddRange(
                new DataColumn[]
                {
                    new DataColumn("Id"),
                    new DataColumn("Name")
                }
             );

            foreach (var item in viewModel.report)
            {
                dataTable.Rows.Add(
                    item.DateOfBirth.ToString(),
                    item.Age(),
                    item.WorkStation
                 );
            }
            
            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dataTable);
                using (MemoryStream stream = new MemoryStream())
                {
                    wb.SaveAs(stream);

                    return File(stream.ToArray(),
                        "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                        fileName);
                }
            }
            
        }
        */






        /*
        // GET: Report/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contractEntity = await _context.ContractEntity
                .Include(c => c.ApplicationUserEntity)
                .Include(c => c.ContractGroupItemEntity)
                .Include(c => c.ContractStateGroupItemEntity)
                .Include(c => c.PersonalInformationEntity)
                .Include(c => c.ResignationReasonGroupItemEntity)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contractEntity == null)
            {
                return NotFound();
            }

            return View(contractEntity);
        }

        // GET: Report/Create
        public IActionResult Create()
        {
            ViewData["EditorId"] = new SelectList(_context.Users, "Id", "Id");
            ViewData["ContractId"] = new SelectList(_context.GroupItemEntity, "Id", "Id");
            ViewData["ContractStateId"] = new SelectList(_context.GroupItemEntity, "Id", "Id");
            ViewData["PersonalInformationId"] = new SelectList(_context.PersonalInformationEntity, "Id", "Id");
            ViewData["ResignationReasonId"] = new SelectList(_context.GroupItemEntity, "Id", "Id");
            return View();
        }

        // POST: Report/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PersonalInformationId,ContractId,ResignationReasonId,ContractStateId,Observation,DateOfContract,Id,EditorId,DateCreated,DateModified")] ContractEntity contractEntity)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contractEntity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EditorId"] = new SelectList(_context.Users, "Id", "Id", contractEntity.EditorId);
            ViewData["ContractId"] = new SelectList(_context.GroupItemEntity, "Id", "Id", contractEntity.ContractId);
            ViewData["ContractStateId"] = new SelectList(_context.GroupItemEntity, "Id", "Id", contractEntity.ContractStateId);
            ViewData["PersonalInformationId"] = new SelectList(_context.PersonalInformationEntity, "Id", "Id", contractEntity.PersonalInformationId);
            ViewData["ResignationReasonId"] = new SelectList(_context.GroupItemEntity, "Id", "Id", contractEntity.ResignationReasonId);
            return View(contractEntity);
        }

        // GET: Report/Edit/5
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
            ViewData["ContractId"] = new SelectList(_context.GroupItemEntity, "Id", "Id", contractEntity.ContractId);
            ViewData["ContractStateId"] = new SelectList(_context.GroupItemEntity, "Id", "Id", contractEntity.ContractStateId);
            ViewData["PersonalInformationId"] = new SelectList(_context.PersonalInformationEntity, "Id", "Id", contractEntity.PersonalInformationId);
            ViewData["ResignationReasonId"] = new SelectList(_context.GroupItemEntity, "Id", "Id", contractEntity.ResignationReasonId);
            return View(contractEntity);
        }

        // POST: Report/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PersonalInformationId,ContractId,ResignationReasonId,ContractStateId,Observation,DateOfContract,Id,EditorId,DateCreated,DateModified")] ContractEntity contractEntity)
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
            ViewData["ContractId"] = new SelectList(_context.GroupItemEntity, "Id", "Id", contractEntity.ContractId);
            ViewData["ContractStateId"] = new SelectList(_context.GroupItemEntity, "Id", "Id", contractEntity.ContractStateId);
            ViewData["PersonalInformationId"] = new SelectList(_context.PersonalInformationEntity, "Id", "Id", contractEntity.PersonalInformationId);
            ViewData["ResignationReasonId"] = new SelectList(_context.GroupItemEntity, "Id", "Id", contractEntity.ResignationReasonId);
            return View(contractEntity);
        }

        // GET: Report/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contractEntity = await _context.ContractEntity
                .Include(c => c.ApplicationUserEntity)
                .Include(c => c.ContractGroupItemEntity)
                .Include(c => c.ContractStateGroupItemEntity)
                .Include(c => c.PersonalInformationEntity)
                .Include(c => c.ResignationReasonGroupItemEntity)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contractEntity == null)
            {
                return NotFound();
            }

            return View(contractEntity);
        }

        // POST: Report/Delete/5
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;
using PortalEquador.Data;
using PortalEquador.Data.Scheduler.Entities;
using PortalEquador.Domain.GroupTypes.UseCases;
using PortalEquador.Domain.GroupTypes.ViewModels;
using PortalEquador.Domain.Scheduler.MechanicalWorkshop.ViewModels;

namespace PortalEquador.Controllers.MechanicalWorkshopScheduler
{
    public class MechanicalWorkshopSchedulerController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MechanicalWorkshopSchedulerController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: MechanicalWorkshopScheduler
        public async Task<IActionResult> Index()
        {
            //var applicationDbContext = _context.MechanicalWorkshopSchedulerEntity.Include(m => m.InterventionTimeGroupItemEntity).Include(m => m.MechanicGroupItemEntity);
            //return View(await applicationDbContext.ToListAsync());

            var main = new LoloVml();
            var models = new List<MechanicalWorkshopSchedulerViewModel>();

            var mechanics = new List<GroupItemViewModel>();
            mechanics.Add(
   new GroupItemViewModel
   {
       Id = 1,
       Description = "Mec 1"
   }
);
            mechanics.Add(
   new GroupItemViewModel
   {
       Id = 2,
       Description = "Mec 2"
   }
);
            mechanics.Add(
               new GroupItemViewModel
               {
                   Id = 3,
                   Description = "Mec 3"
               }
            );

            var schedules = new List<GroupItemViewModel>();
            schedules.Add(
   new GroupItemViewModel
   {
       Id = 1,
       Description = "08:00 - 09:30"
   }
);
            schedules.Add(
   new GroupItemViewModel
   {
       Id = 2,
       Description = "10:00 - 11:30"
   }
);
            schedules.Add(
               new GroupItemViewModel
               {
                   Id = 3,
                   Description = "12:00 - 13:30"
               }
            );

            main.Mechanics = mechanics;

            var lolo = new MechanicalWorkshopSchedulerViewModel();
            lolo.Id = 1;
            lolo.Contract = "Contract 1";
            lolo.LicencePlate = "AA-BB-CC";
            lolo.InterventionTime = new GroupItemViewModel
            {
                Id = 1,
                Description = "08:00 - 09:30"
            };
            lolo.Mechanic = new GroupItemViewModel
            {
                Id = 1,
                Description = "Mec 1"
            };

            var lolo2 = new MechanicalWorkshopSchedulerViewModel();
            lolo2.Id = 2;
            lolo2.Contract = "CVX";
            lolo2.LicencePlate = "BB-BB-BB";
            lolo2.InterventionTime = new GroupItemViewModel
            {
                Id = 2,
                Description = "10:00 - 11:30"
            };
            lolo2.Mechanic = new GroupItemViewModel
            {
                Id = 2,
                Description = "Mec 2"
            };

            var lolo3 = new MechanicalWorkshopSchedulerViewModel();
            lolo3.Id = 3;
            lolo3.Contract = "ALGN";
            lolo3.LicencePlate = "CC-CC-CC";
            lolo3.InterventionTime = new GroupItemViewModel
            {
                Id = 1,
                Description = "08:00 - 09:30"
            };
            lolo3.Mechanic = new GroupItemViewModel
            {
                Id = 3,
                Description = "Mec 3"
            };

            

            //1, GroupItemViewModel(1, ), GroupItemViewModel(),"AA-AA-AA", DateTime.UtcNow

           
            models.Add(lolo);
            models.Add(lolo2);
            models.Add(lolo3);
            main.registers = models;
            main.Schedules = schedules;
            main.RegisteredDictionary = main.colab();
            main.RegisteredTime = main.colabTime();
           

           
            return View(main);
        }

        /*

        // GET: MechanicalWorkshopScheduler/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.MechanicalWorkshopSchedulerEntity == null)
            {
                return NotFound();
            }

            var mechanicalWorkshopSchedulerEntity = await _context.MechanicalWorkshopSchedulerEntity
                .Include(m => m.InterventionTimeGroupItemEntity)
                .Include(m => m.MechanicGroupItemEntity)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mechanicalWorkshopSchedulerEntity == null)
            {
                return NotFound();
            }

            return View(mechanicalWorkshopSchedulerEntity);
        }

        // GET: MechanicalWorkshopScheduler/Create
        public IActionResult Create()
        {
            ViewData["InterventionTimeId"] = new SelectList(_context.GroupItemEntity, "Id", "Id");
            ViewData["MechanicId"] = new SelectList(_context.GroupItemEntity, "Id", "Id");
            return View();
        }

        // POST: MechanicalWorkshopScheduler/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("InterventionTimeId,MechanicId,LicencePlate,ScheduleDate,Id,DateCreated,DateModified")] MechanicalWorkshopSchedulerEntity mechanicalWorkshopSchedulerEntity)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mechanicalWorkshopSchedulerEntity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["InterventionTimeId"] = new SelectList(_context.GroupItemEntity, "Id", "Id", mechanicalWorkshopSchedulerEntity.InterventionTimeId);
            ViewData["MechanicId"] = new SelectList(_context.GroupItemEntity, "Id", "Id", mechanicalWorkshopSchedulerEntity.MechanicId);
            return View(mechanicalWorkshopSchedulerEntity);
        }

        // GET: MechanicalWorkshopScheduler/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.MechanicalWorkshopSchedulerEntity == null)
            {
                return NotFound();
            }

            var mechanicalWorkshopSchedulerEntity = await _context.MechanicalWorkshopSchedulerEntity.FindAsync(id);
            if (mechanicalWorkshopSchedulerEntity == null)
            {
                return NotFound();
            }
            ViewData["InterventionTimeId"] = new SelectList(_context.GroupItemEntity, "Id", "Id", mechanicalWorkshopSchedulerEntity.InterventionTimeId);
            ViewData["MechanicId"] = new SelectList(_context.GroupItemEntity, "Id", "Id", mechanicalWorkshopSchedulerEntity.MechanicId);
            return View(mechanicalWorkshopSchedulerEntity);
        }

        // POST: MechanicalWorkshopScheduler/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("InterventionTimeId,MechanicId,LicencePlate,ScheduleDate,Id,DateCreated,DateModified")] MechanicalWorkshopSchedulerEntity mechanicalWorkshopSchedulerEntity)
        {
            if (id != mechanicalWorkshopSchedulerEntity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mechanicalWorkshopSchedulerEntity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MechanicalWorkshopSchedulerEntityExists(mechanicalWorkshopSchedulerEntity.Id))
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
            ViewData["InterventionTimeId"] = new SelectList(_context.GroupItemEntity, "Id", "Id", mechanicalWorkshopSchedulerEntity.InterventionTimeId);
            ViewData["MechanicId"] = new SelectList(_context.GroupItemEntity, "Id", "Id", mechanicalWorkshopSchedulerEntity.MechanicId);
            return View(mechanicalWorkshopSchedulerEntity);
        }

        // GET: MechanicalWorkshopScheduler/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.MechanicalWorkshopSchedulerEntity == null)
            {
                return NotFound();
            }

            var mechanicalWorkshopSchedulerEntity = await _context.MechanicalWorkshopSchedulerEntity
                .Include(m => m.InterventionTimeGroupItemEntity)
                .Include(m => m.MechanicGroupItemEntity)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mechanicalWorkshopSchedulerEntity == null)
            {
                return NotFound();
            }

            return View(mechanicalWorkshopSchedulerEntity);
        }

        // POST: MechanicalWorkshopScheduler/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.MechanicalWorkshopSchedulerEntity == null)
            {
                return Problem("Entity set 'ApplicationDbContext.MechanicalWorkshopSchedulerEntity'  is null.");
            }
            var mechanicalWorkshopSchedulerEntity = await _context.MechanicalWorkshopSchedulerEntity.FindAsync(id);
            if (mechanicalWorkshopSchedulerEntity != null)
            {
                _context.MechanicalWorkshopSchedulerEntity.Remove(mechanicalWorkshopSchedulerEntity);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MechanicalWorkshopSchedulerEntityExists(int id)
        {
          return (_context.MechanicalWorkshopSchedulerEntity?.Any(e => e.Id == id)).GetValueOrDefault();
        }
        */
    }
}

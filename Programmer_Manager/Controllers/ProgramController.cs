using Data_Programmer_Manager;
using Programmer_Manager.ViewModels.Program;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Programmer_Manager.Controllers
{
    public class ProgramController : Controller
    {
        private readonly ProgrammerDbContext context;

        public ProgramController(ProgrammerDbContext context)
        {
            this.context = context;
        }

        public async Task<IActionResult> Index()
        {
            var programs = await context.Programs
                .Include(d => d.Programmer)
                .ToListAsync();

            var model = new List<ProgramIndexViewModel>();

            foreach (var program in programs)
            {
                model.Add(new ProgramIndexViewModel
                {
                    Id = program.Id,
                    Name = program.Name,
                    ProgrammingLanguage = program.ProgrammingLanguage,
                    Version = program.Version,
                    ProgrammerName = program.Programmer != null ? program.Programmer.Name : "(no owner)"
                });
            }

            return View(model);
        }

        public async Task<IActionResult> Details(int id)
        {
            var program = await context.Programs
                .Include(d => d.Programmer)
                .FirstOrDefaultAsync(d => d.Id == id);

            if (program == null)
            {
                return NotFound();
            }

            var model = new ProgramDetailsViewModel
            {
                Id = program.Id,
                Name = program.Name,
                Description = program.Description,
                ProgrammingLanguage = program.ProgrammingLanguage,
                Version = program.Version,
                ProgrammerName = program.Programmer != null ? program.Programmer.Name : "(no owner)"
            };

            return View(model);
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.Programmers = new SelectList(
            await context.Programmers
         .Where(p => !p.IsDeleted)
         .ToListAsync(),
             "Id",
            "Name");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProgramCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                var program = new Data_Programmer_Manager.Entities.Program
                {
                    Name = model.Name,
                    Description = model.Description,
                    ProgrammingLanguage = model.ProgrammingLanguage,
                    Version = model.Version,
                    ProgrammerId = model.ProgrammerId
                };

                context.Programs.Add(program);
                await context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            ViewBag.Programmers = new SelectList(
                await context.Programmers
                    .Where(p => !p.IsDeleted)
                    .ToListAsync(),
                "Id",
                "Name");

            return View(model);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var program = await context.Programs.FindAsync(id);

            if (program == null)
            {
                return NotFound();
            }

            var model = new ProgramEditViewModel
            {
                Id = program.Id,
                Name = program.Name,
                Description = program.Description,
                ProgrammingLanguage = program.ProgrammingLanguage,
                Version = program.Version,
                ProgrammerId = program.ProgrammerId
            };

            ViewBag.Programmers = new SelectList(
                    await context.Programmers
                        .Where(p => !p.IsDeleted)
                        .ToListAsync(),
                    "Id",
                    "Name");

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, ProgramEditViewModel model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var program = await context.Programs.FindAsync(id);

                if (program == null)
                {
                    return NotFound();
                }

                program.Name = model.Name;
                program.Description = model.Description;
                program.ProgrammingLanguage = model.ProgrammingLanguage;
                program.Version = model.Version;
                program.ProgrammerId = model.ProgrammerId;

                await context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            ViewBag.Programmers = new SelectList(
                  await context.Programmers
                      .Where(p => !p.IsDeleted)
                      .ToListAsync(),
                  "Id",
                  "Name");

            return View(model);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var program = await context.Programs.FindAsync(id);

            if (program == null)
            {
                return NotFound();
            }

            var model = new ProgramDeleteViewModel
            {
                Id = program.Id,
                Name = program.Name,
                ProgrammingLanguage = program.ProgrammingLanguage
            };

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var program = await context.Programs.FindAsync(id);

            if (program != null)
            {
                context.Programs.Remove(program);
                await context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}

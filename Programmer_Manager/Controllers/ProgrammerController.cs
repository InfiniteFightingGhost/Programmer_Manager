using Data_Programmer_Manager;
using Data_Programmer_Manager.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Programmer_Manager.ViewModels.Programmer;

namespace Programmer_Manager.Controllers
{

    public class ProgrammerController : Controller
    {

        private readonly ProgrammerDbContext context;

        public ProgrammerController(ProgrammerDbContext context)
        {
            this.context = context;
        }

        
            
        public async Task<IActionResult> Index()
        {
            var programmers = await context.Programmers
                .Where(p => !p.IsDeleted)
                .ToListAsync();

            var model = new List<ProgrammerIndexViewModel>();

            foreach (var programmer in programmers)
            {
                model.Add(new ProgrammerIndexViewModel
                {
                    Id = programmer.Id,
                    Name = programmer.Name,
                    Address = programmer.Address,
                    Email = programmer.Email,
                    PhoneNumber = programmer.PhoneNumber,
                    YearsOfExperience = programmer.YearsOfExperience
                });
            }

            return View(model);
        }
        

        public async Task<IActionResult> Details(int id)
        {
            var programmer = await context.Programmers.FindAsync(id);

            if (programmer == null)
            {
                return NotFound();
            }

            var model = new ProgrammerDetailsViewModel
            {
                Id = programmer.Id,
                Name = programmer.Name,
                Address = programmer.Address,
                Email = programmer.Email,
                PhoneNumber = programmer.PhoneNumber,
                YearsOfExperience = programmer.YearsOfExperience,
                CreatedOn = programmer.CreatedOn
            };

            return View(model);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProgrammerCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                var programmer = new Programmer
                {
                    Name = model.Name,
                    Address = model.Address,
                    Email = model.Email,
                    PhoneNumber = model.PhoneNumber,
                    YearsOfExperience = model.YearsOfExperience,
                    CreatedOn = DateTime.Now,
                    IsDeleted = false
                };

                context.Programmers.Add(programmer);
                await context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var programmer = await context.Programmers.FindAsync(id);

            if (programmer == null)
            {
                return NotFound();
            }

            var model = new ProgrammerEditViewModel
            {
                Id = programmer.Id,
                Name = programmer.Name,
                Address = programmer.Address,
                Email = programmer.Email,
                PhoneNumber = programmer.PhoneNumber,
                YearsOfExperience = programmer.YearsOfExperience
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, ProgrammerEditViewModel model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var programmer = await context.Programmers.FindAsync(id);

                if (programmer == null)
                {
                    return NotFound();
                }

                programmer.Name = model.Name;
                programmer.Address = model.Address;
                programmer.Email = model.Email;
                programmer.PhoneNumber = model.PhoneNumber;
                programmer.YearsOfExperience = model.YearsOfExperience;

                await context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var programmer = await context.Programmers.FindAsync(id);

            if (programmer == null)
            {
                return NotFound();
            }

            var model = new ProgrammerDeleteViewModel
            {
                Id = programmer.Id,
                Name = programmer.Name
            };

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var programmer = await context.Programmers.FindAsync(id);

            if (programmer != null)
            {
                programmer.IsDeleted = true;

                await context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}


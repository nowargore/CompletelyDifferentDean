using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CompletelyDifferentDean.Application.Services;
using CompletelyDifferentDean.Dto.Disciplines;

namespace CompletelyDifferentDean.Web.Controllers
{
    [Authorize]
    public class DisciplinesController : Controller
    {
        private readonly IDisciplineService _service;

        public DisciplinesController(IDisciplineService service)
        {
            _service = service;
        }

        // GET: Disciplines
        public async Task<IActionResult> Index()
        {
            return View(await _service.ListAsync());
        }

        // GET: Disciplines/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var discipline = await _service.GetAsync((int)id);
            if (discipline == null)
            {
                return NotFound();
            }

            return View(discipline);
        }

        // GET: Disciplines/Create
        public IActionResult Create()
        {
            return View("CreateUpdate");
        }

        // POST: Disciplines/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description")] DisciplineCreateUpdateDto discipline)
        {
            if (ModelState.IsValid)
            {
                await _service.AddAsync(discipline);
                return RedirectToAction(nameof(Index));
            }
            return View("CreateUpdate", discipline);
        }

        // GET: Disciplines/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var discipline = await _service.GetForEditAsync((int)id);
            if (discipline == null)
            {
                return NotFound();
            }
            return View("CreateUpdate", discipline);
        }
         
        // POST: Disciplines/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description")] DisciplineCreateUpdateDto discipline)
        {
            if (id != discipline.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _service.UpdateAsync(discipline);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await _service.ExistsAsync(id))
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
            return View("CreateUpdate", discipline);
        }

        // GET: Disciplines/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var discipline = await _service.GetAsync((int)id);
            if (discipline == null)
            {
                return NotFound();
            }

            return View(discipline);
        }

        // POST: Disciplines/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}

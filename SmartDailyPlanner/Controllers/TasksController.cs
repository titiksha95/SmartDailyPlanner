using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartDailyPlanner.Data;
using SmartDailyPlanner.Models;

namespace SmartDailyPlanner.Controllers
{
    public class TasksController : Controller
    {

        private readonly ApplicationDbContext _context;

        public TasksController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            List<PlannerTask> tasks =
                await _context.PlannerTasks
                    .OrderBy(task => task.DueDate).ToListAsync();
                    
            return View(tasks);
        }

        // Opens the Create page
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // Receives and saves the submitted form
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
            PlannerTask plannerTask)
        {
            if (!ModelState.IsValid)
            {
                return View(plannerTask);
            }

            plannerTask.CreatedAt = DateTime.Now;

            _context.PlannerTasks.Add(plannerTask);

            await _context.SaveChangesAsync();

            TempData["SuccessMessage"] =
                "Task created successfully.";

            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateStatus(
            int id,
            bool isCompleted)
        {
            PlannerTask? plannerTask =
                await _context.PlannerTasks.FindAsync(id);

            if (plannerTask == null)
            {
                return NotFound();
            }

            plannerTask.IsCompleted = isCompleted;

            await _context.SaveChangesAsync();

            TempData["SuccessMessage"] =
                "Task status updated successfully.";

            return RedirectToAction(nameof(Index));
        }
    }
}

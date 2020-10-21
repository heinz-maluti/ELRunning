using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ELRunning.Data;
using ELRunning.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace ELRunning.Controllers
{
    public class AthleteController : Controller
    {
        private readonly ApplicationDbContext _context;
        private UserManager<AppUser> _userManager;

        public AthleteController(ApplicationDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Athlete
        public async Task<IActionResult> Index(string ViewType = "CURR")
        {
            List<ActivityEvent> AllEvents = await _context.ActivityEvents.ToListAsync();

            switch(ViewType)
            {
                case "PREV":
                    {
                        //for FUTURE events
                        AllEvents = AllEvents
                            .OrderBy(x => x.StartDate)
                            .Where(x => x.EndDate < DateTime.Now)
                            .Take(5)
                            .ToList();

                        break;
                    }
                case "FUTR":
                    {
                        //for PAST events
                        AllEvents = AllEvents
                            .OrderBy(x => x.StartDate)
                            .Where(x => x.StartDate > DateTime.Now)
                            .Take(5)
                            .ToList();
                        break;
                    }
                default:
                    {
                        //for CURRENT events
                        AllEvents = AllEvents
                            .OrderBy(x => x.StartDate)
                            .Where(x => x.StartDate < DateTime.Now)
                            .Where(x => x.EndDate > DateTime.Now)
                            .Take(5)
                            .ToList();
                        break;
                    }
            }

            return View(AllEvents);
        }

        // GET: Athlete/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var activityLog = await _context.ActivityLogs
                .FirstOrDefaultAsync(m => m.ActivityLogID == id);
            if (activityLog == null)
            {
                return NotFound();
            }

            return View(activityLog);
        }

        // GET: Athlete/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Athlete/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ActivityLogID,TimeLogged,Units")] ActivityLog activityLog)
        {
            if (ModelState.IsValid)
            {
                activityLog.ActivityLogID = Guid.NewGuid();
                _context.Add(activityLog);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(activityLog);
        }

        // GET: Athlete/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var activityLog = await _context.ActivityLogs.FindAsync(id);
            if (activityLog == null)
            {
                return NotFound();
            }
            return View(activityLog);
        }

        // POST: Athlete/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("ActivityLogID,TimeLogged,Units")] ActivityLog activityLog)
        {
            if (id != activityLog.ActivityLogID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(activityLog);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ActivityLogExists(activityLog.ActivityLogID))
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
            return View(activityLog);
        }

        // GET: Athlete/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var activityLog = await _context.ActivityLogs
                .FirstOrDefaultAsync(m => m.ActivityLogID == id);
            if (activityLog == null)
            {
                return NotFound();
            }

            return View(activityLog);
        }

        // POST: Athlete/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var activityLog = await _context.ActivityLogs.FindAsync(id);
            _context.ActivityLogs.Remove(activityLog);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult LogActivity(Guid ActivityEventID)
        {
            ActivityEvent ActivityEvent = _context.ActivityEvents.Find(ActivityEventID);

            if (ActivityEvent == null) return NotFound();

            List<ActivityLog> Logs = _context.ActivityLogs
                .Where(x => x.Event.ActivityEventID == ActivityEventID)
                .ToList();

            ActivityEvent.EventType = _context.EventTypes.Find(ActivityEvent.EventTypeID);

            return View(ActivityEvent);
        }

        [HttpPost]
        public async Task<IActionResult> LogActivity(ActivityLog activityLog, IFormCollection fc)
        {
            if (ModelState.IsValid)
            {
                activityLog.ActivityLogID = Guid.NewGuid();
                
                string dist = fc["distance"];
                activityLog.Units = Convert.ToInt32(dist);

                string aeid = fc["ActivityEventID"];
                activityLog.Event = _context.ActivityEvents.Find(new Guid(aeid));

                AppUser user = await _userManager.FindByEmailAsync(User.Identity.Name);
                activityLog.User = user;

                _context.Add(activityLog);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(activityLog);
        }

        private bool ActivityLogExists(Guid id)
        {
            return _context.ActivityLogs.Any(e => e.ActivityLogID == id);
        }
    }
}

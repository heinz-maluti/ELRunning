using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ELRunning.Data;
using ELRunning.Models;

namespace ELRunning.Controllers
{
    public class ActivityEventsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ActivityEventsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ActivityEvents
        public async Task<IActionResult> Index()
        {
            return View(await _context.ActivityEvents.ToListAsync());
        }

        public async Task<IActionResult> EventTypeIndex()
        {
            return View(await _context.EventTypes.ToListAsync());
        }

        // GET: ActivityEvents/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var activityEvent = await _context.ActivityEvents
                .FirstOrDefaultAsync(m => m.ActivityEventID == id);
            if (activityEvent == null)
            {
                return NotFound();
            }

            return View(activityEvent);
        }

        // GET: ActivityEvents/Create
        public IActionResult Create()
        {
            List<EventType> et = _context.EventTypes.ToList();
            ViewBag.message = et;

            return View();
        }

        public IActionResult CreateEventType()
        {
            return View();
        }

        // POST: ActivityEvents/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ActivityEventID,EventName,StartDate,EndDate,Distance,EventType")] ActivityEvent activityEvent)
        {
            if (ModelState.IsValid)
            {
                activityEvent.ActivityEventID = Guid.NewGuid();
                activityEvent.EventType = activityEvent.EventType ?? _context.EventTypes.Where(x => x.TypeName == "Running").FirstOrDefault();
                _context.Add(activityEvent);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(activityEvent);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateEventType(EventType eventType)
        {
            if (ModelState.IsValid)
            {
                eventType.EventTypeID = Guid.NewGuid();
                _context.Add(eventType);
                await _context.SaveChangesAsync();
                return RedirectToAction("EventTypeIndex");
            }
            return View(eventType);
        }

        // GET: ActivityEvents/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var activityEvent = await _context.ActivityEvents.FindAsync(id);
            if (activityEvent == null)
            {
                return NotFound();
            }
            return View(activityEvent);
        }

        // POST: ActivityEvents/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("ActivityEventID,EventName,StartDate,EndDate,Distance,EventType")] ActivityEvent activityEvent)
        {
            if (id != activityEvent.ActivityEventID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(activityEvent);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ActivityEventExists(activityEvent.ActivityEventID))
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
            return View(activityEvent);
        }

        // GET: ActivityEvents/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var activityEvent = await _context.ActivityEvents
                .FirstOrDefaultAsync(m => m.ActivityEventID == id);
            if (activityEvent == null)
            {
                return NotFound();
            }

            return View(activityEvent);
        }

        // POST: ActivityEvents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var activityEvent = await _context.ActivityEvents.FindAsync(id);
            _context.ActivityEvents.Remove(activityEvent);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ActivityEventExists(Guid id)
        {
            return _context.ActivityEvents.Any(e => e.ActivityEventID == id);
        }
    }
}

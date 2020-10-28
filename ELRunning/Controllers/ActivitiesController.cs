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

namespace ELRunning.Controllers
{
    public class ActivitiesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ActivitiesController(ApplicationDbContext context)
        {
            _context = context;
            SeedData();
        }

        // GET: Activities
        public async Task<IActionResult> Index()
        {
            return View(await _context.ActivityEvents.ToListAsync());
        }

        // GET: Activities/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var activityEvent = await _context.ActivityEvents
                .FirstOrDefaultAsync(m => m.ActivityEventID == id);
            activityEvent.EventType = _context.EventTypes.Find(activityEvent.EventTypeID);
            if (activityEvent == null)
            {
                return NotFound();
            }

            return View(activityEvent);
        }

        // GET: Activities/Create
        public IActionResult Create()
        {
            ViewBag.ddlEventTypes = _context.EventTypes.ToList().OrderBy(x => x.TypeName);
            return View();
        }

        // POST: Activities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //, Microsoft.AspNetCore.Http.FormCollection fc
        //[Bind("ActivityEventID,EventName,StartDate,EndDate,Distance,EventType")] 
        public async Task<IActionResult> Create(IFormCollection fc, ActivityEvent activityEvent) 
        {
            if (ModelState.IsValid)
            {
                string y = fc["ddlEventType"];
                activityEvent.ActivityEventID = Guid.NewGuid();
                activityEvent.EventType = _context.EventTypes.Find(new Guid(y));
                _context.Add(activityEvent);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.ddlEventTypes = _context.EventTypes.ToList().OrderBy(x => x.TypeName);

            return View(activityEvent);
        }

        // GET: Activities/Edit/5
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
            ViewBag.ddlEventTypes = _context.EventTypes.ToList().OrderBy(x => x.TypeName);
            return View(activityEvent);
        }

        // POST: Activities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("ActivityEventID,EventName,StartDate,EndDate,Distance")] ActivityEvent activityEvent)
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
            ViewBag.ddlEventTypes = _context.EventTypes.ToList().OrderBy(x => x.TypeName);
            return View(activityEvent);
        }

        // GET: Activities/Delete/5
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

        // POST: Activities/Delete/5
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

        public bool SeedData()
        {
            bool change = false;

            if (_context.Countries.Count()==0)
            {
                List<Country> countries = new List<Country>();
                countries.Add(new Country(new Guid("12C6E74B-41D9-4056-9D75-28C36C06CE45"), "USA"));
                countries.Add(new Country(new Guid("BEAF367C-15D5-4C04-A801-871E28E33086"), "ZA"));

                _context.Countries.AddRange(countries);
                change = true;
            }

            if (_context.Gender.Count()==0)
            {
                List<Gender> genders = new List<Gender>();
                genders.Add(new Gender(new Guid("FF735D70-90D4-4029-82D5-924C0FC58FA0"), "Male"));
                genders.Add(new Gender(new Guid("31F03DDB-CAEA-4230-A02A-F8E7B576FFBF"),"Female"));

                _context.Gender.AddRange(genders);
                change = true;
            }

            if (change)
            {
                _context.SaveChanges();
            }

            return change;
        }
    }
}

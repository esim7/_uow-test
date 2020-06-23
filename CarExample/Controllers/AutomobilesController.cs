using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Domain.Model;
using Domain.Model.Enums;
using Infrastructure.DataBase.Interfaces;
using Infrastructure.EntityFramework;

namespace CarExample.Controllers
{
    public class AutomobilesController : Controller
    {
        //private readonly AutomobileDataContext _context;
        private readonly IUnitOfWork _uow;

        public AutomobilesController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<IActionResult> Index()
        {
            //return View(await _context.Automobiles.ToListAsync());
            return View(_uow.Automobiles.GetAll());
        }

        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var automobile = await _context.Automobiles
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (automobile == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(automobile);
        //}

        //public IActionResult Create()
        //{
        //    ViewBag.Colors = new SelectList(Enum.GetValues(typeof(ConsoleColor)));
        //    ViewBag.BodyTypes = new SelectList(Enum.GetValues(typeof(BodyType)));
        //    return View();
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Brand,Color,BodyType,Power,Id,CreationDate")] Automobile automobile)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(automobile);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(automobile);
        //}

        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var automobile = await _context.Automobiles.FindAsync(id);
        //    if (automobile == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(automobile);
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Brand,Color,BodyType,Power,Id,CreationDate")] Automobile automobile)
        //{
        //    if (id != automobile.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(automobile);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!AutomobileExists(automobile.Id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(automobile);
        //}

        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var automobile = await _context.Automobiles
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (automobile == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(automobile);
        //}

        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var automobile = await _context.Automobiles.FindAsync(id);
        //    _context.Automobiles.Remove(automobile);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool AutomobileExists(int id)
        //{
        //    return _context.Automobiles.Any(e => e.Id == id);
        //}
    }
}

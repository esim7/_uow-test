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
        private readonly IUnitOfWork _uow;

        public AutomobilesController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public IActionResult Index()
        {
            return View(_uow.Automobiles.GetAll());
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var automobile = _uow.Automobiles.Get(id);
            if (automobile == null)
            {
                return NotFound();
            }

            return View(automobile);
        }

        public IActionResult Create()
        {
            ViewBag.Colors = new SelectList(Enum.GetValues(typeof(ConsoleColor)));
            ViewBag.BodyTypes = new SelectList(Enum.GetValues(typeof(BodyType)));
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Brand,Color,BodyType,Power,Id,CreationDate")] Automobile automobile)
        {
            if (ModelState.IsValid)
            {
                _uow.Automobiles.Create(automobile);
                _uow.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(automobile);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var automobile = _uow.Automobiles.Get(id);
            if (automobile == null)
            {
                return NotFound();
            }
            ViewBag.Colors = new SelectList(Enum.GetValues(typeof(ConsoleColor)));
            ViewBag.BodyTypes = new SelectList(Enum.GetValues(typeof(BodyType)));
            return View(automobile);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Brand,Color,BodyType,Power,Id,CreationDate")] Automobile automobile)
        {
            if (id != automobile.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _uow.Automobiles.Edit(automobile);
                _uow.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(automobile);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var automobile = _uow.Automobiles.Get(id);
            if (automobile == null)
            {
                return NotFound();
            }

            return View(automobile);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var automobile = _uow.Automobiles.Get(id);
            _uow.Automobiles.Remove(automobile);
            _uow.Save();
            return RedirectToAction(nameof(Index));
        }
    }
}

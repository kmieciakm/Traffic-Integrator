﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PBLWeb.Areas.Identity.Repository;
using PBLWeb.Data;

namespace PBLWeb.Controllers
{
    public class SupplierDataController : Controller
    {
        private ILogger<SupplierDataController> _Logger { get; }
        private ISupplierDataRepository _SupplierRepo { get; }

        public SupplierDataController( ILogger<SupplierDataController> logger,
            ISupplierDataRepository supplierRepo)
        {
            _Logger = logger;
            _SupplierRepo = supplierRepo;
        }

        // GET: SupplierData
        public IActionResult Index()
        {
            return View(_SupplierRepo.GetSuppliers());
        }

        // GET: SupplierData/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SupplierData/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create( [Bind("Id,Name,ApiUrl")] SupplierData supplierData ) {
            try {
                if (ModelState.IsValid) {
                    supplierData.Active = false;
                    
                    bool addedSuccessfully = _SupplierRepo.Add(supplierData);
                    if (!addedSuccessfully) {
                        throw new InvalidOperationException(
                            $"Cannot create supplier");
                    }
                    _Logger.LogInformation($"Successfully created supplier (Id = {supplierData.Id})");
                    return RedirectToAction(nameof(Index));
                }
                return View(supplierData);
            } catch (InvalidOperationException e) {
                ModelState.AddModelError(String.Empty, "Something went wrong, sorry");
                _Logger.LogError(e.Message);
                return View(supplierData);
            }
        }

        // GET: SupplierData/Edit/5
        public IActionResult Edit( int id ) {
            if (!_SupplierRepo.Exists(id)) {
                return NotFound();
            } else {
                var supplierData = _SupplierRepo.GetSupplierById(id);
                return View(supplierData);
            }
        }

        // POST: SupplierData/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit( int id, [Bind("Id,Name,ApiUrl")] SupplierData supplierData ) {
            if (id != supplierData.Id) {
                return NotFound();
            }

            if (ModelState.IsValid) {
                try {
                    var editSuccessfully = _SupplierRepo.Update(supplierData);
                    if (!editSuccessfully) {
                        throw new InvalidOperationException(
                                $"Cannot update supplier with id {supplierData.Id}");
                    }
                    _Logger.LogInformation($"Successfully edited supplier with id {supplierData.Id}");
                } catch (InvalidOperationException e) {
                    ModelState.AddModelError(String.Empty, "Something went wrong, sorry");
                    _Logger.LogError(e.Message);
                    return View(supplierData);
                }
                return RedirectToAction(nameof(Index));
            }
            return View(supplierData);
        }

        // GET: SupplierData/Delete/5
        public IActionResult Delete( int id ) {
            if (!_SupplierRepo.Exists(id)) {
                return NotFound();
            } else {
                var supplierData = _SupplierRepo.GetSupplierById(id);
                return View(supplierData);
            }
        }

        // POST: SupplierData/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed( int id ) {
            var deletedSuccessfully = _SupplierRepo.DeleteById(id);
            if (!deletedSuccessfully) {
                _Logger.LogError($"Cannot delete supplier with id {id}");
            }
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Activate( int id ) {
            try {
                var supplierData = _SupplierRepo.GetSupplierById(id);
                supplierData.Active = true;
                var changedSuccessfully = _SupplierRepo.Update(supplierData);
                if(!changedSuccessfully) {
                    throw new InvalidOperationException(
                        $"Cannot change status of supplier with id {id}");
                }
                _Logger.LogInformation($"Successfully changed status of supplier with id {id}");
            } catch (Exception e) {
                _Logger.LogError(e.Message);
            }
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Disable( int id ) {
            try {
                var supplierData = _SupplierRepo.GetSupplierById(id);
                supplierData.Active = false;
                var changedSuccessfully = _SupplierRepo.Update(supplierData);
                if (!changedSuccessfully) {
                    throw new InvalidOperationException(
                        $"Cannot change status of supplier with id {id}");
                }
                _Logger.LogInformation($"Successfully changed status of supplier with id {id}");
            } catch (Exception e) {
                _Logger.LogError(e.Message);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}

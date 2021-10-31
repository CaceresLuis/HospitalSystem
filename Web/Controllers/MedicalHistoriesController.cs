using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Controllers
{
    public class MedicalHistoriesController : Controller
    {
        // GET: MedicalHistoriesController
        public ActionResult Index()
        {
            return View();
        }

        // GET: MedicalHistoriesController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MedicalHistoriesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MedicalHistoriesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MedicalHistoriesController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MedicalHistoriesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MedicalHistoriesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MedicalHistoriesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}

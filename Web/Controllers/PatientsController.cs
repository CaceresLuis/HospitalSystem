using System;
using MediatR;
using Core.Dtos;
using Core.Enums;
using Core.Exceptions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Core.Services.Patients.Read;
using Core.Services.Patients.List;
using Core.Services.Patients.Create;
using Core.Services.Patients.Update;
using Core.Services.Patients.Delete;

namespace Web.Controllers
{
    public class PatientsController : Controller
    {
        private readonly IMediator _mediator;

        public PatientsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<ActionResult> Index()
        {
            return View(await _mediator.Send(new ListPatientsQuery()));
        }

        public async Task<IActionResult> Details(Guid id)
        {
            try
            {
                return View(await _mediator.Send(new ReadPatientQuery { Id = id }));
            }
            catch (ExceptionHandler e)
            {
                TempData["Title"] = e.Error.Title;
                TempData["Message"] = e.Error.Message;
                TempData["State"] = State.error.ToString();

                return RedirectToAction(nameof(Index));
            }
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(PatientsDto patientsDto)
        {
            try
            {
                await _mediator.Send(new CreatePatientCommand { Patient = patientsDto });
                TempData["Title"] = "Created";
                TempData["Message"] = $"The patient {patientsDto.FullName} was created";
                TempData["State"] = State.success.ToString();

                return RedirectToAction(nameof(Index));
            }
            catch (ExceptionHandler e)
            {
                TempData["Title"] = e.Error.Title;
                TempData["Message"] = e.Error.Message;
                TempData["State"] = State.error.ToString();

                return View(patientsDto);
            }
        }

        public async Task<ActionResult> Edit(Guid id)
        {
            return View(await _mediator.Send(new ReadPatientQuery { Id = id }));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Guid id, PatientsDto patientsDto)
        {
            patientsDto.Id = id;
            try
            {
                await _mediator.Send(new UpdatePatientCommad { PatientsDto = patientsDto });
                TempData["Title"] = "Updated";
                TempData["Message"] = $"The patient {patientsDto.FullName} was updated";
                TempData["State"] = State.success.ToString();

                return RedirectToAction(nameof(Index));
            }
            catch (ExceptionHandler e)
            {
                TempData["Title"] = e.Error.Title;
                TempData["Message"] = e.Error.Message;
                TempData["State"] = State.error.ToString();

                return View(patientsDto);
            }
        }

        public async Task<ActionResult> Delete(Guid id)
        {
            try
            {
                await _mediator.Send(new DeletePatientCommand { Id = id });
                TempData["Title"] = "Deleted";
                TempData["Message"] = "The patient was deleted";
                TempData["State"] = State.success.ToString();

                return RedirectToAction(nameof(Index));
            }
            catch (ExceptionHandler e)
            {
                TempData["Title"] = e.Error.Title;
                TempData["Message"] = e.Error.Message;
                TempData["State"] = State.error.ToString();

                return RedirectToAction(nameof(Index));
            }
        }
    }
}

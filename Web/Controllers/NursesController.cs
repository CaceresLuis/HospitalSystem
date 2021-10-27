using System;
using MediatR;
using Core.Dtos;
using Core.Enums;
using Core.Exceptions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Core.Services.Nurses.List;
using Core.Services.Nurses.Read;
using Core.Services.Nurses.Create;
using Core.Services.Nurses.Delete;
using Core.Services.Nurses.Update;

namespace Web.Controllers
{
    public class NursesController : Controller
    {
        private readonly IMediator _mediator;

        public NursesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<ActionResult> Index()
        {
            return View(await _mediator.Send(new ListNursesQuery()));
        }

        public async Task<ActionResult> Details(Guid id)
        {
            try
            {
                return View(await _mediator.Send(new ReadNurseQuery { Id = id }));
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
        public async Task<ActionResult> Create(NurseDto nurseDto)
        {
            try
            {
                await _mediator.Send(new CreateNurseCommand { NurseDto = nurseDto });
                TempData["Title"] = "Created";
                TempData["Message"] = $"The patient {nurseDto.FullName} was created";
                TempData["State"] = State.success.ToString();

                return RedirectToAction(nameof(Index));
            }
            catch (ExceptionHandler e)
            {
                TempData["Title"] = e.Error.Title;
                TempData["Message"] = e.Error.Message;
                TempData["State"] = State.error.ToString();

                return View(nurseDto);
            }
        }

        public async Task<ActionResult> Edit(Guid id)
        {
            return View(await _mediator.Send(new ReadNurseQuery { Id = id }));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Guid id, NurseDto nurseDto)
        {
            nurseDto.Id = id;
            try
            {
                await _mediator.Send(new UpdateNuseCommand { NurseDto = nurseDto });
                TempData["Title"] = "Updated";
                TempData["Message"] = $"The patient {nurseDto.FullName} was updated";
                TempData["State"] = State.success.ToString();

                return RedirectToAction(nameof(Index));
            }
            catch (ExceptionHandler e)
            {
                TempData["Title"] = e.Error.Title;
                TempData["Message"] = e.Error.Message;
                TempData["State"] = State.error.ToString();

                return View(nurseDto);
            }
        }

        public async Task<ActionResult> Delete(Guid id)
        {
            try
            {
                await _mediator.Send(new DeleteNurseCommand { Id = id });
                TempData["Title"] = "Deleted";
                TempData["Message"] = "The nurse was deleted";
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

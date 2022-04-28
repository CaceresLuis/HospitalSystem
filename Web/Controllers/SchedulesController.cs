using System;
using MediatR;
using Core.Dtos;
using Core.Enums;
using Core.Exceptions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Core.Services.Schedules.List;
using Core.Services.Schedules.Create;
using Core.Services.Schedules.Delete;

namespace Web.Controllers
{
    public class SchedulesController : Controller
    {
        private readonly IMediator _mediator;

        public SchedulesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<ActionResult> Index()
        {
            return View(await _mediator.Send(new ListSchedulesQuery()));
        }

        // GET: SchedulesController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateScheduleDto scheduleDto)
        {
            try
            {
                await _mediator.Send(new CreateScheduleCommand { ScheduleDto = scheduleDto });
                TempData["Title"] = "Created";
                TempData["Message"] = $"The Eschedule for day {scheduleDto.Date} {scheduleDto.Hour} was created";
                TempData["State"] = State.success.ToString();

                return RedirectToAction(nameof(Index));
            }
            catch (ExceptionHandler e)
            {
                TempData["Title"] = e.Error.Title;
                TempData["Message"] = e.Error.Message;
                TempData["State"] = State.error.ToString();

                return View(scheduleDto);
            }
        }

        // GET: SchedulesController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SchedulesController/Edit/5
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

        public async Task<ActionResult> Delete(Guid id)
        {
            try
            {
                await _mediator.Send(new DeleteScheduleCommand { Id = id });
                TempData["Title"] = "Deleted";
                TempData["Message"] = "The Schedule was deleted";
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

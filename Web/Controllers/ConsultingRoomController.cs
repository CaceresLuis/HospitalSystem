using System;
using MediatR;
using Core.Dtos;
using Core.Enums;
using Core.Exceptions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Core.Services.Doctors.List;
using Core.Services.Doctors.Read;
using Core.Services.Doctors.Create;
using Core.Services.Doctors.Delete;
using Core.Services.Doctors.Update;
using Core.Services.ConsultingRoom.List;
using Core.Services.ConsultingRoom.Create;
using Core.Services.ConsultingRoom.Read;
using Core.Services.ConsultingRoom.Update;
using Core.Services.ConsultingRoom.Delete;

namespace Web.Controllers
{
    public class ConsultingRoomController : Controller
    {
        private readonly IMediator _mediator;

        public ConsultingRoomController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<ActionResult> Index()
        {
            return View(await _mediator.Send(new ListConsultingRoomsQuery()));
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ConsultingRoomDto consultingRoomDto)
        {
            try
            {
                await _mediator.Send(new CreateConsultingRoomCommand { ConsultingRoomDto = consultingRoomDto });
                TempData["Title"] = "Created";
                TempData["Message"] = $"The doctor {consultingRoomDto.Name} was created";
                TempData["State"] = State.success.ToString();

                return RedirectToAction(nameof(Index));
            }
            catch (ExceptionHandler e)
            {
                TempData["Title"] = e.Error.Title;
                TempData["Message"] = e.Error.Message;
                TempData["State"] = State.error.ToString();

                return View(consultingRoomDto);
            }
        }

        public async Task<ActionResult> Edit(Guid id)
        {
            return View(await _mediator.Send(new ReadConsultingRoomQuery { Id = id }));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Guid id, ConsultingRoomDto consultingRoomDto)
        {
            consultingRoomDto.Id = id;
            try
            {
                await _mediator.Send(new UpdateconsultingRoomCommand { consultingRoomDto = consultingRoomDto });
                TempData["Title"] = "Updated";
                TempData["Message"] = $"The doctor {consultingRoomDto.Name} was updated";
                TempData["State"] = State.success.ToString();

                return RedirectToAction(nameof(Index));
            }
            catch (ExceptionHandler e)
            {
                TempData["Title"] = e.Error.Title;
                TempData["Message"] = e.Error.Message;
                TempData["State"] = State.error.ToString();

                return View(consultingRoomDto);
            }
        }

        public async Task<ActionResult> Delete(Guid id)
        {
            try
            {
                await _mediator.Send(new DeleteConsultingRoomCommand { Id = id });
                TempData["Title"] = "Deleted";
                TempData["Message"] = "The consultoring room was deleted";
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

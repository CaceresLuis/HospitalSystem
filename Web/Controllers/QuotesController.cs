using System;
using MediatR;
using Core.Dtos;
using Core.Enums;
using Core.Exceptions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Core.Services.Quotes.List;
using Core.Services.Doctors.List;
using Core.Services.Quotes.Create;
using System.Collections.Generic;

namespace Web.Controllers
{
    public class QuotesController : Controller
    {
        private readonly IMediator _mediator;

        public QuotesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<ActionResult> Index()
        {
            List<QuoteDto> quotes = await _mediator.Send(new ListQuoteQuery());
            return View(quotes);
        }

        //public async Task<ActionResult> Details(Guid id)
        //{
        //    try
        //    {
        //        return View(await _mediator.Send(new ReadDoctorQuery { Id = id }));
        //    }
        //    catch (ExceptionHandler e)
        //    {
        //        TempData["Title"] = e.Error.Title;
        //        TempData["Message"] = e.Error.Message;
        //        TempData["State"] = State.error.ToString();

        //        return RedirectToAction(nameof(Index));
        //    }
        //}

        public async Task<ActionResult> Create(Guid id)
        {
            System.Collections.Generic.List<DoctorDto> doctors = await _mediator.Send(new ListDoctorQuery());
            CreateQuoteDto createQuoteDto = new()
            {
                MedicalHistory = id,
                Doctors = doctors
            };
            return View(createQuoteDto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateQuoteDto createQuoteDto)
        {
            try
            {
                await _mediator.Send(new CreateQuoteCommand { CreateQuoteDto = createQuoteDto });
                TempData["Title"] = "Created";
                TempData["Message"] = $"appointment for {createQuoteDto.MedicalHistory} was successfully booked";
                TempData["State"] = State.success.ToString();

                return RedirectToAction(nameof(Index));
            }
            catch (ExceptionHandler e)
            {
                TempData["Title"] = e.Error.Title;
                TempData["Message"] = e.Error.Message;
                TempData["State"] = State.error.ToString();

                return View(createQuoteDto);
            }
        }

        //public async Task<ActionResult> Edit(Guid id)
        //{
        //    return View(await _mediator.Send(new ReadDoctorQuery { Id = id }));
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> Edit(Guid id, DoctorDto doctorDto)
        //{
        //    doctorDto.Id = id;
        //    try
        //    {
        //        await _mediator.Send(new UpdateDoctorCommad { DoctorDto = doctorDto });
        //        TempData["Title"] = "Updated";
        //        TempData["Message"] = $"The doctor {doctorDto.FullName} was updated";
        //        TempData["State"] = State.success.ToString();

        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch (ExceptionHandler e)
        //    {
        //        TempData["Title"] = e.Error.Title;
        //        TempData["Message"] = e.Error.Message;
        //        TempData["State"] = State.error.ToString();

        //        return View(doctorDto);
        //    }
        //}

        //public async Task<ActionResult> Delete(Guid id)
        //{
        //    try
        //    {
        //        await _mediator.Send(new DeleteDoctorCommand { Id = id });
        //        TempData["Title"] = "Deleted";
        //        TempData["Message"] = "The doctor was deleted";
        //        TempData["State"] = State.success.ToString();

        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch (ExceptionHandler e)
        //    {
        //        TempData["Title"] = e.Error.Title;
        //        TempData["Message"] = e.Error.Message;
        //        TempData["State"] = State.error.ToString();

        //        return RedirectToAction(nameof(Index));
        //    }
        //}
    }
}

using System;
using MediatR;
using Core.Dtos;
using Core.Enums;
using Core.Exceptions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Core.Services.Quotes.Create;

namespace Web.Controllers
{
    public class QuotesController : Controller
    {
        private readonly IMediator _mediator;

        public QuotesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        //public async Task<ActionResult> Index()
        //{
        //    return View(await _mediator.Send(new ListDoctorQuery()));
        //}

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

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(QuoteDto quoteDto)
        {
            try
            {
                await _mediator.Send(new CreateQuoteCommand { QuoteDto = quoteDto });
                TempData["Title"] = "Created";
                TempData["Message"] = $"appointment for {quoteDto.MedicalHistory.Expedient} was successfully booked";
                TempData["State"] = State.success.ToString();

                return RedirectToAction(nameof(Index));
            }
            catch (ExceptionHandler e)
            {
                TempData["Title"] = e.Error.Title;
                TempData["Message"] = e.Error.Message;
                TempData["State"] = State.error.ToString();

                return View(quoteDto);
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

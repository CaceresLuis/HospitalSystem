using System;
using MediatR;
using Core.Dtos;
using Core.Enums;
using Core.Exceptions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Core.Services.Quotes.List;
using Core.Services.Doctors.List;
using System.Collections.Generic;
using Core.Services.Quotes.Create;
using Core.Services.Patients.Search;

namespace Web.Controllers
{
    public class QuotesController : Controller
    {
        private readonly IMediator _mediator;

        public QuotesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> Patients(SearchPatientDto searchPatientDto)
        {
            return View(await _mediator.Send(new ListSearchPatientsQuery { SearchPatientDto = searchPatientDto }));
        }

        public async Task<ActionResult> Create(Guid id)
        {
            List<DoctorDto> doctors = await _mediator.Send(new ListDoctorQuery());
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
    }
}

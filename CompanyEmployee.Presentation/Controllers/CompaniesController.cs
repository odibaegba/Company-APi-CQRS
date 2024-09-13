using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Application.Commands;
using Application.Notification;
using Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Shared.DataTransferObjects;

namespace CompanyEmployee.Presentation.Controllers
{
    [Route("api/companies")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        private readonly ISender _sender;
        private readonly IPublisher _publisher;
        public CompaniesController(ISender sender, IPublisher publisher)
        {
            _sender = sender;
            _publisher = publisher;
        }

        [HttpGet]
        public async Task<IActionResult> GetCompanies()
        {
            var companies = await _sender.Send(new GetCompaniesQuery(trackChanges : false));
            return Ok(companies);
        }

        [HttpGet("company/{id}", Name = "CompanyById")]
        public async Task<IActionResult> GetCompany(Guid id)
        {
            var company = await _sender.Send(new GetCompanyQuery(id, TrackChanges: false));
            return Ok(company);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCompany([FromBody] CompanyForCreationDto companyDto)
        {
            if (companyDto is null)
            return BadRequest("CompanyForCreationDto object is null");

            var company = await _sender.Send(new CreateCompanyCommand(companyDto));
            return CreatedAtRoute("CompanyById", new {id = company.Id}, company);
        }

        [HttpPut("updatecompany/{id}")]
        public async Task<IActionResult> UpdateCompany(Guid id, CompanyForUpdateDto companyDto)
        {
            if (companyDto is null)
            return BadRequest("CompanyForUpdateDto object is null");

            await _sender.Send(new UpdateCompanyCommand(id, companyDto, trackChanges: true));

            return NoContent();

        }

        [HttpDelete("deletecompany/{id}")]
        public async Task<IActionResult> DeleteCompany(Guid id, CompanyForUpdateDto companyDto) 
        {
           // await _sender.Send(new DeleteCompanyCommand(id, trackChanges: false));
           await _publisher.Publish(new CompanyDeletedNotification(id, trackChanges : false));
            return NoContent();
        }
    }
}
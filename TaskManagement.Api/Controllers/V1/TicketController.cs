using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TaskManagement.Api.Models.Dtos;
using TaskManagement.ApiFramework.Api;
using TaskManagement.Common.Enums;
using TaskManagement.Data.Contracts;
using TaskManagement.Data.Contracts.EntityContract;
using TaskManagement.Entity.DomainModels;

namespace TaskManagement.Api.Controllers.V1
{
    [ApiVersion("1")]
    public class TicketController : GeneralBaseController
    {
        private readonly IUnitOfWork _uow;
        private readonly ITicketRepository _ticketRepository;
        private ILogger<TicketController> _logger;

        public TicketController(IUnitOfWork uow, ITicketRepository ticketRepository, ILogger<TicketController> logger)
        {
            _uow = uow;
            _ticketRepository = ticketRepository;
            _logger = logger;
        }

        //[AllowAnonymous]

        [HttpGet("[action]")]
        public async Task<ApiResult<List<Ticket>>> Get([FromQuery] PaginationDto paging, CancellationToken cancellationToken)
        {
            var result = await _uow.TicketService.GetAsync(paging.Page, paging.PageSize).Result.ToListAsync();

            return result;
        }

        [HttpGet("[action]")]
        public async Task<ApiResult<Ticket>> GetById(Int64 id, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
                return new BadRequestObjectResult(ModelState);

            return await _uow.TicketService.GetByIdAsync(cancellationToken, id);

        }
        [HttpPost("[action]")]
        public async Task<ApiResult> AddNewTicket([FromBody]Ticket ticket, CancellationToken cancellationToken)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                ticket.CreateBy = GetUserIDOfClaim();
                
                await _uow.TicketService.AddAsync(ticket, cancellationToken);
                return Ok();
            }
            catch (Exception e)
            {
                throw new ApplicationException(e.Message,e);
            }
        }

        [HttpPut("[action]")]
        public async Task<ApiResult> EditTicket([FromBody]Ticket ticket,CancellationToken cancellationToken)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(modelState: ModelState);
                }

                await _uow.TicketService.UpdateAsync(ticket, cancellationToken);
                return Ok();
            }
            catch (Exception exception)
            {
                throw new ApplicationException(exception.Message,exception);
            }
        }

        [HttpPost("[action]")]
        public async Task<ApiResult> DeleteTicket([FromBody]Ticket ticket, CancellationToken cancellationToken)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                await _uow.TicketService.DeleteAsync(ticket,cancellationToken);
                return Ok();
            }
            catch (Exception exception)
            {
                throw  new ApplicationException(exception.Message,exception);
            }
        }
    }
}
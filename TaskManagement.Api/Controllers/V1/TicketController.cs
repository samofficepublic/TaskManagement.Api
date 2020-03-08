using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
        [HttpGet("Get")]
        public async Task<ApiResult<List<Ticket>>> Get(int page,int pageSize,CancellationToken cancellationToken)
        {
            //var result =await _uow.TicketService.TableNoTracking.ToListAsync(cancellationToken);
            //return result;


            var result = await _uow.TicketService.GetAsync(page, pageSize).Result.ToListAsync();

            return result;
        }
    }
}

﻿using Api.Facultad.Application.Features.Facultad.Command.CreateFacultad;
using Api.Facultad.Application.Features.Facultad.Queries.GetFacultadById;
using Api.Facultad.Application.Utils;
using Api.Facultad.Domain.DTOs.Base;
using API.Facultad.Routes;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace API.Facultad.Controllers
{
    [ApiController]
    [Route(ApiRoutes.Facultad.Controller)]
    public class FacultadController : ControllerBase
    {
        private IMediator _mediator;
        private readonly ILogger<FacultadController> _logger;
        public FacultadController(IMediator mediator, ILogger<FacultadController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpGet(ApiRoutes.Facultad.FindFacultadById)]
        public async Task<ActionResult<ResponseBase>> GetFacultadById(long id)
        {
            try
            {
                var query = new GetFacultadByIdQuery();
                query.IdFacultad= id;
                return Ok(await _mediator.Send(query));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "", ex.Message);
                return ResponseUtil.BadRequest(ex.Message.ToString());
            }
            
        }

        [HttpPost(ApiRoutes.Facultad.CreateFacultad)]
        public async Task<ActionResult<ResponseBase>> CreateFacultad([FromBody] CreateFacultadCommand command)
        {
            try
            {
                return Ok(await _mediator.Send(command));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "", ex.Message);
                return ResponseUtil.BadRequest(ex.Message.ToString());
            }
        }
                
    }
}
using Api.Facultad.Application.Contracts.Persistence;
using Api.Facultad.Application.Utils;
using Api.Facultad.Domain.DTOs.Base;
using Api.Facultad.Domain.Entities;
using API.Catalogo.Domain.Constants.Base;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Api.Facultad.Application.Features.Facultad.Queries.GetFacultadById
{
    public class GetFacultadByIdQueryHandler : IRequestHandler<GetFacultadByIdQuery, ResponseBase>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly ILogger<GetFacultadByIdQueryHandler> _logger;
        public GetFacultadByIdQueryHandler(IUnitOfWork uow, IMapper mapper, ILogger<GetFacultadByIdQueryHandler> logger)
        {
            _uow = uow;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<ResponseBase> Handle(GetFacultadByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var facultadId = request.IdFacultad;
                var facultadEncontrada = await _uow.Repository<Facultade>().GetAsync(x => !x.IsDeleted && x.Id == facultadId);

                if (facultadEncontrada == null)
                    return ResponseUtil.NotFoundRequest(MessageConstant.NotFoundRequest);
                
                return ResponseUtil.OK(facultadEncontrada!);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "", ex.Message);
                return ResponseUtil.InternalError();
            }
            

        }
    }
}

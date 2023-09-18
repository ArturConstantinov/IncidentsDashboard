﻿using AutoMapper;
using AutoMapper.QueryableExtensions;
using Incidents.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Incidents.Application.Incidents.Queries.OriginQueries.GetAllOrigins
{
    public class GetAllOriginsQuery : IRequest<List<GetAllOriginsVm>>
    {
    }

    public class GetAllOriginsQueryHandler : IRequestHandler<GetAllOriginsQuery, List<GetAllOriginsVm>>
    {
        private readonly IIncidentsDbContext _context;
        private readonly IMapper _mapper;

        public GetAllOriginsQueryHandler(IIncidentsDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<GetAllOriginsVm>> Handle(GetAllOriginsQuery request, CancellationToken cancellationToken)
        {
            var origins = await _context.Origins
                .Select(x => new GetAllOriginsVm
                {
                    Id = x.Id,
                    Name = x.Name,
                })
                .ToListAsync(cancellationToken);

            return origins;
        }
    }
}

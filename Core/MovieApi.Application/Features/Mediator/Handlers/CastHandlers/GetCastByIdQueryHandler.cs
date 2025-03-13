﻿using MediatR;
using Microsoft.EntityFrameworkCore;
using MovieApi.Application.Features.Mediator.Queries.CastQueries;
using MovieApi.Application.Features.Mediator.Results.CastResult;
using MovieApi.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.Mediator.Handlers.CastHandlers
{
    public class GetCastByIdQueryHandler : IRequestHandler<GetCastByIdQuery, GetCastByIdQueryResult>
    {
        private readonly MovieContext _context;

        public GetCastByIdQueryHandler(MovieContext context)
        {
            _context = context;
        }

        public async Task<GetCastByIdQueryResult> Handle(GetCastByIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _context.Casts.FindAsync(request.CastId);
            return new GetCastByIdQueryResult
            {
                CastId = values.CastId,
                Title = values.Title,
                Name = values.Name,
                Surname = values.Surname,
                ImageUrl = values.ImageUrl,
                Overview = values.Overview,
                Biography = values.Biography
            };
        }
    }
}

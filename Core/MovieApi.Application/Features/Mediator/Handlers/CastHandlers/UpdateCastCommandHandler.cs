using MediatR;
using MovieApi.Application.Features.Mediator.Commands.CastCommands;
using MovieApi.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.Mediator.Handlers.CastHandlers
{
    public class UpdateCastCommandHandler : IRequestHandler<UpdateCastCommand>
    {
        private readonly MovieContext _context;

        public UpdateCastCommandHandler(MovieContext context)
        {
            _context = context;
        }

        public async Task Handle(UpdateCastCommand request, CancellationToken cancellationToken)
        {
            var values = await _context.Casts.FindAsync(request.CastId);
            values.Name = request.Name;
            values.Surname = request.Surname;
            values.IamgeUrl = request.IamgeUrl;
            values.Biography = request.Biography;
            values.Title = request.Title;
            values.Overview = request.Overview;
            await _context.SaveChangesAsync();
        }
    }
}

﻿using MovieApi.Application.Features.CQRS.Commands.MovieCommands;
using MovieApi.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.CQRS.Handlers.MovieHandlers
{
    public class RemoveMovieCommandHandler
    {
        private readonly MovieContext _context;

        public RemoveMovieCommandHandler(MovieContext context)
        {
            _context = context;
        }
        public async Task Handler(RemoveMovieCommand command)
        {
            var value = await _context.Movies.FindAsync(command.MovieId);
            _context.Movies.Remove(value);
            await _context.SaveChangesAsync();
        }
    }
}

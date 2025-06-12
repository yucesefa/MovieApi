using Microsoft.AspNetCore.Identity;
using MovieApi.Application.Features.CQRS.Commands.UserRegisterCommands;
using MovieApi.Persistence.Context;
using MovieApi.Persistence.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.CQRS.Handlers.UserRegisterHandlers
{
    public class CreateUserRegisterCommandHandler
    {
        private readonly MovieContext _context;
        private readonly UserManager<AppUser> _userManager;

        public CreateUserRegisterCommandHandler(MovieContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task Handle(CreateUserRegisterCommand command)
        {
            var user = new AppUser
            {
                UserName = command.Username,
                Email = command.Email,
                Name = command.Name,
                Surname = command.Surname
            };
            var result = await _userManager.CreateAsync(user, command.Password);
            if (!result.Succeeded)
            {
                throw new Exception(string.Join(", ", result.Errors.Select(e => e.Description)));
            }

            // Optionally, you can add the user to a role or perform additional actions here
        }
    }
}

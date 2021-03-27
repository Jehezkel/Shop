using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shop.Web.DAL;
using Shop.Web.Models;

namespace Shop.Web.Accounts.Commands
{
    public class RegisterResult
    {
        public string Error { get; set; }
        public bool Success { get; set; }
    }
    public class RegisterCommand : IRequest<RegisterResult>
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
    }
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, RegisterResult>
    {
        private AppDbContext _context;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;

        public RegisterCommandHandler(AppDbContext context, SignInManager<AppUser> signInManager, UserManager<AppUser> userManager)
        {
            _context = context;
            _signInManager = signInManager;
            _userManager = userManager;
        }
        public async Task<RegisterResult> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user != null)
            {
                return new RegisterResult
                {
                    Success = false,
                    Error = "Email address already in use."
                };
            }
            else
            {
                AppUser usrToBeRegistred = new AppUser
                {
                    Email = request.Email,
                    UserName = request.UserName
                };
                var registerResult = await _userManager.CreateAsync(usrToBeRegistred, request.Password);
                var errorsFormatted = registerResult.Errors.Select(e => $"[{e.Code}] {e.Description}").ToArray<string>();
                return new RegisterResult
                {
                    Success = registerResult.Succeeded,
                    Error = String.Join("\n", errorsFormatted)
                };
            }
        }
    }
}
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Shop.Web.DAL;
using Microsoft.AspNetCore.Identity;
using Shop.Web.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.IdentityModel.Tokens.Jwt;
using Shop.Web.Accounts;
using Microsoft.Extensions.Configuration;

namespace Shop.Web.Accounts.Commands
{
    public class LogInCommand : IRequest<LogInResponse>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
    public class LogInResponse
    {
        public AppUser User { get; set; }
        public string Token { get; set; }
    }
    public class LogInCommandHandler : IRequestHandler<LogInCommand, LogInResponse>
    {
        private AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IConfiguration _configuration;
        public LogInCommandHandler(AppDbContext context, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IConfiguration configuration)
        {
            _context = context;
            _signInManager = signInManager;
            _userManager = userManager;
            _configuration = configuration;
        }
        public async Task<LogInResponse> Handle(LogInCommand request, CancellationToken cancellation)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == request.Email);
            if (user == null)
            {
                throw new Exception("Not Registred");
            }
            else
            {
                var pwdCheckResult = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);
                var acc_service = new AccountsService(_configuration);
                if (pwdCheckResult == SignInResult.Success)
                {
                    return new LogInResponse
                    {
                        User = user,
                        Token = new JwtSecurityTokenHandler().WriteToken(acc_service.CreateJwtToken(user.Id))
                    };
                }
                else
                {
                    throw new Exception("Incorrect password");
                }
            }
        }
    }
}
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Shop.Web.DAL;
using Microsoft.AspNetCore.Identity;
using Shop.Web.Models;
using Microsoft.EntityFrameworkCore;

namespace Shop.Web.Accounts.Commands
{
    public class LogInCommand : IRequest<string>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
    public class LogInCommandHandler : IRequestHandler<LogInCommand, string>
    {
        private AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        public LogInCommandHandler(AppDbContext context, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _context = context;
            _signInManager = signInManager;
            _userManager = userManager;
        }
        public async Task<string> Handle(LogInCommand request, CancellationToken cancellation)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == request.Email);
            if (user == null)
            {
                return "not registred";
            }
            else
            {
                var pwdCheckResult = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);
                if (pwdCheckResult == SignInResult.Success)
                {
                    return "Success";
                }
                else
                {
                    return "Incorrect password";
                }
            }
        }
    }
}
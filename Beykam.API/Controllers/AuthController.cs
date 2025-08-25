using System.ComponentModel.DataAnnotations;
using Beykam.Application.Common.Interfaces;
using Beykam.Domain.Entities;
using Beykam.Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Beykam.Persistence.Context;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;



namespace Beykam.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<IdentityRole<Guid>> _roleManager;
        private readonly IJwtTokenService _jwtTokenService;
        private readonly BeykamDbContext _dbContext;

        public AuthController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            RoleManager<IdentityRole<Guid>> roleManager,
            IJwtTokenService jwtTokenService,
            BeykamDbContext dbContext)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _jwtTokenService = jwtTokenService;
            _dbContext = dbContext;
        }

        public record RegisterCandidateRequest(
            [Required, EmailAddress] string Email,
            [Required] string Password,
            [Required] string FirstName,
            [Required] string LastName,
            [Required] string PhoneNumber
        );

        public record RegisterEmployerRequest(
            [Required, EmailAddress] string Email,
            [Required] string Password,
            [Required] string CompanyName,
            string? Phone
        );

        public record LoginRequest([Required] string Email, [Required] string Password);

        [HttpPost("register/candidate")]
        [AllowAnonymous]
        public async Task<IActionResult> RegisterCandidate([FromBody] RegisterCandidateRequest request)
        {
            var user = new ApplicationUser
            {
                UserName = request.Email,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber,
                FullName = $"{request.FirstName} {request.LastName}",
                UserType = UserType.Candidate,
                IsActive = true
            };

            var result = await _userManager.CreateAsync(user, request.Password);
            if (!result.Succeeded)
            {
                return BadRequest(new { errors = result.Errors.Select(e => e.Description) });
            }

            if (!await _roleManager.RoleExistsAsync(Roles.Candidate))
            {
                await _roleManager.CreateAsync(new IdentityRole<Guid>(Roles.Candidate));
            }
            await _userManager.AddToRoleAsync(user, Roles.Candidate);

            // Create Candidate profile
            _dbContext.Candidates.Add(new Candidate
            {
                UserId = user.Id,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber
            });
            await _dbContext.SaveChangesAsync();

            var token = await _jwtTokenService.CreateTokenAsync(user);
            return Ok(new { access_token = token });
        }

        [HttpPost("register/employer")]
        [AllowAnonymous]
        public async Task<IActionResult> RegisterEmployer([FromBody] RegisterEmployerRequest request)
        {
            var user = new ApplicationUser
            {
                UserName = request.Email,
                Email = request.Email,
                PhoneNumber = request.Phone,
                FullName = request.CompanyName,
                UserType = UserType.Employer,
                IsActive = true
            };

            var result = await _userManager.CreateAsync(user, request.Password);
            if (!result.Succeeded)
            {
                return BadRequest(new { errors = result.Errors.Select(e => e.Description) });
            }

            if (!await _roleManager.RoleExistsAsync(Roles.Employer))
            {
                await _roleManager.CreateAsync(new IdentityRole<Guid>(Roles.Employer));
            }
            await _userManager.AddToRoleAsync(user, Roles.Employer);

            // Create Employer profile
            _dbContext.Employers.Add(new Employer
            {
                UserId = user.Id,
                CompanyName = request.CompanyName,
                Phone = request.Phone
            });
            await _dbContext.SaveChangesAsync();

            var token = await _jwtTokenService.CreateTokenAsync(user);
            return Ok(new { access_token = token });
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user is null)
            {
                return Unauthorized();
            }

            if (!user.IsActive)
            {
                return Forbid();
            }

            var result = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);
            if (!result.Succeeded)
            {
                return Unauthorized();
            }

            var token = await _jwtTokenService.CreateTokenAsync(user);
            return Ok(new { access_token = token });
        }

         [HttpGet("me")]
        public async Task<IActionResult> GetCurrentUser(CancellationToken cancellationToken)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (userId == null)
                return Unauthorized();

            var user = await _dbContext.Users
            .Include(u => u.Employer)
            .Include(u => u.Candidate)
            .FirstOrDefaultAsync(u => u.Id == Guid.Parse(userId), cancellationToken);


            if (user == null)
                return NotFound();

            var role = User.FindFirstValue(ClaimTypes.Role);

            return Ok(new
            {
                userId = user.Id,
                email = user.Email,
                fullName = user.FullName,
                role = role,
                employerId = user.Employer?.Id,
                candidateId = user.Candidate?.Id,
    
            });
        }
    }
}



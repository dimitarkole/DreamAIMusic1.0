namespace DreamAIMusic.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using DreamAIMusic.Data.Models;
    using DreamAIMusic.Services.Contracts.Common;
    using DreamAIMusic.Services.Contracts.User;
    using DreamAIMusic.Services.Messaging;
    using DreamAIMusic.Web.Configuration;
    using DreamAIMusic.Web.Extensions;
    using DreamAIMusic.Web.ViewModels.CommonResurces.IdentityModels;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.UI.V3.Pages.Account.Internal;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Options;

    public class IdentityController : ApiController
    {
        private readonly IIdentityService identityService;
		private readonly IEmailSender emailSender;

        public IdentityController(
			IIdentityService identityService,
			IEmailSender emailSender,
			UserManager<ApplicationUser> userManager,
			SignInManager<ApplicationUser> signInManager,
			ILogger<LogoutModel> logger)
			: base(userManager, signInManager, logger)
        {
            this.identityService = identityService;
			this.emailSender = emailSender;
        }

        [HttpPost("[action]")]
        public async Task<ActionResult<ApplicationUser>> Register(RegisterInputModel model)
        {
            var user = new ApplicationUser
            {
                Email = model.Email,
                UserName = model.Username,
            };

            user.Roles.Add(this.identityService.SetUserRole(user));

            IdentityResult result = await this.userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
            {
                return this.BadRequest(result.Errors.Select(e => e.Description).ToList());
            }

            await this.emailSender.SendEmailAfterUserRegistration(model.Email, model.Username, model.Password);
            return user;
        }

        [HttpPost("[action]")]
		public async Task<ActionResult<ApplicationUser>> Login(LoginInputModel model, [FromServices] IOptions<JwtSettings> settings)
		{
			var jwtToken = await this.userManager.Authenticate(model.Username, model.Password, settings.Value);

			if (jwtToken == null)
			{
				return this.BadRequest("Username or password is incorrect.");
			}

			return new JsonResult(jwtToken);
		}

		[Authorize]
		[HttpGet("username")]
		public ActionResult<string> GetUsername()
		{
			return this.User.Identity.Name;
		}
	}
}

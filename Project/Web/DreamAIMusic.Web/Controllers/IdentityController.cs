namespace DreamAIMusic.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using DreamAIMusic.Data.Models;
    using DreamAIMusic.Services.Contracts.Common;
    using DreamAIMusic.Services.Contracts.User;
    using DreamAIMusic.Web.Configuration;
    using DreamAIMusic.Web.Extensions;
    using DreamAIMusic.Web.ViewModels.CommonResurces.IdentityModels;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Options;

    public class IdentityController : ApiController
    {
		private readonly UserManager<ApplicationUser> userManager;

		public IdentityController(UserManager<ApplicationUser> userManager)
		{
			this.userManager = userManager;
		}

		[HttpPost("[action]")]
		public async Task<ActionResult<ApplicationUser>> Register(RegisterInputModel model)
		{
			var user = new ApplicationUser
			{
				Email = model.Email,
				UserName = model.Username,
			};

			IdentityResult result = await userManager.CreateAsync(user, model.Password);
			if (!result.Succeeded)
			{
				return BadRequest(result.Errors.Select(e => e.Description).ToList());
			}
			return user;
		}

		[HttpPost("[action]")]
		public async Task<ActionResult<ApplicationUser>> Login(LoginInputModel model, [FromServices] IOptions<JwtSettings> settings)
		{
			var jwtToken = await userManager.Authenticate(model.Username, model.Password, settings.Value);

			if (jwtToken == null)
			{
				return BadRequest("Username or password is incorrect.");
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

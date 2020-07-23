namespace DreamAIMusic.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using DreamAIMusic.Data.Models;
    using DreamAIMusic.Services.Contracts.Common;
    using DreamAIMusic.Services.Contracts.User;
    using DreamAIMusic.Web.ViewModels.CommonResurces.IdentityModels;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Options;

    public class IdentityController : ApiController
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IIdentityService identityService;
        private readonly ApplicationSettings appSettings;

        public IdentityController(
            UserManager<ApplicationUser> userManager,
            IIdentityService identityService,
            IOptions<ApplicationSettings> appSettings)
        {
            this.userManager = userManager;
            this.identityService = identityService;
            this.appSettings = appSettings.Value;
        }

        [HttpPost]
        [Route(nameof(Regester))]
        public async Task<ActionResult<ApplicationUser>> Regester(RegesterUserRequestModel model)
        {
            var user = new ApplicationUser
            {
                Email = model.Email,
                UserName = model.Username,
            };

            IdentityResult result = await this.userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
            {
                return this.BadRequest(result.Errors.Select(e => e.Description).ToList());
            }

            return user;
        }

        [HttpPost]
        [Route(nameof(Login))]
        public async Task<ActionResult<LoginResponseModel>> Login(LoginUserRequestModel model)
        {
            var user = await this.userManager.FindByNameAsync(model.Username);
            if (user == null)
            {
                return this.Unauthorized();
            }

            var passwordValidator = await this.userManager.CheckPasswordAsync(user, model.Password);

            if (!passwordValidator)
            {
                return this.Unauthorized();
            }

            var encryptToken = this.identityService.GenerateJwtToken(user.Id, user.UserName, this.appSettings.Secret);
            return new LoginResponseModel
            {
                Token = encryptToken,
            };
        }
    }
}

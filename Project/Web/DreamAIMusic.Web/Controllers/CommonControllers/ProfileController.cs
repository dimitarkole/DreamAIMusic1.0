namespace DreamAIMusic.Web.Controllers.CommonControllers.CommentsControllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using DreamAIMusic.Common;
    using DreamAIMusic.Data.Models;
    using DreamAIMusic.Services.Contracts.Common;
    using DreamAIMusic.Web.Infrastucture;
    using DreamAIMusic.Web.Infrastucture.Extensions;
    using DreamAIMusic.Web.ViewModels.CommonResurces.ProfilleModels;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.UI.V3.Pages.Account.Internal;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;

    public class ProfileController : ApiController
    {
        private readonly IProfileService profileService;

        public ProfileController(
            IProfileService profileService,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ILogger<LogoutModel> logger)
            : base(userManager, signInManager, logger)
        {
            this.profileService = profileService;
        }

        [HttpGet]
        public ActionResult All() => this.Ok(this.profileService.All<ProfileViewModel>());

        [HttpGet("{id}")]
        public IActionResult Get(string id) => this.Ok(this.profileService.GetById<ProfileEditModel>(id));

        [HttpGet(nameof(MyProfile))]
        public IActionResult MyProfile() => this.Ok(this.profileService.GetById<ProfileDetailsViewModel>(this.User.GetUserId()));

        [HttpPost(nameof(UploadProfileImage))]
        public async Task<IActionResult> UploadProfileImage(UserProfilePictueInputModel model)
        {
            string userId = this.User.GetUserId();
            await this.profileService.UploadProfileImage(userId, model);
            return this.Ok();
        }

        [AllowAnonymous]
        [HttpGet(nameof(ValidateToken))]
        public IActionResult ValidateToken() => this.Ok(this.User.Identity.IsAuthenticated);

        /*[AllowAnonymous]
        [HttpGet(nameof(HasPermission))]
        public IActionResult HasPermission(PermissionType permissionType)
        {
            if (!this.User.Identity.IsAuthenticated)
            {
                return this.Ok(false);
            }

            return this.Ok(this.profileService.HasPermissions(this.User.GetUserId(), permissionType));
        }*/
        
        [HttpPost(nameof(ChangePassword))]
        public async Task<ActionResult> ChangePassword([FromBody] PasswordChangeInputModel model)
        {
            ApplicationUser user = await this.userManager.GetUserAsync(this.User);

            IdentityResult result = await this.userManager.ChangePasswordAsync(user, model.CurrentPassword, model.NewPassword);
            return result.ToActionResult();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Edit(ProfileEditModel model, string id)
        {
            this.ValidateUser(model, id);
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState.Errors());
            }

            ApplicationUser user = await this.profileService.Update(id, model);
            await this.ClearUserRoles(user);
            await this.userManager.AddToRolesAsync(user, model.Roles);

            return this.Ok();
        }

        [HttpPatch(nameof(ChangePermissions))]
        public async Task<ActionResult> ChangePermissions(ChangePermissionsInputModel model)
        {
            ApplicationUser user = this.userManager.Users.FirstOrDefault(u => u.Id == model.Id);
            await this.ClearUserRoles(user);
            IdentityResult result = await this.userManager.AddToRolesAsync(user, model.Roles);
            return result.ToActionResult();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUser(string id)
        {
            await this.profileService.Delete(id);
            return this.Ok();
        }

        [HttpPost(nameof(RenewUser))]
        public async Task<ActionResult> RenewUser([FromBody] string id)
        {
            await this.profileService.Renew(id);
            return this.Ok();
        }

        [Permission(PermissionType.UserAdministration)]
        [HttpPost(nameof(FindUsers))]
        public ActionResult FindUsers([FromBody] FindUserInputModel model) => this.Ok(this.profileService.Search(model.SearchQuery));

        [Permission(PermissionType.UserAdministration)]
        [HttpPost(nameof(AdvancedSearch))]
        public ActionResult AdvancedSearch([FromBody] UserFilter model) => this.Ok(this.profileService.Search(model));

        [HttpGet(nameof(GetFullNames))]
        public ActionResult GetFullNames() => this.Ok(this.profileService.All<UserFullNameViewModel>());

        [Permission(PermissionType.UserAdministration)]
        [HttpGet("[action]/{id}")]
        public ActionResult GetUserName(string id) => this.Ok(this.profileService.GetById<UserFullNameViewModel>(id));

       /* [HttpPost(nameof(SetTimeZone))]
        public async Task<ActionResult> SetTimeZone(UserTimeZoneInputModel model)
        {
            string id = this.User.GetUserId();
            await this.profileService.SetTimeZone(model.TimeZoneId, id);
            return this.Ok();
        }

        [HttpGet(nameof(GetTimeZone))]
        public ActionResult GetTimeZone()
        {
            string userId = this.User.GetUserId();
            TimeZoneViewModel timeZone = this.profileService.GetTimeZone<TimeZoneViewModel>(userId);
            return this.Ok(timeZone);
        }*/

       /* [HttpGet(nameof(Notifications))]
        public ActionResult Notifications() => Ok(notificationsService.GetUserNotifications<NotificationViewModel>(User.GetUserId()));

        [HttpPost("[action]/{notificationId}")]
        public async Task<ActionResult> MarkNotificationAsSeen(int notificationId)
        {
            if (User.GetUserId() != notificationsService.GetNotificationOwner(notificationId))
            {
                return Forbid();
            }

            await notificationsService.MarkAsSeen(notificationId);
            return Ok();
        }*/

        [Authorize]
        [HttpPost("[action]/{settingId}")]
        public async Task<ActionResult> ToggleSetting(int settingId)
        {
            await this.profileService.ToggleSetting(settingId);
            return this.Ok();
        }

        [HttpPost(nameof(Settings))]
        public ActionResult Settings()
        {
            string userId = this.User.GetUserId();
            IEnumerable<UserSettingViewModel> userSettings = this.profileService.GetSettings<UserSettingViewModel>(userId);
            return this.Ok(userSettings);
        }

        private void ValidateUser(ProfileInputModel model, string id = null)
        {
            if (string.IsNullOrEmpty(model.Username))
            {
                this.ModelState.AddModelError(nameof(ProfileInputModel.Username), "Username is required!");
            }
            else if (this.profileService.UserExistsByUsername(model.Username, id))
            {
                this.ModelState.AddModelError(nameof(ProfileInputModel.Username), "User with the same 'Username' already exists.");
            }

            if (this.profileService.UserExistsByEmail(model.Email, id))
            {
                this.ModelState.AddModelError(nameof(ProfileInputModel.Email), "User with the same 'Email' already exists.");
            }
        }

        private async Task ClearUserRoles(ApplicationUser user)
        {
            IList<string> roles = await this.userManager.GetRolesAsync(user);
            await this.userManager.RemoveFromRolesAsync(user, roles);
        }
    }
}

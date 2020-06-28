namespace DreamAIMusic.Web.Areas.Administration.Controllers
{
    using DreamAIMusic.Common;
    using DreamAIMusic.Web.Controllers;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    [Area("Administration")]
    public class AdministrationController : BaseController
    {
    }
}

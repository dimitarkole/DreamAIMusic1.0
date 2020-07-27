using DreamAIMusic.Common;
using DreamAIMusic.Data.Models;
using DreamAIMusic.Services.Contracts.Administration;
using DreamAIMusic.Web.ViewModels.Administration.CategoriesModels;
using DreamAIMusic.Web.ViewModels.CommonResurces.CategoryModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.V3.Pages.Account.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DreamAIMusic.Web.Controllers
{
    public class CategoryController : ApiController
    {
        private readonly ICategoryService categoryService;

        public CategoryController(ICategoryService categoryService, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, ILogger<LogoutModel> logger, IHostingEnvironment hostingEnvironment) : base(userManager, signInManager, logger, hostingEnvironment)
        {
            this.categoryService = categoryService;
        }

        [HttpGet]
        [Route("/Categoty/[action]")]
        public IActionResult All()
        {
            var all = this.categoryService.All<CategoryViewModel>().ToList();
            return this.Ok(all);
        }

        [HttpPost]
        [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
        [Route("/Categoty/[action]")]
        public async Task<IActionResult> Create(CategoryInputModel model)
        {
            var id = await this.categoryService.Create(model);
            return this.Ok(id);
        }
    }
}

namespace DreamAIMusic.Web.Areas.Administration.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using DreamAIMusic.Data.Models;
    using DreamAIMusic.Services.Contracts.Administration;
    using DreamAIMusic.Web.Areas.Identity.Pages.Account;
    using DreamAIMusic.Web.ViewModels.Administration.CategoriesModels;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;

    public class CategoryController : AdministrationController
    {
        private readonly ICategoryService categoryService;

        public CategoryController(ICategoryService categoryService, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, ILogger<LogoutModel> logger, IHostingEnvironment hostingEnvironment) : base(userManager, signInManager, logger, hostingEnvironment)
        {
            this.categoryService = categoryService;
        }

        [HttpGet]
        // [Route("/Music/Create")]
        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoryInputModel model)
        {
            var userId = this.userManager.GetUserId(this.User);
            this.ViewData["message"] = await this.categoryService.Create(model, userId);
            return this.View(model);
        }
    }
}

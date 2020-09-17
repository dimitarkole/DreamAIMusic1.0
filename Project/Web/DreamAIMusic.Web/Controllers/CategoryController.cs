namespace DreamAIMusic.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using DreamAIMusic.Common;
    using DreamAIMusic.Data.Models;
    using DreamAIMusic.Services.Contracts.Administration;
    using DreamAIMusic.Web.ViewModels.Administration.CategoriesModels;
    using DreamAIMusic.Web.ViewModels.CommonResurces.CategoryModels;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.UI.V3.Pages.Account.Internal;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;

    public class CategoryController : ApiController
    {
        private readonly ICategoryService categoryService;

        public CategoryController(
            ICategoryService categoryService,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ILogger<LogoutModel> logger)
            : base(userManager, signInManager, logger)
        {
            this.categoryService = categoryService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<CategoryViewModel>> Get() => this.Ok(this.categoryService.All<CategoryViewModel>());

        [HttpGet("{id}")]
        public ActionResult<CategoryViewModel> Get(string id) => this.Ok(this.categoryService.GetById<CategoryViewModel>(id));

        [HttpPost]
        public async Task<IActionResult> Post(CategoryInputModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest();
            }

            await this.categoryService.Create(model);
            return this.StatusCode(StatusCodes.Status201Created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, CategoryEditModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest();
            }

            await this.categoryService.Update(id, model);
            return this.Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await this.categoryService.Delete(id);
            return this.Ok();
        }
    }
}

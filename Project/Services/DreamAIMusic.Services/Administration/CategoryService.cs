namespace DreamAIMusic.Services.Administration
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using DreamAIMusic.Data;
    using DreamAIMusic.Data.Models;
    using DreamAIMusic.Services.Contracts.Administration;
    using DreamAIMusic.Services.Mapping;
    using DreamAIMusic.Web.ViewModels.Administration.CategoriesModels;

    public class CategoryService : ICategoryService
    {
        private readonly ApplicationDbContext context;

        public CategoryService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IList<T> All<T>() => this.context.Categories
            .Where(c => c.DeletedOn == null)
            .To<T>()
            .ToList();

        public async Task Create(CategoryInputModel model)
        {
            Category category = model.To<Category>();
            await this.context.Categories.AddAsync(category);
            await this.context.SaveChangesAsync();
        }

        public async Task Delete(string id)
        {
            Category category = this.context.Categories.Find(id);
            this.context.Categories.Remove(category);
            await this.context.SaveChangesAsync();
        }

        public T GetById<T>(string id) =>
            this.context.Categories
            .Where(m => m.Id == id)
            .To<T>()
            .FirstOrDefault();

        public async Task Update(string id, CategoryEditModel model)
        {
            Category category = this.context.Categories
               .FirstOrDefault(s => s.Id == id);

            model.To<Category>(category);

            this.context.Categories.Update(category);
            await this.context.SaveChangesAsync();
        }
    }
}

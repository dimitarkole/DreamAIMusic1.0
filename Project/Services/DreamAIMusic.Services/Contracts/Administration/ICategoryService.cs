namespace DreamAIMusic.Services.Contracts.Administration
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    using DreamAIMusic.Web.ViewModels.Administration.CategoriesModels;

    public interface ICategoryService
    {
        IList<T> All<T>();

        Task<string> Create(CategoryInputModel model);

        Task Update(string id, CategoryEditModel model);

        T GetById<T>(string id);

        Task Delete(string id);
    }
}

using DreamAIMusic.Web.ViewModels.Administration.CategoriesModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DreamAIMusic.Services.Contracts.Administration
{
    public interface ICategoryService
    {
        IList<T> All<T>();

        Task<string> Create(CategoryInputModel model, string userId);

        Task Update(string id, CategoryEditModel model);

        T GetById<T>(string id);

        Task Delete(string id);
    }
}

namespace DreamAIMusic.Web.ViewModels.Administration.CategoriesModels
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using DreamAIMusic.Data.Models;
    using DreamAIMusic.Services.Mapping;

    public class CategoryInputModel : IMapTo<Category>
    {
        public string Name { get; set; }
    }
}

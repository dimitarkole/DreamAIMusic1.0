namespace DreamAIMusic.Web.ViewModels.CommonResurces.CategoryModels
{
    using DreamAIMusic.Data.Models;
    using DreamAIMusic.Services.Mapping;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class CategoryViewModel : IMapFrom<Category>
    {
        public string Id { get; set; }

        public string Name { get; set; }
    }
}
